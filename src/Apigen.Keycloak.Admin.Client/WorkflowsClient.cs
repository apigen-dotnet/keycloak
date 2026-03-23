using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Client for Workflows operations
/// </summary>
public class WorkflowsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal WorkflowsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// List workflows
  /// Operation: GET /admin/realms/{realm}/workflows
  /// </summary>
  public async Task<WorkflowRepresentation> GetWorkflowsAsync(string realm, GetWorkflowsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/workflows".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    WorkflowRepresentation? result = JsonSerializer.Deserialize<WorkflowRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new WorkflowRepresentation();
  }


  /// <summary>
  /// Create workflow
  /// Operation: POST /admin/realms/{realm}/workflows
  /// </summary>
  public async Task PostWorkflowsAsync(string realm, Apigen.Keycloak.Admin.Models.WorkflowRepresentationRequest workflowRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/workflows".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(workflowRepresentation, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// List scheduled workflows for resource
  /// Operation: GET /admin/realms/{realm}/workflows/scheduled/{resource-id}
  /// </summary>
  public async Task<WorkflowRepresentation> GetAsync(string resourceId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["resource-id"] = resourceId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/workflows/scheduled/{resource-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    WorkflowRepresentation? result = JsonSerializer.Deserialize<WorkflowRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new WorkflowRepresentation();
  }


  /// <summary>
  /// Get workflow
  /// Operation: GET /admin/realms/{realm}/workflows/{id}
  /// </summary>
  public async Task<WorkflowRepresentation> GetAsync(string realm, string id, GetWorkflowsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["id"] = id
    };
    string url = "realms/{realm}/workflows/{id}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    WorkflowRepresentation? result = JsonSerializer.Deserialize<WorkflowRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new WorkflowRepresentation();
  }


  /// <summary>
  /// Update workflow
  /// Operation: PUT /admin/realms/{realm}/workflows/{id}
  /// </summary>
  public async Task UpdateAsync(string realm, string id, Apigen.Keycloak.Admin.Models.WorkflowRepresentationRequest workflowRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["id"] = id
    };
    string url = "realms/{realm}/workflows/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(workflowRepresentation, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "PUT", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Delete workflow
  /// Operation: DELETE /admin/realms/{realm}/workflows/{id}
  /// </summary>
  public async Task DeleteAsync(string realm, string id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["id"] = id
    };
    string url = "realms/{realm}/workflows/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Activate workflow for resource
  /// Operation: POST /admin/realms/{realm}/workflows/{id}/activate/{type}/{resourceId}
  /// </summary>
  public async Task PostWorkflowsAsync(string resourceId, string type, string realm, string id, PostWorkflowsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["resourceId"] = resourceId,
      ["type"] = type,
      ["realm"] = realm,
      ["id"] = id
    };
    string url = "realms/{realm}/workflows/{id}/activate/{type}/{resourceId}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Deactivate workflow for resource
  /// Operation: POST /admin/realms/{realm}/workflows/{id}/deactivate/{type}/{resourceId}
  /// </summary>
  public async Task PostWorkflowsAsync(string resourceId, string type, string realm, string id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["resourceId"] = resourceId,
      ["type"] = type,
      ["realm"] = realm,
      ["id"] = id
    };
    string url = "realms/{realm}/workflows/{id}/deactivate/{type}/{resourceId}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }
  }


}
