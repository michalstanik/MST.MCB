using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using MCB.Api.Helpers;
using MCB.Api.Interfaces.Configuration;
using MCB.Api.OperationFilters;
using MCB.Api.Services;
using MCB.Business.CoreHelper.UserInterfaces;
using MCB.Data;
using MCB.Data.Repositories;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MCB.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.ConfigureRootConfiguration(Configuration);
            var rootConfiguration = services.BuildServiceProvider().GetService<IRootConfiguration>();


            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = rootConfiguration.AuthConfiguration.STSAuthority;
                options.ApiName = rootConfiguration.AuthConfiguration.STSApiName;
            });

            services.AddMvc(setupAction =>
            {
                setupAction.Filters.Add(new AuthorizeFilter());

                setupAction.ReturnHttpNotAcceptable = true;

                var jsonOutputFormatter = setupAction.OutputFormatters.OfType<JsonOutputFormatter>().FirstOrDefault();

                if (jsonOutputFormatter != null)
                {
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.mcb.trip+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.mcb.tripfull+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.mcb.tripwithstops+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.mcb.tripwithstopsandusers+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.mcb.tripwithcountries+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.mcb.tripwithcountriesandstats+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.mcb.tripwithcountriesandworldheritages+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.mcb.countriesforUserWithAssessments+json");

                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.mcb.cintinentWithRegionsAndCountries+json");

                    if (jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
                    {
                        jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                    }
                }
            })
            .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore) //ignores self reference object 
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2); //validate api rules

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsHeadersAndMethods",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("MCBOpenAPISpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "MCB API",
                        Version = "1"
                    });

                setupAction.OperationFilter<TripOperationFilter>();

                setupAction.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    { 
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(rootConfiguration.AuthConfiguration.STSApiAuthorizeUrl, UriKind.Absolute),
                            Scopes = new Dictionary<string, string>
                            {
                                { rootConfiguration.AuthConfiguration.STSApiName,
                                  rootConfiguration.AuthConfiguration.STSApiDescription
                                },
                            }
                        }
                    }
                });

                //setupAction.OperationFilter<AuthorizeCheckOperationFilter>(); // Required to use access token
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                        },
                        new[] { rootConfiguration.AuthConfiguration.STSApiName }
                    }
                });
                //Use of reflection to cobime a XML document with assembly path
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentFullPath);

                setupAction.ResolveConflictingActions(apiDesscriptions =>
                {
                    return apiDesscriptions.First();
                });
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<MCBDictionarySeeder>();
            services.AddTransient<MCBDataSeeder>();
            services.AddTransient<MCBEnsureDB>();
            services.AddTransient<MCBReportingSeeder>();
            services.AddScoped<IGeoRepository, GeoRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            // register an IHttpContextAccessor so we can access the current HttpContext in services by injecting it
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<MCBContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("MCBConnectionString"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var confScope = app.ApplicationServices.CreateScope();
            var rootConfiguration = confScope.ServiceProvider.GetService<IRootConfiguration>();
        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable CORS
            app.UseCors("AllowAllOriginsHeadersAndMethods");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/MCBOpenAPISpecification/swagger.json", "MCB API");
                setupAction.RoutePrefix = "api";

                setupAction.OAuthClientId(rootConfiguration.AuthConfiguration.STSOAuthClientId);
            });

            app.UseAuthentication();

            app.UseMvc();
            app.UseStaticFiles();

            confScope.Dispose();

                // Seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var configuration = scope.ServiceProvider.GetService<IRootConfiguration>();
                    var recreateDbOption = configuration.AppConfiguration.RecreateDB;
                    var deleteData = configuration.AppConfiguration.DeleteData;

                    if(recreateDbOption)
                    {
                        var recreate = scope.ServiceProvider.GetService<MCBEnsureDB>();
                        recreate.EnsureCreated();
                    }

                    //1
                    var dictionarySeeder = scope.ServiceProvider.GetService<MCBDictionarySeeder>();
                    dictionarySeeder.Seed().Wait();

                    //2
                    var dataSeeder = scope.ServiceProvider.GetService<MCBDataSeeder>();
                    if (deleteData)
                    {
                        dataSeeder.DeleteData();
                    }
                    dataSeeder.Seed().Wait();

                //3
                    var reportingSeeder = scope.ServiceProvider.GetService<MCBReportingSeeder>();
                    reportingSeeder.GenerateReportingForRegionsAndContinents().Wait();
                }
            
        }
    }
}
