using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace MST.IDP.Admin.Configuration.Identity
{
    public class Users
    {
        public const string AdminUserName = "admin";
        public const string AdminPassword = "Pa$$word123";
        public const string AdminEmail = "admin@example.com";

        public static List<TestUser> Get()
        {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "fec0a4d6-5830-4eb8-8024-272bd5d6d2bb",
                    Username = "Michal",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Michał"),
                        new Claim(JwtClaimTypes.Email, "michal@michal.com"),
                        new Claim("family_name", "Smith")
                    }
                },
                new TestUser {
                    SubjectId = "c3b7f625-c07f-4d7d-9be1-ddff8ff93b4d",
                    Username = "Aga",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Aga"),
                        new Claim(JwtClaimTypes.Email, "aga@aga.com"),
                        new Claim("family_name", "Smith"),
                    }
                },
            };
        }
    }


}
