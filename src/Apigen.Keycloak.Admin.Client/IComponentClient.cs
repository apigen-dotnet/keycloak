using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Component operations
/// </summary>
public interface IComponentClient
{
  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/components
  /// </summary>
  Task<List<ComponentRepresentation>> GetAsync(string realm, GetComponentRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /admin/realms/{realm}/components
  /// </summary>
  Task PostAsync(string realm, Apigen.Keycloak.Admin.Models.ComponentRepresentation componentRepresentation);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/components/{id}
  /// </summary>
  Task<ComponentRepresentation> GetAsync(string id, string realm);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/components/{id}
  /// </summary>
  Task UpdateAsync(string id, string realm, Apigen.Keycloak.Admin.Models.ComponentRepresentation componentRepresentation);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/components/{id}
  /// </summary>
  Task DeleteAsync(string id, string realm);

  /// <summary>
  /// List of subcomponent types that are available to configure for a particular parent component.
  /// Operation: GET /admin/realms/{realm}/components/{id}/sub-component-types
  /// </summary>
  Task<List<ComponentTypeRepresentation>> GetAsync(string id, string realm, GetComponentRequest? request = null);

}
