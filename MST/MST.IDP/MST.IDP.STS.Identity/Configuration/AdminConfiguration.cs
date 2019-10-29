using MST.IDP.STS.Identity.Configuration.Intefaces;

namespace MST.IDP.STS.Identity.Configuration
{
    public class AdminConfiguration : IAdminConfiguration
    {
        public string IdentityAdminBaseUrl { get; set; } = "http://localhost:9000";
    }
}