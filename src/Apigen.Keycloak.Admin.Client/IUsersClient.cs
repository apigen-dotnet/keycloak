using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Users operations
/// </summary>
public partial interface IUsersClient
{
  /// <summary>
  /// Get users Returns a stream of users, filtered according to query parameters.
  /// Operation: GET /admin/realms/{realm}/users
  /// </summary>
  Task<List<UserRepresentation>> GetUsersAsync(string realm, GetUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a new user Username must be unique.
  /// Operation: POST /admin/realms/{realm}/users
  /// </summary>
  Task PostUsersAsync(string realm, Apigen.Keycloak.Admin.Models.UserRepresentation userRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Returns the number of users that match the given criteria.
  /// Operation: GET /admin/realms/{realm}/users/count
  /// </summary>
  Task<JsonElement> GetAdminRealmsUsersCountAsync(string realm, GetUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/profile
  /// </summary>
  Task<UserProfileConfig> GetUsersAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/users/profile
  /// </summary>
  Task<UserProfileConfig> PutUsersAsync(string realm, Apigen.Keycloak.Admin.Models.UserProfileConfig userProfileConfig, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/profile/metadata
  /// </summary>
  Task<UserProfileMetadata> GetAdminRealmsUsersProfileMetadataAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get representation of the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}
  /// </summary>
  Task<UserRepresentation> GetAsync(string realm, string userId, GetUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update the user
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}
  /// </summary>
  Task UpdateAsync(string realm, string userId, Apigen.Keycloak.Admin.Models.UserRepresentation userRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete the user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}
  /// </summary>
  Task DeleteAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Return credential types, which are provided by the user storage where user is stored.
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/configured-user-storage-credential-types
  /// </summary>
  Task<JsonElement> GetUsersAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get consents granted by the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/consents
  /// </summary>
  Task<JsonElement> GetAdminRealmsUsersConsentsAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Revoke consent and offline tokens for particular client from user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/consents/{client}
  /// </summary>
  Task DeleteAsync(string client, string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/credentials
  /// </summary>
  Task<List<CredentialRepresentation>> GetAdminRealmsUsersCredentialsAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove a credential for a user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}
  /// </summary>
  Task DeleteAdminRealmsUsersCredentialsAsync(string credentialId, string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Move a credential to a position behind another credential
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}
  /// </summary>
  Task PostUsersAsync(string credentialId, string newPreviousCredentialId, string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Move a credential to a first position in the credentials list of the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}/moveToFirst
  /// </summary>
  Task PostUsersAsync(string credentialId, string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a credential label for a user
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}/userLabel
  /// </summary>
  Task PutUsersAsync(string credentialId, string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Disable all credentials for a user of a specific type
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/disable-credential-types
  /// </summary>
  Task PutUsersAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Send an email to the user with a link they can click to execute particular actions.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/execute-actions-email
  /// </summary>
  Task PutUsersAsync(string realm, string userId, PutUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get social logins associated with the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/federated-identity
  /// </summary>
  Task<List<FederatedIdentityRepresentation>> GetAdminRealmsUsersFederatedIdentityAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add a social login provider to the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/federated-identity/{provider}
  /// </summary>
  Task PostUsersAsync(string provider, string realm, string userId, Apigen.Keycloak.Admin.Models.FederatedIdentityRepresentation federatedIdentityRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove a social login provider from user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/federated-identity/{provider}
  /// </summary>
  Task DeleteAdminRealmsUsersFederatedIdentityAsync(string provider, string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/groups
  /// </summary>
  Task<List<GroupRepresentation>> GetUsersAsync(string realm, string userId, GetUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/groups/count
  /// </summary>
  Task<JsonElement> GetAdminRealmsUsersGroupsCountAsync(string realm, string userId, GetUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/groups/{groupId}
  /// </summary>
  Task UpdateAsync(string groupId, string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/groups/{groupId}
  /// </summary>
  Task DeleteAdminRealmsUsersGroupsAsync(string groupId, string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Impersonate the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/impersonation
  /// </summary>
  Task<JsonElement> PostUsersAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove all user sessions associated with the user Also send notification to all clients that have an admin URL to invalidate the sessions for the particular user.
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/logout
  /// </summary>
  Task PostAdminRealmsUsersLogoutAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get offline sessions associated with the user and client
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/offline-sessions/{clientUuid}
  /// </summary>
  Task<List<UserSessionRepresentation>> GetAsync(string clientUuid, string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Set up a new password for the user.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/reset-password
  /// </summary>
  Task PutUsersAsync(string realm, string userId, Apigen.Keycloak.Admin.Models.CredentialRepresentation credentialRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Send an email to the user with a link they can click to reset their password.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/reset-password-email
  /// </summary>
  Task PutAdminRealmsUsersResetPasswordEmailAsync(string realm, string userId, PutUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Send an email-verification email to the user An email contains a link the user can click to verify their email address.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/send-verify-email
  /// </summary>
  Task PutAdminRealmsUsersSendVerifyEmailAsync(string realm, string userId, PutUsersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get sessions associated with the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/sessions
  /// </summary>
  Task<List<UserSessionRepresentation>> GetAdminRealmsUsersSessionsAsync(string realm, string userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/unmanagedAttributes
  /// </summary>
  Task<JsonElement> GetAdminRealmsUsersUnmanagedAttributesAsync(string realm, string userId, CancellationToken cancellationToken = default);

}
