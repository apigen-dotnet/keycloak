using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Client Initial Access operations
/// </summary>
public interface IClientInitialAccessClient
{
  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/clients-initial-access
  /// </summary>
  Task<List<ClientInitialAccessPresentation>> GetClientInitialAccessAsync(string realm);

  /// <summary>
  /// Create a new initial access token.
  /// Operation: POST /admin/realms/{realm}/clients-initial-access
  /// </summary>
  Task<ClientInitialAccessCreatePresentation> PostClientInitialAccessAsync(string realm, Apigen.Keycloak.Admin.Models.ClientInitialAccessCreatePresentation clientInitialAccessCreatePresentation);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/clients-initial-access/{id}
  /// </summary>
  Task DeleteAsync(string id, string realm);

}
