using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Workflows operations
/// </summary>
public partial interface IWorkflowsClient
{
  /// <summary>
  /// List workflows
  /// Operation: GET /admin/realms/{realm}/workflows
  /// </summary>
  Task<WorkflowRepresentation> GetWorkflowsAsync(string realm, GetWorkflowsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create workflow
  /// Operation: POST /admin/realms/{realm}/workflows
  /// </summary>
  Task PostWorkflowsAsync(string realm, Apigen.Keycloak.Admin.Models.WorkflowRepresentation workflowRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// List scheduled workflows for resource
  /// Operation: GET /admin/realms/{realm}/workflows/scheduled/{resource-id}
  /// </summary>
  Task<WorkflowRepresentation> GetAsync(string resourceId, string realm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get workflow
  /// Operation: GET /admin/realms/{realm}/workflows/{id}
  /// </summary>
  Task<WorkflowRepresentation> GetAsync(string realm, string id, GetWorkflowsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update workflow
  /// Operation: PUT /admin/realms/{realm}/workflows/{id}
  /// </summary>
  Task UpdateAsync(string realm, string id, Apigen.Keycloak.Admin.Models.WorkflowRepresentation workflowRepresentation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete workflow
  /// Operation: DELETE /admin/realms/{realm}/workflows/{id}
  /// </summary>
  Task DeleteAsync(string realm, string id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Activate workflow for resource
  /// Operation: POST /admin/realms/{realm}/workflows/{id}/activate/{type}/{resourceId}
  /// </summary>
  Task PostWorkflowsAsync(string resourceId, string type, string realm, string id, PostWorkflowsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deactivate workflow for resource
  /// Operation: POST /admin/realms/{realm}/workflows/{id}/deactivate/{type}/{resourceId}
  /// </summary>
  Task PostWorkflowsAsync(string resourceId, string type, string realm, string id, CancellationToken cancellationToken = default);

}
