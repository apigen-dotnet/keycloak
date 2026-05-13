using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Authentication Management operations
/// </summary>
public partial interface IAuthenticationManagementClient
{
  /// <summary>
  /// Get authenticator providers Returns a stream of authenticator providers.
  /// Operation: GET /admin/realms/{realm}/authentication/authenticator-providers
  /// </summary>
  Task<JsonElement> GetAuthenticationManagementAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get client authenticator providers Returns a stream of client authenticator providers.
  /// Operation: GET /admin/realms/{realm}/authentication/client-authenticator-providers
  /// </summary>
  Task<JsonElement> GetAdminRealmsAuthenticationClientAuthenticatorProvidersAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create new authenticator configuration
  /// Operation: POST /admin/realms/{realm}/authentication/config
  /// </summary>
  Task PostAuthenticationManagementAsync(string realm, Apigen.Keycloak.Admin.Models.AuthenticatorConfigRepresentation authenticatorConfigRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get authenticator provider&apos;s configuration description
  /// Operation: GET /admin/realms/{realm}/authentication/config-description/{providerId}
  /// </summary>
  Task<AuthenticatorConfigInfoRepresentation> GetAsync(string providerId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get authenticator configuration
  /// Operation: GET /admin/realms/{realm}/authentication/config/{id}
  /// </summary>
  Task<AuthenticatorConfigRepresentation> GetAdminRealmsAuthenticationConfigAsync(string id, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update authenticator configuration
  /// Operation: PUT /admin/realms/{realm}/authentication/config/{id}
  /// </summary>
  Task UpdateAsync(string id, string realm, Apigen.Keycloak.Admin.Models.AuthenticatorConfigRepresentation authenticatorConfigRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete authenticator configuration
  /// Operation: DELETE /admin/realms/{realm}/authentication/config/{id}
  /// </summary>
  Task DeleteAsync(string id, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add new authentication execution
  /// Operation: POST /admin/realms/{realm}/authentication/executions
  /// </summary>
  Task PostAuthenticationManagementAsync(string realm, Apigen.Keycloak.Admin.Models.AuthenticationExecutionRepresentation authenticationExecutionRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get Single Execution
  /// Operation: GET /admin/realms/{realm}/authentication/executions/{executionId}
  /// </summary>
  Task<AuthenticationExecutionRepresentation> GetAdminRealmsAuthenticationExecutionsAsync(string executionId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete execution
  /// Operation: DELETE /admin/realms/{realm}/authentication/executions/{executionId}
  /// </summary>
  Task DeleteAdminRealmsAuthenticationExecutionsAsync(string executionId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update execution with new configuration
  /// Operation: POST /admin/realms/{realm}/authentication/executions/{executionId}/config
  /// </summary>
  Task PostAuthenticationManagementAsync(string executionId, string realm, Apigen.Keycloak.Admin.Models.AuthenticatorConfigRepresentation authenticatorConfigRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get execution&apos;s configuration
  /// Operation: GET /admin/realms/{realm}/authentication/executions/{executionId}/config/{id}
  /// </summary>
  Task<AuthenticatorConfigRepresentation> GetAsync(string executionId, string id, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Lower execution&apos;s priority
  /// Operation: POST /admin/realms/{realm}/authentication/executions/{executionId}/lower-priority
  /// </summary>
  Task PostAuthenticationManagementAsync(string executionId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Raise execution&apos;s priority
  /// Operation: POST /admin/realms/{realm}/authentication/executions/{executionId}/raise-priority
  /// </summary>
  Task PostAdminRealmsAuthenticationExecutionsRaisePriorityAsync(string executionId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get authentication flows Returns a stream of authentication flows.
  /// Operation: GET /admin/realms/{realm}/authentication/flows
  /// </summary>
  Task<List<AuthenticationFlowRepresentation>> GetAdminRealmsAuthenticationFlowsAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a new authentication flow
  /// Operation: POST /admin/realms/{realm}/authentication/flows
  /// </summary>
  Task PostAuthenticationManagementAsync(string realm, Apigen.Keycloak.Admin.Models.AuthenticationFlowRepresentation authenticationFlowRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Copy existing authentication flow under a new name The new name is given as &apos;newName&apos; attribute of the passed JSON object
  /// Operation: POST /admin/realms/{realm}/authentication/flows/{flowAlias}/copy
  /// </summary>
  Task PostAdminRealmsAuthenticationFlowsCopyAsync(string flowAlias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get authentication executions for a flow
  /// Operation: GET /admin/realms/{realm}/authentication/flows/{flowAlias}/executions
  /// </summary>
  Task<List<AuthenticationExecutionInfoRepresentation>> GetAuthenticationManagementAsync(string flowAlias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update authentication executions of a Flow
  /// Operation: PUT /admin/realms/{realm}/authentication/flows/{flowAlias}/executions
  /// </summary>
  Task PutAuthenticationManagementAsync(string flowAlias, string realm, Apigen.Keycloak.Admin.Models.AuthenticationExecutionInfoRepresentation authenticationExecutionInfoRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add new authentication execution to a flow
  /// Operation: POST /admin/realms/{realm}/authentication/flows/{flowAlias}/executions/execution
  /// </summary>
  Task PostAdminRealmsAuthenticationFlowsExecutionsExecutionAsync(string flowAlias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add new flow with new execution to existing flow
  /// Operation: POST /admin/realms/{realm}/authentication/flows/{flowAlias}/executions/flow
  /// </summary>
  Task PostAdminRealmsAuthenticationFlowsExecutionsFlowAsync(string flowAlias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get authentication flow for id
  /// Operation: GET /admin/realms/{realm}/authentication/flows/{id}
  /// </summary>
  Task<AuthenticationFlowRepresentation> GetAdminRealmsAuthenticationFlowsAsync(string id, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update an authentication flow
  /// Operation: PUT /admin/realms/{realm}/authentication/flows/{id}
  /// </summary>
  Task UpdateAsync(string id, string realm, Apigen.Keycloak.Admin.Models.AuthenticationFlowRepresentation authenticationFlowRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete an authentication flow
  /// Operation: DELETE /admin/realms/{realm}/authentication/flows/{id}
  /// </summary>
  Task DeleteAdminRealmsAuthenticationFlowsAsync(string id, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get form action providers Returns a stream of form action providers.
  /// Operation: GET /admin/realms/{realm}/authentication/form-action-providers
  /// </summary>
  Task<JsonElement> GetAdminRealmsAuthenticationFormActionProvidersAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get form providers Returns a stream of form providers.
  /// Operation: GET /admin/realms/{realm}/authentication/form-providers
  /// </summary>
  Task<JsonElement> GetAdminRealmsAuthenticationFormProvidersAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get configuration descriptions for all clients
  /// Operation: GET /admin/realms/{realm}/authentication/per-client-config-description
  /// </summary>
  Task<JsonElement> GetAdminRealmsAuthenticationPerClientConfigDescriptionAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Register a new required actions
  /// Operation: POST /admin/realms/{realm}/authentication/register-required-action
  /// </summary>
  Task PostAuthenticationManagementAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get required actions Returns a stream of required actions.
  /// Operation: GET /admin/realms/{realm}/authentication/required-actions
  /// </summary>
  Task<List<RequiredActionProviderRepresentation>> GetAdminRealmsAuthenticationRequiredActionsAsync(string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get required action for alias
  /// Operation: GET /admin/realms/{realm}/authentication/required-actions/{alias}
  /// </summary>
  Task<RequiredActionProviderRepresentation> GetAdminRealmsAuthenticationRequiredActionsAsync(string alias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update required action
  /// Operation: PUT /admin/realms/{realm}/authentication/required-actions/{alias}
  /// </summary>
  Task UpdateAsync(string alias, string realm, Apigen.Keycloak.Admin.Models.RequiredActionProviderRepresentation requiredActionProviderRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete required action
  /// Operation: DELETE /admin/realms/{realm}/authentication/required-actions/{alias}
  /// </summary>
  Task DeleteAdminRealmsAuthenticationRequiredActionsAsync(string alias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get RequiredAction configuration
  /// Operation: GET /admin/realms/{realm}/authentication/required-actions/{alias}/config
  /// </summary>
  Task<RequiredActionConfigRepresentation> GetAdminRealmsAuthenticationRequiredActionsConfigAsync(string alias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update RequiredAction configuration
  /// Operation: PUT /admin/realms/{realm}/authentication/required-actions/{alias}/config
  /// </summary>
  Task PutAuthenticationManagementAsync(string alias, string realm, Apigen.Keycloak.Admin.Models.RequiredActionConfigRepresentation requiredActionConfigRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete RequiredAction configuration
  /// Operation: DELETE /admin/realms/{realm}/authentication/required-actions/{alias}/config
  /// </summary>
  Task DeleteAuthenticationManagementAsync(string alias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get RequiredAction provider configuration description
  /// Operation: GET /admin/realms/{realm}/authentication/required-actions/{alias}/config-description
  /// </summary>
  Task<RequiredActionConfigInfoRepresentation> GetAdminRealmsAuthenticationRequiredActionsConfigDescriptionAsync(string alias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Lower required action&apos;s priority
  /// Operation: POST /admin/realms/{realm}/authentication/required-actions/{alias}/lower-priority
  /// </summary>
  Task PostAdminRealmsAuthenticationRequiredActionsLowerPriorityAsync(string alias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Raise required action&apos;s priority
  /// Operation: POST /admin/realms/{realm}/authentication/required-actions/{alias}/raise-priority
  /// </summary>
  Task PostAdminRealmsAuthenticationRequiredActionsRaisePriorityAsync(string alias, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get unregistered required actions Returns a stream of unregistered required actions.
  /// Operation: GET /admin/realms/{realm}/authentication/unregistered-required-actions
  /// </summary>
  Task<JsonElement> GetAdminRealmsAuthenticationUnregisteredRequiredActionsAsync(string realm, CancellationToken cancellationToken = default);

}
