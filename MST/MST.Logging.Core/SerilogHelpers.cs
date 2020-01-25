using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Enrichers.AspnetcoreHttpcontext;
using Serilog.Filters;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace MST.Flogging.Core
{
    public static class SerilogHelpers
    {
        /// <summary>
        /// Provides standardized, centralized Serilog wire-up for a suite of applications.
        /// </summary>
        /// <param name="loggerConfig">Provide this value from the UseSerilog method param</param>
        /// <param name="provider">Provide this value from the UseSerilog method param as well</param>
        /// <param name="applicationName">Represents the name of YOUR APPLICATION and will be used to segregate your app
        /// from others in the logging sink(s).</param>
        /// <param name="config">IConfiguration settings -- generally read this from appsettings.json</param>
        public static void WithSimpleConfiguration(this LoggerConfiguration loggerConfig,
            IServiceProvider provider, string applicationName, IConfiguration config)
        {
            var name = Assembly.GetExecutingAssembly().GetName();
            var connectionString = config.GetConnectionString("MCBConnectionString");

            loggerConfig
                .ReadFrom.Configuration(config) // minimum levels defined per project in json files 
                .Enrich.WithAspnetcoreHttpcontext(provider, AddCustomContextDetails)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Assembly", $"{name.Name}")
                .Enrich.WithProperty("Version", $"{name.Version}")
           .WriteTo.Logger(lc => lc
                 .Filter.ByExcluding(Matching.WithProperty("ElapsedMilliseconds"))
                 .Filter.ByExcluding(Matching.WithProperty("UsageName"))
                 .WriteTo.MSSqlServer(
                     connectionString: connectionString,
                     tableName: "Log",
                     autoCreateSqlTable: false))
           .WriteTo.Logger(lc => lc
                 .Filter.ByIncludingOnly(Matching.WithProperty("ElapsedMilliseconds"))
                 .WriteTo.MSSqlServer(
                     connectionString: connectionString,
                     tableName: "LogPerformance",
                     autoCreateSqlTable: true,
                     columnOptions: GetPerfSqlColumnOptions()))
           .WriteTo.Logger(lc => lc
                 .Filter.ByIncludingOnly(Matching.WithProperty("UsageName"))
                 .WriteTo.MSSqlServer(
                     connectionString: connectionString,
                     tableName: "LogUsage",
                     autoCreateSqlTable: true,
                     columnOptions: GetUsageSqlColumnOptions()));
        }

        private static ColumnOptions GetUsageSqlColumnOptions()
        {
            var options = new ColumnOptions();
            return options;
        }

        private static ColumnOptions GetPerfSqlColumnOptions()
        {
            var options = new ColumnOptions();
            options.Store.Remove(StandardColumn.Message);
            options.Store.Remove(StandardColumn.MessageTemplate);
            options.Store.Remove(StandardColumn.Level);
            options.Store.Remove(StandardColumn.Exception);

            options.Store.Remove(StandardColumn.Properties);
            options.Store.Add(StandardColumn.LogEvent);
            options.LogEvent.ExcludeStandardColumns = true;
            options.LogEvent.ExcludeAdditionalProperties = true;

            options.AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn
                { ColumnName = "PerfItem", AllowNull = false,
                    DataType = SqlDbType.NVarChar, DataLength = 100,
                    NonClusteredIndex = true },
                new SqlColumn
                {
                    ColumnName = "ElapsedMilliseconds", AllowNull = false,
                    DataType = SqlDbType.Int
                },
                new SqlColumn
                {
                    ColumnName = "ActionName", AllowNull = false
                },
                new SqlColumn
                {
                    ColumnName = "MachineName", AllowNull = false
                }
            };

            return options;
        }

        private static UserInfo AddCustomContextDetails(IHttpContextAccessor ctx)
        {
            var excluded = new List<string> { "nbf", "exp", "auth_time", "amr", "sub" };
            const string userIdClaimType = "sub";

            var context = ctx.HttpContext;
            var user = context?.User.Identity;
            if (user == null || !user.IsAuthenticated) return null;

            var userId = context.User.Claims.FirstOrDefault(a => a.Type == userIdClaimType)?.Value;
            var userInfo = new UserInfo
            {
                UserName = user.Name,
                UserId = userId,
                UserClaims = new Dictionary<string, List<string>>()
            };
            foreach (var distinctClaimType in context.User.Claims
                .Where(a => excluded.All(ex => ex != a.Type))
                .Select(a => a.Type)
                .Distinct())
            {
                userInfo.UserClaims[distinctClaimType] = context.User.Claims
                    .Where(a => a.Type == distinctClaimType)
                    .Select(c => c.Value)
                    .ToList();
            }

            return userInfo;
        }
    }
}
