using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Client Role Mappings operations
/// </summary>
public interface IClientRoleMappingsClient
{
  /// <summary>
  /// Get client-level role mappings for the user or group, and the app
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}
  /// </summary>
  Task<List<RoleRepresentation>> GetAsync(string realm, string groupId, string clientId);

  /// <summary>
  /// Add client-level roles to the user or group role mapping
  /// Operation: POST /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}
  /// </summary>
  Task PostClientRoleMappingsAsync(string realm, string groupId, string clientId);

  /// <summary>
  /// Delete client-level roles from user or group role mapping
  /// Operation: DELETE /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}
  /// </summary>
  Task DeleteAsync(string realm, string groupId, string clientId);

  /// <summary>
  /// Get available client-level roles that can be mapped to the user or group
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/available
  /// </summary>
  Task<List<RoleRepresentation>> GetClientRoleMappingsAsync(string realm, string groupId, string clientId);

  /// <summary>
  /// Get effective client-level role mappings This recurses any composite roles
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetClientRoleMappingsAsync(string realm, string groupId, string clientId, GetClientRoleMappingsRequest? request = null);

  /// <summary>
  /// Get client-level role mappings for the user or group, and the app
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsClientsAsync(string realm, string userId, string clientId);

  /// <summary>
  /// Add client-level roles to the user or group role mapping
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}
  /// </summary>
  Task PostAdminRealmsUsersRoleMappingsClientsAsync(string realm, string userId, string clientId);

  /// <summary>
  /// Delete client-level roles from user or group role mapping
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}
  /// </summary>
  Task DeleteAdminRealmsUsersRoleMappingsClientsAsync(string realm, string userId, string clientId);

  /// <summary>
  /// Get available client-level roles that can be mapped to the user or group
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/available
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsClientsAvailableAsync(string realm, string userId, string clientId);

  /// <summary>
  /// Get effective client-level role mappings This recurses any composite roles
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsClientsCompositeAsync(string realm, string userId, string clientId, GetClientRoleMappingsRequest? request = null);

}
