using MCB.Api.Configuration.Interfaces;
using MCB.Api.Interfaces.Configuration;
using Microsoft.Extensions.Options;

namespace MCB.Api.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {
        public IAuthConfiguration AuthConfiguration { get; set; }

        public RootConfiguration(IOptions<AuthConfiguration> authConfiguration)
        {
            AuthConfiguration = authConfiguration.Value;
        }
    }
}
