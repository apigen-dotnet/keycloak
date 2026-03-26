using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Users operations
/// </summary>
public interface IUsersClient
{
  /// <summary>
  /// Get users Returns a stream of users, filtered according to query parameters.
  /// Operation: GET /admin/realms/{realm}/users
  /// </summary>
  Task<List<UserRepresentation>> GetUsersAsync(string realm, GetUsersRequest? request = null);

  /// <summary>
  /// Create a new user Username must be unique.
  /// Operation: POST /admin/realms/{realm}/users
  /// </summary>
  Task PostUsersAsync(string realm, Apigen.Keycloak.Admin.Models.UserRepresentation userRepresentation);

  /// <summary>
  /// Returns the number of users that match the given criteria.
  /// Operation: GET /admin/realms/{realm}/users/count
  /// </summary>
  Task<JsonElement> GetAdminRealmsUsersCountAsync(string realm, GetUsersRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/profile
  /// </summary>
  Task<UPConfig> GetUsersAsync(string realm);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/users/profile
  /// </summary>
  Task<UPConfig> PutUsersAsync(string realm, Apigen.Keycloak.Admin.Models.UPConfig upConfig);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/profile/metadata
  /// </summary>
  Task<UserProfileMetadata> GetAdminRealmsUsersProfileMetadataAsync(string realm);

  /// <summary>
  /// Get representation of the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}
  /// </summary>
  Task<UserRepresentation> GetAsync(string realm, string userId, GetUsersRequest? request = null);

  /// <summary>
  /// Update the user
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}
  /// </summary>
  Task UpdateAsync(string realm, string userId, Apigen.Keycloak.Admin.Models.UserRepresentation userRepresentation);

  /// <summary>
  /// Delete the user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}
  /// </summary>
  Task DeleteAsync(string realm, string userId);

  /// <summary>
  /// Return credential types, which are provided by the user storage where user is stored.
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/configured-user-storage-credential-types
  /// </summary>
  Task<JsonElement> GetUsersAsync(string realm, string userId);

  /// <summary>
  /// Get consents granted by the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/consents
  /// </summary>
  Task<JsonElement> GetAdminRealmsUsersConsentsAsync(string realm, string userId);

  /// <summary>
  /// Revoke consent and offline tokens for particular client from user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/consents/{client}
  /// </summary>
  Task DeleteAsync(string client, string realm, string userId);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/credentials
  /// </summary>
  Task<List<CredentialRepresentation>> GetAdminRealmsUsersCredentialsAsync(string realm, string userId);

  /// <summary>
  /// Remove a credential for a user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}
  /// </summary>
  Task DeleteAdminRealmsUsersCredentialsAsync(string credentialId, string realm, string userId);

  /// <summary>
  /// Move a credential to a position behind another credential
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}
  /// </summary>
  Task PostUsersAsync(string credentialId, string newPreviousCredentialId, string realm, string userId);

  /// <summary>
  /// Move a credential to a first position in the credentials list of the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}/moveToFirst
  /// </summary>
  Task PostUsersAsync(string credentialId, string realm, string userId);

  /// <summary>
  /// Update a credential label for a user
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}/userLabel
  /// </summary>
  Task PutUsersAsync(string credentialId, string realm, string userId);

  /// <summary>
  /// Disable all credentials for a user of a specific type
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/disable-credential-types
  /// </summary>
  Task PutUsersAsync(string realm, string userId);

  /// <summary>
  /// Send an email to the user with a link they can click to execute particular actions.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/execute-actions-email
  /// </summary>
  Task PutUsersAsync(string realm, string userId, PutUsersRequest? request = null);

  /// <summary>
  /// Get social logins associated with the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/federated-identity
  /// </summary>
  Task<List<FederatedIdentityRepresentation>> GetAdminRealmsUsersFederatedIdentityAsync(string realm, string userId);

  /// <summary>
  /// Add a social login provider to the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/federated-identity/{provider}
  /// </summary>
  Task PostUsersAsync(string provider, string realm, string userId, Apigen.Keycloak.Admin.Models.FederatedIdentityRepresentation federatedIdentityRepresentation);

  /// <summary>
  /// Remove a social login provider from user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/federated-identity/{provider}
  /// </summary>
  Task DeleteAdminRealmsUsersFederatedIdentityAsync(string provider, string realm, string userId);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/groups
  /// </summary>
  Task<List<GroupRepresentation>> GetUsersAsync(string realm, string userId, GetUsersRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/groups/count
  /// </summary>
  Task<JsonElement> GetAdminRealmsUsersGroupsCountAsync(string realm, string userId, GetUsersRequest? request = null);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/groups/{groupId}
  /// </summary>
  Task UpdateAsync(string groupId, string realm, string userId);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/groups/{groupId}
  /// </summary>
  Task DeleteAdminRealmsUsersGroupsAsync(string groupId, string realm, string userId);

  /// <summary>
  /// Impersonate the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/impersonation
  /// </summary>
  Task<JsonElement> PostUsersAsync(string realm, string userId);

  /// <summary>
  /// Remove all user sessions associated with the user Also send notification to all clients that have an admin URL to invalidate the sessions for the particular user.
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/logout
  /// </summary>
  Task PostAdminRealmsUsersLogoutAsync(string realm, string userId);

  /// <summary>
  /// Get offline sessions associated with the user and client
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/offline-sessions/{clientUuid}
  /// </summary>
  Task<List<UserSessionRepresentation>> GetAsync(string clientUuid, string realm, string userId);

  /// <summary>
  /// Set up a new password for the user.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/reset-password
  /// </summary>
  Task PutUsersAsync(string realm, string userId, Apigen.Keycloak.Admin.Models.CredentialRepresentation credentialRepresentation);

  /// <summary>
  /// Send an email to the user with a link they can click to reset their password.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/reset-password-email
  /// </summary>
  Task PutAdminRealmsUsersResetPasswordEmailAsync(string realm, string userId, PutUsersRequest? request = null);

  /// <summary>
  /// Send an email-verification email to the user An email contains a link the user can click to verify their email address.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/send-verify-email
  /// </summary>
  Task PutAdminRealmsUsersSendVerifyEmailAsync(string realm, string userId, PutUsersRequest? request = null);

  /// <summary>
  /// Get sessions associated with the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/sessions
  /// </summary>
  Task<List<UserSessionRepresentation>> GetAdminRealmsUsersSessionsAsync(string realm, string userId);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/unmanagedAttributes
  /// </summary>
  Task<JsonElement> GetAdminRealmsUsersUnmanagedAttributesAsync(string realm, string userId);

}
