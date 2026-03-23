using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Client Scopes operations
/// </summary>
public interface IClientScopesClient
{
  /// <summary>
  /// Get client scopes belonging to the realm Returns a list of client scopes belonging to the realm
  /// Operation: GET /admin/realms/{realm}/client-scopes
  /// </summary>
  Task<List<ClientScopeRepresentation>> GetClientScopesAsync(string realm);

  /// <summary>
  /// Create a new client scope Client Scope’s name must be unique!
  /// Operation: POST /admin/realms/{realm}/client-scopes
  /// </summary>
  Task PostClientScopesAsync(string realm, Apigen.Keycloak.Admin.Models.ClientScopeRepresentation clientScopeRepresentation);

  /// <summary>
  /// Get representation of the client scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}
  /// </summary>
  Task<ClientScopeRepresentation> GetAsync(string realm, string clientScopeId);

  /// <summary>
  /// Update the client scope
  /// Operation: PUT /admin/realms/{realm}/client-scopes/{client-scope-id}
  /// </summary>
  Task UpdateAsync(string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ClientScopeRepresentation clientScopeRepresentation);

  /// <summary>
  /// Delete the client scope
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}
  /// </summary>
  Task DeleteAsync(string realm, string clientScopeId);

  /// <summary>
  /// Get client scopes belonging to the realm Returns a list of client scopes belonging to the realm
  /// Operation: GET /admin/realms/{realm}/client-templates
  /// </summary>
  Task<List<ClientScopeRepresentation>> GetAdminRealmsClientTemplatesAsync(string realm);

  /// <summary>
  /// Create a new client scope Client Scope’s name must be unique!
  /// Operation: POST /admin/realms/{realm}/client-templates
  /// </summary>
  Task PostAdminRealmsClientTemplatesAsync(string realm, Apigen.Keycloak.Admin.Models.ClientScopeRepresentation clientScopeRepresentation);

  /// <summary>
  /// Get representation of the client scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}
  /// </summary>
  Task<ClientScopeRepresentation> GetAdminRealmsClientTemplatesAsync(string realm, string clientScopeId);

  /// <summary>
  /// Update the client scope
  /// Operation: PUT /admin/realms/{realm}/client-templates/{client-scope-id}
  /// </summary>
  Task PutAdminRealmsClientTemplatesAsync(string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ClientScopeRepresentation clientScopeRepresentation);

  /// <summary>
  /// Delete the client scope
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}
  /// </summary>
  Task DeleteAdminRealmsClientTemplatesAsync(string realm, string clientScopeId);

}
