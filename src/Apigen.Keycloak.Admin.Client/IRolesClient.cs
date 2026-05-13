using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Roles operations
/// </summary>
public partial interface IRolesClient
{
  /// <summary>
  /// Get all roles for the realm or client
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles
  /// </summary>
  Task<List<RoleRepresentation>> GetRolesAsync(string realm, string clientUuid, GetRolesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a new role for the realm or client
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/roles
  /// </summary>
  Task PostRolesAsync(string realm, string clientUuid, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a role by name
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}
  /// </summary>
  Task<RoleRepresentation> GetAsync(string roleName, string realm, string clientUuid, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a role by name
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}
  /// </summary>
  Task UpdateAsync(string roleName, string realm, string clientUuid, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a role by name
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}
  /// </summary>
  Task DeleteAsync(string roleName, string realm, string clientUuid, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get composites of the role
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites
  /// </summary>
  Task<List<RoleRepresentation>> GetRolesAsync(string roleName, string realm, string clientUuid, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add a composite to the role
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites
  /// </summary>
  Task PostRolesAsync(string roleName, string realm, string clientUuid, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove roles from the role&apos;s composite
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites
  /// </summary>
  Task DeleteRolesAsync(string roleName, string realm, string clientUuid, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get client-level roles for the client that are in the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites/clients/{client-uuid}
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientsRolesCompositesClientsAsync(string clientUuid, string roleName, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get realm-level roles of the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites/realm
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientsRolesCompositesRealmAsync(string roleName, string realm, string clientUuid, CancellationToken cancellationToken = default);

  /// <summary>
  /// Returns a stream of groups that have the specified role name
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/groups
  /// </summary>
  Task<List<UserRepresentation>> GetRolesAsync(string roleName, string realm, string clientUuid, GetRolesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> GetAdminRealmsClientsRolesManagementPermissionsAsync(string roleName, string realm, string clientUuid, CancellationToken cancellationToken = default);

  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> PutRolesAsync(string roleName, string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference, CancellationToken cancellationToken = default);

  /// <summary>
  /// Returns a stream of users that have the specified role name.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/users
  /// </summary>
  Task<List<UserRepresentation>> GetAdminRealmsClientsRolesUsersAsync(string roleName, string realm, string clientUuid, GetRolesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all roles for the realm or client
  /// Operation: GET /admin/realms/{realm}/roles
  /// </summary>
  Task<List<RoleRepresentation>> GetRolesAsync(string realm, GetRolesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a new role for the realm or client
  /// Operation: POST /admin/realms/{realm}/roles
  /// </summary>
  Task PostRolesAsync(string realm, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a role by name
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}
  /// </summary>
  Task<RoleRepresentation> GetAsync(string roleName, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a role by name
  /// Operation: PUT /admin/realms/{realm}/roles/{role-name}
  /// </summary>
  Task UpdateAsync(string roleName, string realm, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a role by name
  /// Operation: DELETE /admin/realms/{realm}/roles/{role-name}
  /// </summary>
  Task DeleteAsync(string roleName, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get composites of the role
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/composites
  /// </summary>
  Task<List<RoleRepresentation>> GetRolesAsync(string roleName, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add a composite to the role
  /// Operation: POST /admin/realms/{realm}/roles/{role-name}/composites
  /// </summary>
  Task PostRolesAsync(string roleName, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove roles from the role&apos;s composite
  /// Operation: DELETE /admin/realms/{realm}/roles/{role-name}/composites
  /// </summary>
  Task DeleteRolesAsync(string roleName, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get client-level roles for the client that are in the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/composites/clients/{client-uuid}
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsRolesCompositesClientsAsync(string clientUuid, string roleName, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get realm-level roles of the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/composites/realm
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsRolesCompositesRealmAsync(string roleName, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Returns a stream of groups that have the specified role name
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/groups
  /// </summary>
  Task<List<UserRepresentation>> GetAdminRealmsRolesGroupsAsync(string roleName, string realm, GetRolesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> GetAdminRealmsRolesManagementPermissionsAsync(string roleName, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: PUT /admin/realms/{realm}/roles/{role-name}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> PutRolesAsync(string roleName, string realm, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference, CancellationToken cancellationToken = default);

  /// <summary>
  /// Returns a stream of users that have the specified role name.
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/users
  /// </summary>
  Task<List<UserRepresentation>> GetAdminRealmsRolesUsersAsync(string roleName, string realm, GetRolesRequest? request = null, CancellationToken cancellationToken = default);

}
