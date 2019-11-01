using MCB.Api.Configuration.Interfaces;
using MCB.Api.Interfaces.Configuration;
using Microsoft.Extensions.Options;

namespace MCB.Api.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {
        public IAuthConfiguration AuthConfiguration { get; set; }

        public IAppConfiguration AppConfiguration { get; set; }

        public RootConfiguration(IOptions<AuthConfiguration> authConfiguration, IOptions<AppConfiguration> appConfiguration)
        {
            AuthConfiguration = authConfiguration.Value;
            AppConfiguration = appConfiguration.Value;
        }
    }
}
