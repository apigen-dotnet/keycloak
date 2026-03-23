using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Identity Providers operations
/// </summary>
public interface IIdentityProvidersClient
{
  /// <summary>
  /// Import identity provider from JSON body
  /// Operation: POST /admin/realms/{realm}/identity-provider/import-config
  /// </summary>
  Task<JsonElement> PostIdentityProvidersAsync(string realm);

  /// <summary>
  /// List identity providers
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances
  /// </summary>
  Task<List<IdentityProviderRepresentation>> GetIdentityProvidersAsync(string realm, GetIdentityProvidersRequest? request = null);

  /// <summary>
  /// Create a new identity provider
  /// Operation: POST /admin/realms/{realm}/identity-provider/instances
  /// </summary>
  Task PostIdentityProvidersAsync(string realm, Apigen.Keycloak.Admin.Models.IdentityProviderRepresentation identityProviderRepresentation);

  /// <summary>
  /// Get the identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}
  /// </summary>
  Task<IdentityProviderRepresentation> GetAsync(string realm, string alias);

  /// <summary>
  /// Update the identity provider
  /// Operation: PUT /admin/realms/{realm}/identity-provider/instances/{alias}
  /// </summary>
  Task UpdateAsync(string realm, string alias, Apigen.Keycloak.Admin.Models.IdentityProviderRepresentation identityProviderRepresentation);

  /// <summary>
  /// Delete the identity provider
  /// Operation: DELETE /admin/realms/{realm}/identity-provider/instances/{alias}
  /// </summary>
  Task DeleteAsync(string realm, string alias);

  /// <summary>
  /// Export public broker configuration for identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/export
  /// </summary>
  Task GetIdentityProvidersAsync(string realm, string alias, GetIdentityProvidersRequest? request = null);

  /// <summary>
  /// Return object stating whether client Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> GetIdentityProvidersAsync(string realm, string alias);

  /// <summary>
  /// Return object stating whether client Authorization permissions have been initialized or not and a reference
  /// Operation: PUT /admin/realms/{realm}/identity-provider/instances/{alias}/management/permissions
  /// </summary>
  Task<ManagementPermissionReference> PutIdentityProvidersAsync(string realm, string alias, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference);

  /// <summary>
  /// Get mapper types for identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/mapper-types
  /// </summary>
  Task<object> GetAdminRealmsIdentityProviderInstancesMapperTypesAsync(string realm, string alias);

  /// <summary>
  /// Get mappers for identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/mappers
  /// </summary>
  Task<List<IdentityProviderMapperRepresentation>> GetAdminRealmsIdentityProviderInstancesMappersAsync(string realm, string alias);

  /// <summary>
  /// Add a mapper to identity provider
  /// Operation: POST /admin/realms/{realm}/identity-provider/instances/{alias}/mappers
  /// </summary>
  Task PostIdentityProvidersAsync(string realm, string alias, Apigen.Keycloak.Admin.Models.IdentityProviderMapperRepresentation identityProviderMapperRepresentation);

  /// <summary>
  /// Get mapper by id for the identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/mappers/{id}
  /// </summary>
  Task<IdentityProviderMapperRepresentation> GetAsync(string id, string realm, string alias);

  /// <summary>
  /// Update a mapper for the identity provider
  /// Operation: PUT /admin/realms/{realm}/identity-provider/instances/{alias}/mappers/{id}
  /// </summary>
  Task UpdateAsync(string id, string realm, string alias, Apigen.Keycloak.Admin.Models.IdentityProviderMapperRepresentation identityProviderMapperRepresentation);

  /// <summary>
  /// Delete a mapper for the identity provider
  /// Operation: DELETE /admin/realms/{realm}/identity-provider/instances/{alias}/mappers/{id}
  /// </summary>
  Task DeleteAsync(string id, string realm, string alias);

  /// <summary>
  /// Reaload keys for the identity provider if the provider supports it, &quot;true&quot; is returned if reload was performed, &quot;false&quot; if not.
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/reload-keys
  /// </summary>
  Task<JsonElement> GetAdminRealmsIdentityProviderInstancesReloadKeysAsync(string realm, string alias);

  /// <summary>
  /// Get the identity provider factory for that provider id
  /// Operation: GET /admin/realms/{realm}/identity-provider/providers/{provider_id}
  /// </summary>
  Task<JsonElement> GetAdminRealmsIdentityProviderProvidersAsync(string providerId, string realm);

}
