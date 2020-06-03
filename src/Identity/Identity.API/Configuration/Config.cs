using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity.API.Configuration
{
    //This configuration contains 3 things: 
    //a) Which are the API resources needs to be protected 
    //b) which are the clients and how they can get access tokens, meaning what flows they are allowed to use and last but not least 
    //c) what are the OpenID Connect scopes allowed. 
    public class Config
    {
        // Identity resources are data like user ID, name, or email address of a user
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        //api resources or protected resource requests that contain access tokens
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("TaskManagementAPI", "Task Management API")
            };
        }
        //Clients allowed to request for tokens
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "TaskManagement",
                    ClientName = "TaskManagement Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true, // Specifies whether a proof key is required for authorization code based token requests (defaults to false).
                    RequireClientSecret = false,
                    RedirectUris = { "http://localhost:4200" },
                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowedScopes = 
                    {
                        //Specifies the api scopes that the client is allowed to request. If empty, the client can't access any scope
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "TaskManagementAPI"
                    }
                }
                //We have also defined that this client is allowed to request the openid, profile OpenID Connect scopes plus the TaskManagementAPI for accessing the TaskManagement.API resources. 
                //Client will be hosted in http://localhost:4200. 
                //The AllowedGrantTypes property is where you define how clients get access to the protected resources. 
                //Intellisense shows that there are several options to pick.
            };
        }
    }
}