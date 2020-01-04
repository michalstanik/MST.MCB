using Microsoft.Extensions.Options;
using MST.IDP.Admin.Configuration.Interfaces;

namespace MST.IDP.Admin.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {
        public IAdminConfiguration AdminConfiguration { get; set; }

        public IAppConfiguration AppConfiguration { get; set; }

        public RootConfiguration(IOptions<AdminConfiguration> adminConfiguration,
            IOptions<AppConfiguration> appConfiguration)
        {
            AdminConfiguration = adminConfiguration.Value;
            AppConfiguration = appConfiguration.Value;
        }
    }
}
