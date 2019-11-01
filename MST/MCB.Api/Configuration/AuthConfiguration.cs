using MCB.Api.Configuration.Interfaces;

namespace MCB.Api.Configuration
{
    public class AuthConfiguration : IAuthConfiguration
    {
        public string STSAuthority { get; set; }
        public string STSApiName { get; set; }
        public string STSApiAuthorizeUrl { get; set; }
        public string STSOAuthClientId { get; set; }
        public string STSApiDescription { get; set; }
    }
}
