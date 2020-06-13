using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity.Configuration
{
    public class Config
    {
        //identity resources: represent claims about a user like user ID, display name, email address etc
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
        //Client allowed to request for tokens
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "task",
                    ClientName = "Task Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    //Client allowed to receive token
                    RedirectUris =
                    {
                        "https://localhost:4200/signin-oidc"
                    },
                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }
         public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("SocialAPI", "Social Network API")
            };
        }
    }
}
