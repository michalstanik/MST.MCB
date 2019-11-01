using MCB.Api.Configuration;
using MCB.Api.Configuration.Constants;
using MCB.Api.Interfaces.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MCB.Api.Helpers
{
    public static class StartupHelpers
    {
        /// <summary>
        /// Configuration root configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureRootConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<AuthConfiguration>(configuration.GetSection(ConfigurationConsts.AuthConfigurationKey));
            services.Configure<AppConfiguration>(configuration.GetSection(ConfigurationConsts.AppConfigurationKey));
            services.TryAddSingleton<IRootConfiguration, RootConfiguration>();
            return services;
        }
    }
}
