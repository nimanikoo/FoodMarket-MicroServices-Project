using IdentityServer4;
using IdentityServer4.Models;

namespace Restaurant.Services.Identity
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> { new ApiScope("restaurant", "Restaurant Server"),
            new ApiScope(name:"read" , displayName:"Read your Data"),
            new ApiScope(name:"write",displayName:"Write your Data"),
            new ApiScope(name:"delete", displayName:"Delete your Data")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
               new Client
               {
                   ClientId = "client",
                   ClientSecrets = {new Secret ("secretKeySecret".Sha256())},
                   AllowedGrantTypes = GrantTypes.ClientCredentials,
                   AllowedScopes = {"read","write","profile"}
               },
                 new Client
               {
                   ClientId = "restaurant",
                   ClientSecrets = {new Secret ("secretKeySecret".Sha256())},
                   AllowedGrantTypes = GrantTypes.Code,
                   RedirectUris = { "http://localhost:30267/signin-oidc" },
                   PostLogoutRedirectUris = {"http://localhost:30267/signout-callback-oidc"},
                   AllowedScopes = new List<string>
                   {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Email,
                       IdentityServerConstants.StandardScopes.Profile,
                       "restaurant"
                   }
               },

            };
    }
}