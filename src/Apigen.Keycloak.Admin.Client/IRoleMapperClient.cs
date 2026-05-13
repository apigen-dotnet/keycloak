using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Role Mapper operations
/// </summary>
public partial interface IRoleMapperClient
{
  /// <summary>
  /// Get role mappings
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings
  /// </summary>
  Task<MappingsRepresentation> GetRoleMapperAsync(string realm, string groupId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get realm-level role mappings
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/realm
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsGroupsRoleMappingsRealmAsync(string realm, string groupId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add realm-level role mappings to the user
  /// Operation: POST /admin/realms/{realm}/groups/{group-id}/role-mappings/realm
  /// </summary>
  Task PostRoleMapperAsync(string realm, string groupId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete realm-level role mappings
  /// Operation: DELETE /admin/realms/{realm}/groups/{group-id}/role-mappings/realm
  /// </summary>
  Task DeleteRoleMapperAsync(string realm, string groupId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get realm-level roles that can be mapped
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/realm/available
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsGroupsRoleMappingsRealmAvailableAsync(string realm, string groupId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get effective realm-level role mappings This will recurse all composite roles to get the result.
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/realm/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetRoleMapperAsync(string realm, string groupId, GetRoleMapperRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get role mappings
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings
  /// </summary>
  Task<MappingsRepresentation> GetAdminRealmsUsersRoleMappingsAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get realm-level role mappings
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/realm
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsRealmAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add realm-level role mappings to the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/role-mappings/realm
  /// </summary>
  Task PostAdminRealmsUsersRoleMappingsRealmAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete realm-level role mappings
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/role-mappings/realm
  /// </summary>
  Task DeleteAdminRealmsUsersRoleMappingsRealmAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get realm-level roles that can be mapped
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/realm/available
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsRealmAvailableAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get effective realm-level role mappings This will recurse all composite roles to get the result.
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/realm/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsRealmCompositeAsync(string realm, string userId, GetRoleMapperRequest? request = null, CancellationToken cancellationToken = default);

}
