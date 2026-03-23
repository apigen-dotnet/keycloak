using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Groups operations
/// </summary>
public interface IGroupsClient
{
  /// <summary>
  /// Get group hierarchy.  Only `name` and `id` are returned.  `subGroups` are only returned when using the `search` or `q` parameter. If none of these parameters is provided, the top-level groups are returned without `subGroups` being filled.
  /// Operation: GET /admin/realms/{realm}/groups
  /// </summary>
  Task<List<GroupRepresentation>> GetGroupsAsync(string realm, GetGroupsRequest? request = null);

  /// <summary>
  /// create or add a top level realm groupSet or create child.
  /// Operation: POST /admin/realms/{realm}/groups
  /// </summary>
  Task PostGroupsAsync(string realm, Apigen.Keycloak.Admin.Models.GroupRepresentation groupRepresentation);

  /// <summary>
  /// Returns the groups counts.
  /// Operation: GET /admin/realms/{realm}/groups/count
  /// </summary>
  Task<JsonElement> GetAdminRealmsGroupsCountAsync(string realm, GetGroupsRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}
  /// </summary>
  Task<GroupRepresentation> GetAsync(string realm, string groupId);

  /// <summary>
  /// Update group, ignores subgroups.
  /// Operation: PUT /admin/realms/{realm}/groups/{group-id}
  /// </summary>
  Task UpdateAsync(string realm, string groupId, Apigen.Keycloak.Admin.Models.GroupRepresentation groupRepresentation);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/groups/{group-id}
  /// </summary>
  Task DeleteAsync(string realm, string groupId);

  /// <summary>
  /// Return a paginated list of subgroups that have a parent group corresponding to the group on the URL
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/children
  /// </summary>
  Task<List<GroupRepresentation>> GetGroupsAsync(string realm, string groupId, GetGroupsRequest? request = null);

  /// <summary>
  /// Set or create child.
  /// Operation: POST /admin/realms/{realm}/groups/{group-id}/children
  /// </summary>
  Task PostGroupsAsync(string realm, string groupId, Apigen.Keycloak.Admin.Models.GroupRepresentation groupRepresentation);

  /// <summary>
  /// Return object stating whether client Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> GetGroupsAsync(string realm, string groupId);

  /// <summary>
  /// Return object stating whether client Authorization permissions have been initialized or not and a reference
  /// Operation: PUT /admin/realms/{realm}/groups/{group-id}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> PutGroupsAsync(string realm, string groupId, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference);

  /// <summary>
  /// Get users Returns a stream of users, filtered according to query parameters
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/members
  /// </summary>
  Task<List<UserRepresentation>> GetAdminRealmsGroupsMembersAsync(string realm, string groupId, GetGroupsRequest? request = null);

}
