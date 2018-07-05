using IdentityServer4.Models;
using System.Collections.Generic;

namespace Web.IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("web.api", "Web API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret123".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "web.api" }
                }
            };
        }
    }
}
