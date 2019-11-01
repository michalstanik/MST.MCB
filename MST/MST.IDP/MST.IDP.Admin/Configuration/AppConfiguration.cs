using MST.IDP.Admin.Configuration.Interfaces;

namespace MST.IDP.Admin.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public bool DropDB { get; set; }
    }
}
