using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Key operations
/// </summary>
public interface IKeyClient
{
  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/keys
  /// </summary>
  Task<KeysMetadataRepresentation> GetAsync(string realm);

}
