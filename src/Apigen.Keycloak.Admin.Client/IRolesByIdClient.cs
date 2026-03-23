using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Roles (by ID) operations
/// </summary>
public interface IRolesByIdClient
{
  /// <summary>
  /// Get a specific role&apos;s representation
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}
  /// </summary>
  Task<RoleRepresentation> GetAsync(string roleId, string realm);

  /// <summary>
  /// Update the role
  /// Operation: PUT /admin/realms/{realm}/roles-by-id/{role-id}
  /// </summary>
  Task UpdateAsync(string roleId, string realm, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation);

  /// <summary>
  /// Delete the role
  /// Operation: DELETE /admin/realms/{realm}/roles-by-id/{role-id}
  /// </summary>
  Task DeleteAsync(string roleId, string realm);

  /// <summary>
  /// Get role&apos;s children Returns a set of role&apos;s children provided the role is a composite.
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}/composites
  /// </summary>
  Task<List<RoleRepresentation>> GetRolesByIdAsync(string roleId, string realm, GetRolesByIdRequest? request = null);

  /// <summary>
  /// Make the role a composite role by associating some child roles
  /// Operation: POST /admin/realms/{realm}/roles-by-id/{role-id}/composites
  /// </summary>
  Task PostRolesByIdAsync(string roleId, string realm);

  /// <summary>
  /// Remove a set of roles from the role&apos;s composite
  /// Operation: DELETE /admin/realms/{realm}/roles-by-id/{role-id}/composites
  /// </summary>
  Task DeleteRolesByIdAsync(string roleId, string realm);

  /// <summary>
  /// Get client-level roles for the client that are in the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}/composites/clients/{clientUuid}
  /// </summary>
  Task<List<RoleRepresentation>> GetAsync(string clientUuid, string roleId, string realm);

  /// <summary>
  /// Get realm-level roles that are in the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}/composites/realm
  /// </summary>
  Task<List<RoleRepresentation>> GetRolesByIdAsync(string roleId, string realm);

  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> GetAdminRealmsRolesByIdManagementPermissionsAsync(string roleId, string realm);

  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: PUT /admin/realms/{realm}/roles-by-id/{role-id}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> PutRolesByIdAsync(string roleId, string realm, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference);

}
