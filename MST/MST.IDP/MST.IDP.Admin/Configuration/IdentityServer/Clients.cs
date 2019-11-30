using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using MST.IDP.Admin.Configuration.Interfaces;

namespace MST.IDP.Admin.Configuration.IdentityServer

{
    public class Clients
    {
        public static IEnumerable<Client> GetAdminClient(IAdminConfiguration adminConfiguration)
        {

            return new List<Client>
            {
                new Client
                {

                    ClientId =adminConfiguration.ClientId,
                    ClientName =adminConfiguration.ClientId,
                    ClientUri = adminConfiguration.IdentityAdminBaseUrl,

                    AllowedGrantTypes = GrantTypes.Hybrid,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret(adminConfiguration.ClientSecret.ToSha256())
                    },

                    RedirectUris = { $"{adminConfiguration.IdentityAdminBaseUrl}/signin-oidc"},
                    FrontChannelLogoutUri = $"{adminConfiguration.IdentityAdminBaseUrl}/signout-oidc",
                    PostLogoutRedirectUris = { $"{adminConfiguration.IdentityAdminBaseUrl}/signout-callback-oidc"},
                    AllowedCorsOrigins = { adminConfiguration.IdentityAdminBaseUrl },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles"
                    }
                },

                new Client
                {
                    ClientId = adminConfiguration.IdentityAdminApiSwaggerUIClientId,
                    ClientName = adminConfiguration.IdentityAdminApiSwaggerUIClientId,

                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = new List<string>
                    {
                        adminConfiguration.IdentityAdminApiSwaggerUIRedirectUrl
                    },
                    AllowedScopes =
                    {
                        adminConfiguration.IdentityAdminApiScope
                    },
                    AllowAccessTokensViaBrowser = true
                },
                 new Client
                 {
                    ClientId = "mcb_api_swagger",
                    ClientName = "Swagger UI for MCB",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 180,
                    RedirectUris =
                    {
                        "https://localhost:9001/api/oauth2-redirect.html"

                    },
                    AllowedScopes = new []
                    {
                        "tripwithmeapi"
                    }
                },
                new Client
                {
                    ClientName = "Trip With Me WebClient",
                    ClientId="tripwithmeclient",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 180,
                    RedirectUris =           { "https://localhost:4200/assets/oidc-login-redirect.html" },
                    PostLogoutRedirectUris = { "https://localhost:4200/?postLogout=true" },
                    AllowedCorsOrigins =     { "https://localhost:4200/" },
                    AllowedScopes = new []
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "tripwithmeapi"
                    }
                }
                ,
                new Client
                {
                    ClientName = "Trip With Me Mobile",
                    ClientId = "tripwithmemobile",
                    Description = "Used for All Xamarin Mobile Apps",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequireConsent = false,
                    RequirePkce = true,
                    RedirectUris =  { "https://localhost:4200/assets/oidc-login-redirect.html" },
                    AllowedScopes = new List<string>
                     {
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                         IdentityServerConstants.StandardScopes.OfflineAccess
                     },
                   AllowOfflineAccess = true,
                   AllowAccessTokensViaBrowser = true
                }
            };

        }
    }
}
