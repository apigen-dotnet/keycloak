using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Workflows operations
/// </summary>
public interface IWorkflowsClient
{
  /// <summary>
  /// List workflows
  /// Operation: GET /admin/realms/{realm}/workflows
  /// </summary>
  Task<WorkflowRepresentation> GetWorkflowsAsync(string realm, GetWorkflowsRequest? request = null);

  /// <summary>
  /// Create workflow
  /// Operation: POST /admin/realms/{realm}/workflows
  /// </summary>
  Task PostWorkflowsAsync(string realm, Apigen.Keycloak.Admin.Models.WorkflowRepresentation workflowRepresentation);

  /// <summary>
  /// List scheduled workflows for resource
  /// Operation: GET /admin/realms/{realm}/workflows/scheduled/{resource-id}
  /// </summary>
  Task<WorkflowRepresentation> GetAsync(string resourceId, string realm);

  /// <summary>
  /// Get workflow
  /// Operation: GET /admin/realms/{realm}/workflows/{id}
  /// </summary>
  Task<WorkflowRepresentation> GetAsync(string realm, string id, GetWorkflowsRequest? request = null);

  /// <summary>
  /// Update workflow
  /// Operation: PUT /admin/realms/{realm}/workflows/{id}
  /// </summary>
  Task UpdateAsync(string realm, string id, Apigen.Keycloak.Admin.Models.WorkflowRepresentation workflowRepresentation);

  /// <summary>
  /// Delete workflow
  /// Operation: DELETE /admin/realms/{realm}/workflows/{id}
  /// </summary>
  Task DeleteAsync(string realm, string id);

  /// <summary>
  /// Activate workflow for resource
  /// Operation: POST /admin/realms/{realm}/workflows/{id}/activate/{type}/{resourceId}
  /// </summary>
  Task PostWorkflowsAsync(string resourceId, string type, string realm, string id, PostWorkflowsRequest? request = null);

  /// <summary>
  /// Deactivate workflow for resource
  /// Operation: POST /admin/realms/{realm}/workflows/{id}/deactivate/{type}/{resourceId}
  /// </summary>
  Task PostWorkflowsAsync(string resourceId, string type, string realm, string id);

}
