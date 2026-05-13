using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Realms Admin operations
/// </summary>
public partial interface IRealmsAdminClient
{
  /// <summary>
  /// Get accessible realms Returns a list of accessible realms. The list is filtered based on what realms the caller is allowed to view.
  /// Operation: GET /admin/realms
  /// </summary>
  Task<List<RealmRepresentation>> GetRealmsAdminAsync(GetRealmsAdminRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Import a realm. Imports a realm from a full representation of that realm.
  /// Operation: POST /admin/realms
  /// </summary>
  Task PostRealmsAdminAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Get the top-level representation of the realm It will not include nested information like User and Client representations.
  /// Operation: GET /admin/realms/{realm}
  /// </summary>
  Task<RealmRepresentation> GetAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update the top-level information of the realm Any user, roles or client information in the representation will be ignored.
  /// Operation: PUT /admin/realms/{realm}
  /// </summary>
  Task UpdateAsync(string realm, Apigen.Keycloak.Admin.Models.RealmRepresentation realmRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete the realm
  /// Operation: DELETE /admin/realms/{realm}
  /// </summary>
  Task DeleteAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get admin events Returns all admin events, or filters events based on URL query parameters listed here
  /// Operation: GET /admin/realms/{realm}/admin-events
  /// </summary>
  Task<List<AdminEventRepresentation>> GetRealmsAdminAsync(string realm, GetRealmsAdminRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete all admin events
  /// Operation: DELETE /admin/realms/{realm}/admin-events
  /// </summary>
  Task DeleteRealmsAdminAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Base path for importing clients under this realm.
  /// Operation: POST /admin/realms/{realm}/client-description-converter
  /// </summary>
  Task<ClientRepresentation> PostRealmsAdminAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/client-policies/policies
  /// </summary>
  Task<ClientPoliciesRepresentation> GetAdminRealmsClientPoliciesPoliciesAsync(string realm, GetRealmsAdminRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/client-policies/policies
  /// </summary>
  Task PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.ClientPoliciesRepresentation clientPoliciesRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/client-policies/profiles
  /// </summary>
  Task<ClientProfilesRepresentation> GetAdminRealmsClientPoliciesProfilesAsync(string realm, GetRealmsAdminRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/client-policies/profiles
  /// </summary>
  Task PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.ClientProfilesRepresentation clientProfilesRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get client session stats Returns a JSON map.
  /// Operation: GET /admin/realms/{realm}/client-session-stats
  /// </summary>
  Task<JsonElement> GetRealmsAdminAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// List all client types available in the current realm
  /// Operation: GET /admin/realms/{realm}/client-types
  /// </summary>
  Task<ClientTypesRepresentation> GetAdminRealmsClientTypesAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a client type
  /// Operation: PUT /admin/realms/{realm}/client-types
  /// </summary>
  Task PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.ClientTypesRepresentation clientTypesRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/credential-registrators
  /// </summary>
  Task<JsonElement> GetAdminRealmsCredentialRegistratorsAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get realm default client scopes. Only name and ids are returned.
  /// Operation: GET /admin/realms/{realm}/default-default-client-scopes
  /// </summary>
  Task<List<ClientScopeRepresentation>> GetAdminRealmsDefaultDefaultClientScopesAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/default-default-client-scopes/{clientScopeId}
  /// </summary>
  Task UpdateAsync(string clientScopeId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/default-default-client-scopes/{clientScopeId}
  /// </summary>
  Task DeleteAsync(string clientScopeId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get group hierarchy.  Only name and ids are returned.
  /// Operation: GET /admin/realms/{realm}/default-groups
  /// </summary>
  Task<List<GroupRepresentation>> GetAdminRealmsDefaultGroupsAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/default-groups/{groupId}
  /// </summary>
  Task PutAdminRealmsDefaultGroupsAsync(string groupId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/default-groups/{groupId}
  /// </summary>
  Task DeleteAdminRealmsDefaultGroupsAsync(string groupId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get realm optional client scopes. Only name and ids are returned.
  /// Operation: GET /admin/realms/{realm}/default-optional-client-scopes
  /// </summary>
  Task<List<ClientScopeRepresentation>> GetAdminRealmsDefaultOptionalClientScopesAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/default-optional-client-scopes/{clientScopeId}
  /// </summary>
  Task PutAdminRealmsDefaultOptionalClientScopesAsync(string clientScopeId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/default-optional-client-scopes/{clientScopeId}
  /// </summary>
  Task DeleteAdminRealmsDefaultOptionalClientScopesAsync(string clientScopeId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get events Returns all events, or filters them based on URL query parameters listed here
  /// Operation: GET /admin/realms/{realm}/events
  /// </summary>
  Task<List<EventRepresentation>> GetAdminRealmsEventsAsync(string realm, GetRealmsAdminRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete all events
  /// Operation: DELETE /admin/realms/{realm}/events
  /// </summary>
  Task DeleteAdminRealmsEventsAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get the events provider configuration Returns JSON object with events provider configuration
  /// Operation: GET /admin/realms/{realm}/events/config
  /// </summary>
  Task<RealmEventsConfigRepresentation> GetAdminRealmsEventsConfigAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/events/config
  /// </summary>
  Task PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.RealmEventsConfigRepresentation realmEventsConfigRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/group-by-path/{path}
  /// </summary>
  Task<GroupRepresentation> GetAsync(string path, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/localization
  /// </summary>
  Task<JsonElement> GetAdminRealmsLocalizationAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/localization/{locale}
  /// </summary>
  Task<JsonElement> GetAsync(string locale, string realm, GetRealmsAdminRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Import localization from uploaded JSON file
  /// Operation: POST /admin/realms/{realm}/localization/{locale}
  /// </summary>
  Task PostRealmsAdminAsync(string locale, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/localization/{locale}
  /// </summary>
  Task DeleteAdminRealmsLocalizationAsync(string locale, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/localization/{locale}/{key}
  /// </summary>
  Task<object> GetAsync(string key, string locale, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/localization/{locale}/{key}
  /// </summary>
  Task UpdateAsync(string key, string locale, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/localization/{locale}/{key}
  /// </summary>
  Task DeleteAsync(string key, string locale, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Removes all user sessions.
  /// Operation: POST /admin/realms/{realm}/logout-all
  /// </summary>
  Task<GlobalRequestResult> PostAdminRealmsLogoutAllAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Partial export of existing realm into a JSON file.
  /// Operation: POST /admin/realms/{realm}/partial-export
  /// </summary>
  Task<RealmRepresentation> PostRealmsAdminAsync(string realm, PostRealmsAdminRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Partial import from a JSON file to an existing realm.
  /// Operation: POST /admin/realms/{realm}/partialImport
  /// </summary>
  Task<JsonElement> PostAdminRealmsPartialImportAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Push the realm&apos;s revocation policy to any client that has an admin url associated with it.
  /// Operation: POST /admin/realms/{realm}/push-revocation
  /// </summary>
  Task<GlobalRequestResult> PostAdminRealmsPushRevocationAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove a specific user session.
  /// Operation: DELETE /admin/realms/{realm}/sessions/{session}
  /// </summary>
  Task DeleteAsync(string session, string realm, DeleteRealmsAdminRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Test SMTP connection with current logged in user
  /// Operation: POST /admin/realms/{realm}/testSMTPConnection
  /// </summary>
  Task PostAdminRealmsTestSmtpConnectionAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users-management-permissions
  /// </summary>
  Task<ManagementPermissionReference> GetAdminRealmsUsersManagementPermissionsAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/users-management-permissions
  /// </summary>
  Task<ManagementPermissionReference> PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference, CancellationToken cancellationToken = default);

}
