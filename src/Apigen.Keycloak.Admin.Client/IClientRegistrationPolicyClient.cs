using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Client Registration Policy operations
/// </summary>
public interface IClientRegistrationPolicyClient
{
  /// <summary>
  /// Base path for retrieve providers with the configProperties properly filled
  /// Operation: GET /admin/realms/{realm}/client-registration-policy/providers
  /// </summary>
  Task<List<ComponentTypeRepresentation>> GetClientRegistrationPolicyAsync(string realm);

}
