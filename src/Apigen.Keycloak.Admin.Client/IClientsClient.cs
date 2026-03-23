using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Clients operations
/// </summary>
public interface IClientsClient
{
  /// <summary>
  /// Get clients belonging to the realm.
  /// Operation: GET /admin/realms/{realm}/clients
  /// </summary>
  Task<List<ClientRepresentation>> GetClientsAsync(string realm, GetClientsRequest? request = null);

  /// <summary>
  /// Create a new client Client’s client_id must be unique!
  /// Operation: POST /admin/realms/{realm}/clients
  /// </summary>
  Task PostClientsAsync(string realm, Apigen.Keycloak.Admin.Models.ClientRepresentationRequest clientRepresentation);

  /// <summary>
  /// Get representation of the client
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}
  /// </summary>
  Task<ClientRepresentation> GetAsync(string realm, string clientUuid);

  /// <summary>
  /// Update the client
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}
  /// </summary>
  Task UpdateAsync(string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ClientRepresentationRequest clientRepresentation);

  /// <summary>
  /// Delete the client
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}
  /// </summary>
  Task DeleteAsync(string realm, string clientUuid);

  /// <summary>
  /// Get the client secret
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/client-secret
  /// </summary>
  Task<CredentialRepresentation> GetClientsAsync(string realm, string clientUuid);

  /// <summary>
  /// Generate a new secret for the client
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/client-secret
  /// </summary>
  Task<CredentialRepresentation> PostClientsAsync(string realm, string clientUuid);

  /// <summary>
  /// Get the rotated client secret
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/client-secret/rotated
  /// </summary>
  Task<CredentialRepresentation> GetAdminRealmsClientsClientSecretRotatedAsync(string realm, string clientUuid);

  /// <summary>
  /// Invalidate the rotated secret for the client
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/client-secret/rotated
  /// </summary>
  Task DeleteClientsAsync(string realm, string clientUuid);

  /// <summary>
  /// Get default client scopes.  Only name and ids are returned.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/default-client-scopes
  /// </summary>
  Task<List<ClientScopeRepresentation>> GetAdminRealmsClientsDefaultClientScopesAsync(string realm, string clientUuid);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/default-client-scopes/{clientScopeId}
  /// </summary>
  Task UpdateAsync(string clientScopeId, string realm, string clientUuid);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/default-client-scopes/{clientScopeId}
  /// </summary>
  Task DeleteAsync(string clientScopeId, string realm, string clientUuid);

  /// <summary>
  /// Create JSON with payload of example access token
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/evaluate-scopes/generate-example-access-token
  /// </summary>
  Task<AccessToken> GetClientsAsync(string realm, string clientUuid, GetClientsRequest? request = null);

  /// <summary>
  /// Create JSON with payload of example id token
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/evaluate-scopes/generate-example-id-token
  /// </summary>
  Task<IdToken> GetAdminRealmsClientsEvaluateScopesGenerateExampleIdTokenAsync(string realm, string clientUuid, GetClientsRequest? request = null);

  /// <summary>
  /// Create JSON with payload of example user info
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/evaluate-scopes/generate-example-userinfo
  /// </summary>
  Task<JsonElement> GetAdminRealmsClientsEvaluateScopesGenerateExampleUserinfoAsync(string realm, string clientUuid, GetClientsRequest? request = null);

  /// <summary>
  /// Return list of all protocol mappers, which will be used when generating tokens issued for particular client.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/evaluate-scopes/protocol-mappers
  /// </summary>
  Task<List<ProtocolMapperEvaluationRepresentation>> GetAdminRealmsClientsEvaluateScopesProtocolMappersAsync(string realm, string clientUuid, GetClientsRequest? request = null);

  /// <summary>
  /// Get effective scope mapping of all roles of particular role container, which this client is defacto allowed to have in the accessToken issued for him.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/evaluate-scopes/scope-mappings/{roleContainerId}/granted
  /// </summary>
  Task<List<RoleRepresentation>> GetClientsAsync(string realm, string clientUuid, string roleContainerId, GetClientsRequest? request = null);

  /// <summary>
  /// Get roles, which this client doesn&apos;t have scope for and can&apos;t have them in the accessToken issued for him.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/evaluate-scopes/scope-mappings/{roleContainerId}/not-granted
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientsEvaluateScopesScopeMappingsNotGrantedAsync(string realm, string clientUuid, string roleContainerId, GetClientsRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/installation/providers/{providerId}
  /// </summary>
  Task GetAsync(string providerId, string realm, string clientUuid);

  /// <summary>
  /// Return object stating whether client Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> GetAdminRealmsClientsManagementPermissionsAsync(string realm, string clientUuid);

  /// <summary>
  /// Return object stating whether client Authorization permissions have been initialized or not and a reference
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> PutClientsAsync(string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference);

  /// <summary>
  /// Register a cluster node with the client Manually register cluster node to this client - usually it’s not needed to call this directly as adapter should handle by sending registration request to Keycloak
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/nodes
  /// </summary>
  Task PostAdminRealmsClientsNodesAsync(string realm, string clientUuid);

  /// <summary>
  /// Unregister a cluster node from the client
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/nodes/{node}
  /// </summary>
  Task DeleteAdminRealmsClientsNodesAsync(string node, string realm, string clientUuid);

  /// <summary>
  /// Get application offline session count Returns a number of offline user sessions associated with this client { &quot;count&quot;: number }
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/offline-session-count
  /// </summary>
  Task<JsonElement> GetAdminRealmsClientsOfflineSessionCountAsync(string realm, string clientUuid);

  /// <summary>
  /// Get offline sessions for client Returns a list of offline user sessions associated with this client
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/offline-sessions
  /// </summary>
  Task<List<UserSessionRepresentation>> GetAdminRealmsClientsOfflineSessionsAsync(string realm, string clientUuid, GetClientsRequest? request = null);

  /// <summary>
  /// Get optional client scopes.  Only name and ids are returned.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/optional-client-scopes
  /// </summary>
  Task<List<ClientScopeRepresentation>> GetAdminRealmsClientsOptionalClientScopesAsync(string realm, string clientUuid);

  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/optional-client-scopes/{clientScopeId}
  /// </summary>
  Task PutAdminRealmsClientsOptionalClientScopesAsync(string clientScopeId, string realm, string clientUuid);

  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/optional-client-scopes/{clientScopeId}
  /// </summary>
  Task DeleteAdminRealmsClientsOptionalClientScopesAsync(string clientScopeId, string realm, string clientUuid);

  /// <summary>
  /// Push the client&apos;s revocation policy to its admin URL If the client has an admin URL, push revocation policy to it.
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/push-revocation
  /// </summary>
  Task<GlobalRequestResult> PostAdminRealmsClientsPushRevocationAsync(string realm, string clientUuid);

  /// <summary>
  /// Generate a new registration access token for the client
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/registration-access-token
  /// </summary>
  Task<ClientRepresentation> PostAdminRealmsClientsRegistrationAccessTokenAsync(string realm, string clientUuid);

  /// <summary>
  /// Get a user dedicated to the service account
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/service-account-user
  /// </summary>
  Task<UserRepresentation> GetAdminRealmsClientsServiceAccountUserAsync(string realm, string clientUuid);

  /// <summary>
  /// Get application session count Returns a number of user sessions associated with this client { &quot;count&quot;: number }
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/session-count
  /// </summary>
  Task<JsonElement> GetAdminRealmsClientsSessionCountAsync(string realm, string clientUuid);

  /// <summary>
  /// Test if registered cluster nodes are available Tests availability by sending &apos;ping&apos; request to all cluster nodes.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/test-nodes-available
  /// </summary>
  Task<GlobalRequestResult> GetAdminRealmsClientsTestNodesAvailableAsync(string realm, string clientUuid);

  /// <summary>
  /// Get user sessions for client Returns a list of user sessions associated with this client
  /// 
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/user-sessions
  /// </summary>
  Task<List<UserSessionRepresentation>> GetAdminRealmsClientsUserSessionsAsync(string realm, string clientUuid, GetClientsRequest? request = null);

}
