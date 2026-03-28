# Apigen.Keycloak.Admin

Generated C# client for the [Keycloak](https://www.keycloak.org/) Admin REST API.

## Installation

```bash
dotnet add package Apigen.Keycloak.Admin.Client
```

The `Apigen.Keycloak.Admin.Models` package is included as a dependency.

## Usage

```csharp
using System.Net.Http.Headers;
using Apigen.Keycloak.Admin.Client;
using Apigen.Keycloak.Admin.Models;

// Configure an HttpClient with Bearer token authentication
var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://your-keycloak-instance/admin/realms")
};
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", "your-access-token");

var client = new KeycloakAdminClient(httpClient);
```

> **Tip:** Keycloak uses OAuth2 for authentication. Use a library like
> [IdentityModel](https://www.nuget.org/packages/IdentityModel) to obtain
> an access token via client credentials, then pass it as a Bearer token.

## License

MIT
