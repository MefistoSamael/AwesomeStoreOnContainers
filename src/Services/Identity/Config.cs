using Duende.IdentityServer.Models;

namespace Identity
{
  public static class Config
  {
    public static IEnumerable<IdentityResource> IdentityResources =>
      new []
      {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource
        {
          Name = "role",
          UserClaims = new List<string> {"role"}
        }
      };

    public static IEnumerable<ApiScope> ApiScopes =>
      new []
      {
        new ApiScope("awesomeapi.read"),
        new ApiScope("awesomeapi.write"),
      };
    
    public static IEnumerable<ApiResource> ApiResources => new[]
    {
      new ApiResource("awesomeapi")
      {
        Scopes = new List<string> { "awesomeapi.read", "awesomeapi.write"},
        ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
        UserClaims = new List<string> {"role"}
      }
    };

    public static IEnumerable<Client> Clients =>
      new[]
      {
        new Client
        {
          ClientId = "client",
          ClientSecrets = {new Secret("secret".Sha256())},

          AllowedGrantTypes = GrantTypes.ClientCredentials,

          AllowedScopes = { "awesomeapi.read", "awesomeapi.write"},
        },
      };
  }
}