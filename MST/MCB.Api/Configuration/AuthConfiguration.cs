using MCB.Api.Configuration.Interfaces;
using System;

namespace MCB.Api.Configuration
{
    public class AuthConfiguration : IAuthConfiguration
    {
        public string STSAuthority { get; set; }
        public string STSApiName { get; set; }
        public Uri STSApiAuthorizeUrl { get; set; }
        public string STSOAuthClientId { get; set; }
        public string STSApiDescription { get; set; }
    }
}
