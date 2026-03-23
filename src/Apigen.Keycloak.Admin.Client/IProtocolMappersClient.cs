using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Protocol Mappers operations
/// </summary>
public interface IProtocolMappersClient
{
  /// <summary>
  /// Create multiple mappers
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/add-models
  /// </summary>
  Task PostProtocolMappersAsync(string realm, string clientScopeId);

  /// <summary>
  /// Get mappers
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models
  /// </summary>
  Task<List<ProtocolMapperRepresentation>> GetProtocolMappersAsync(string realm, string clientScopeId);

  /// <summary>
  /// Create a mapper
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models
  /// </summary>
  Task PostProtocolMappersAsync(string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation);

  /// <summary>
  /// Get mapper by id
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  Task<ProtocolMapperRepresentation> GetAsync(string id, string realm, string clientScopeId);

  /// <summary>
  /// Update the mapper
  /// Operation: PUT /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  Task UpdateAsync(string id, string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation);

  /// <summary>
  /// Delete the mapper
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  Task DeleteAsync(string id, string realm, string clientScopeId);

  /// <summary>
  /// Get mappers by name for a specific protocol
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/protocol/{protocol}
  /// </summary>
  Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientScopesProtocolMappersProtocolAsync(string protocol, string realm, string clientScopeId);

  /// <summary>
  /// Create multiple mappers
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/add-models
  /// </summary>
  Task PostAdminRealmsClientTemplatesProtocolMappersAddModelsAsync(string realm, string clientScopeId);

  /// <summary>
  /// Get mappers
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models
  /// </summary>
  Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientTemplatesProtocolMappersModelsAsync(string realm, string clientScopeId);

  /// <summary>
  /// Create a mapper
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models
  /// </summary>
  Task PostAdminRealmsClientTemplatesProtocolMappersModelsAsync(string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation);

  /// <summary>
  /// Get mapper by id
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  Task<ProtocolMapperRepresentation> GetAdminRealmsClientTemplatesProtocolMappersModelsAsync(string id, string realm, string clientScopeId);

  /// <summary>
  /// Update the mapper
  /// Operation: PUT /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  Task PutAdminRealmsClientTemplatesProtocolMappersModelsAsync(string id, string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation);

  /// <summary>
  /// Delete the mapper
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  Task DeleteAdminRealmsClientTemplatesProtocolMappersModelsAsync(string id, string realm, string clientScopeId);

  /// <summary>
  /// Get mappers by name for a specific protocol
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/protocol/{protocol}
  /// </summary>
  Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientTemplatesProtocolMappersProtocolAsync(string protocol, string realm, string clientScopeId);

  /// <summary>
  /// Create multiple mappers
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/add-models
  /// </summary>
  Task PostAdminRealmsClientsProtocolMappersAddModelsAsync(string realm, string clientUuid);

  /// <summary>
  /// Get mappers
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models
  /// </summary>
  Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientsProtocolMappersModelsAsync(string realm, string clientUuid);

  /// <summary>
  /// Create a mapper
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models
  /// </summary>
  Task PostAdminRealmsClientsProtocolMappersModelsAsync(string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation);

  /// <summary>
  /// Get mapper by id
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}
  /// </summary>
  Task<ProtocolMapperRepresentation> GetAdminRealmsClientsProtocolMappersModelsAsync(string id, string realm, string clientUuid);

  /// <summary>
  /// Update the mapper
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}
  /// </summary>
  Task PutAdminRealmsClientsProtocolMappersModelsAsync(string id, string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation);

  /// <summary>
  /// Delete the mapper
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}
  /// </summary>
  Task DeleteAdminRealmsClientsProtocolMappersModelsAsync(string id, string realm, string clientUuid);

  /// <summary>
  /// Get mappers by name for a specific protocol
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/protocol/{protocol}
  /// </summary>
  Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientsProtocolMappersProtocolAsync(string protocol, string realm, string clientUuid);

}
