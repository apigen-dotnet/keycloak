using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Scope Mappings operations
/// </summary>
public interface IScopeMappingsClient
{
  /// <summary>
  /// Get all scope mappings for the client
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings
  /// </summary>
  Task<MappingsRepresentation> GetScopeMappingsAsync(string realm, string clientScopeId);

  /// <summary>
  /// Get the roles associated with a client&apos;s scope Returns roles for the client.
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  Task<List<RoleRepresentation>> GetAsync(string realm, string clientScopeId, string client);

  /// <summary>
  /// Add client-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  Task PostScopeMappingsAsync(string realm, string clientScopeId, string client);

  /// <summary>
  /// Remove client-level roles from the client&apos;s scope.
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  Task DeleteAsync(string realm, string clientScopeId, string client);

  /// <summary>
  /// The available client-level roles Returns the roles for the client that can be associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/available
  /// </summary>
  Task<List<RoleRepresentation>> GetScopeMappingsAsync(string realm, string clientScopeId, string client);

  /// <summary>
  /// Get effective client roles Returns the roles for the client that are associated with the client&apos;s scope.
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetScopeMappingsAsync(string realm, string clientScopeId, string client, GetScopeMappingsRequest? request = null);

  /// <summary>
  /// Get realm-level roles associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientScopesScopeMappingsRealmAsync(string realm, string clientScopeId);

  /// <summary>
  /// Add a set of realm-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm
  /// </summary>
  Task PostScopeMappingsAsync(string realm, string clientScopeId);

  /// <summary>
  /// Remove a set of realm-level roles from the client&apos;s scope
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm
  /// </summary>
  Task DeleteScopeMappingsAsync(string realm, string clientScopeId);

  /// <summary>
  /// Get realm-level roles that are available to attach to this client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/available
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientScopesScopeMappingsRealmAvailableAsync(string realm, string clientScopeId);

  /// <summary>
  /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetScopeMappingsAsync(string realm, string clientScopeId, GetScopeMappingsRequest? request = null);

  /// <summary>
  /// Get all scope mappings for the client
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings
  /// </summary>
  Task<MappingsRepresentation> GetAdminRealmsClientTemplatesScopeMappingsAsync(string realm, string clientScopeId);

  /// <summary>
  /// Get the roles associated with a client&apos;s scope Returns roles for the client.
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsClientsAsync(string realm, string clientScopeId, string client);

  /// <summary>
  /// Add client-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  Task PostAdminRealmsClientTemplatesScopeMappingsClientsAsync(string realm, string clientScopeId, string client);

  /// <summary>
  /// Remove client-level roles from the client&apos;s scope.
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  Task DeleteAdminRealmsClientTemplatesScopeMappingsClientsAsync(string realm, string clientScopeId, string client);

  /// <summary>
  /// The available client-level roles Returns the roles for the client that can be associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/available
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsClientsAvailableAsync(string realm, string clientScopeId, string client);

  /// <summary>
  /// Get effective client roles Returns the roles for the client that are associated with the client&apos;s scope.
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsClientsCompositeAsync(string realm, string clientScopeId, string client, GetScopeMappingsRequest? request = null);

  /// <summary>
  /// Get realm-level roles associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsRealmAsync(string realm, string clientScopeId);

  /// <summary>
  /// Add a set of realm-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm
  /// </summary>
  Task PostAdminRealmsClientTemplatesScopeMappingsRealmAsync(string realm, string clientScopeId);

  /// <summary>
  /// Remove a set of realm-level roles from the client&apos;s scope
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm
  /// </summary>
  Task DeleteAdminRealmsClientTemplatesScopeMappingsRealmAsync(string realm, string clientScopeId);

  /// <summary>
  /// Get realm-level roles that are available to attach to this client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/available
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsRealmAvailableAsync(string realm, string clientScopeId);

  /// <summary>
  /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsRealmCompositeAsync(string realm, string clientScopeId, GetScopeMappingsRequest? request = null);

  /// <summary>
  /// Get all scope mappings for the client
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings
  /// </summary>
  Task<MappingsRepresentation> GetAdminRealmsClientsScopeMappingsAsync(string realm, string clientUuid);

  /// <summary>
  /// Get the roles associated with a client&apos;s scope Returns roles for the client.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsClientsAsync(string realm, string clientUuid, string client);

  /// <summary>
  /// Add client-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}
  /// </summary>
  Task PostAdminRealmsClientsScopeMappingsClientsAsync(string realm, string clientUuid, string client);

  /// <summary>
  /// Remove client-level roles from the client&apos;s scope.
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}
  /// </summary>
  Task DeleteAdminRealmsClientsScopeMappingsClientsAsync(string realm, string clientUuid, string client);

  /// <summary>
  /// The available client-level roles Returns the roles for the client that can be associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/available
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsClientsAvailableAsync(string realm, string clientUuid, string client);

  /// <summary>
  /// Get effective client roles Returns the roles for the client that are associated with the client&apos;s scope.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsClientsCompositeAsync(string realm, string clientUuid, string client, GetScopeMappingsRequest? request = null);

  /// <summary>
  /// Get realm-level roles associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsRealmAsync(string realm, string clientUuid);

  /// <summary>
  /// Add a set of realm-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm
  /// </summary>
  Task PostAdminRealmsClientsScopeMappingsRealmAsync(string realm, string clientUuid);

  /// <summary>
  /// Remove a set of realm-level roles from the client&apos;s scope
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm
  /// </summary>
  Task DeleteAdminRealmsClientsScopeMappingsRealmAsync(string realm, string clientUuid);

  /// <summary>
  /// Get realm-level roles that are available to attach to this client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm/available
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsRealmAvailableAsync(string realm, string clientUuid);

  /// <summary>
  /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm/composite
  /// </summary>
  Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsRealmCompositeAsync(string realm, string clientUuid, GetScopeMappingsRequest? request = null);

}
