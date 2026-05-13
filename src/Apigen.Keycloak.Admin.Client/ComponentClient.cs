using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Client for Component operations
/// </summary>
public partial class ComponentClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ComponentClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/components
  /// </summary>
  public async Task<List<ComponentRepresentation>> GetAsync(string realm, GetComponentRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/components".BuildUrl(pathParams, request);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
      HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, errorBody, null);
        throw new ApiException(response.StatusCode, "GET", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      List<ComponentRepresentation>? result = JsonSerializer.Deserialize<List<ComponentRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<ComponentRepresentation>();
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "GET", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "GET", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "GET", url, ex);
      throw;
    }
  }


  /// <summary>
  /// 
  /// Operation: POST /admin/realms/{realm}/components
  /// </summary>
  public async Task PostAsync(string realm, Apigen.Keycloak.Admin.Models.ComponentRepresentation componentRepresentation, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/components".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      string json = JsonSerializer.Serialize(componentRepresentation, JsonConfig.Default);
      HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PostAsync(url, content, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, errorBody, null);
        throw new ApiException(response.StatusCode, "POST", url, errorBody, response.Headers, response.Content.Headers);
      }

    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "POST", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "POST", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "POST", url, ex);
      throw;
    }
  }


  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/components/{id}
  /// </summary>
  public async Task<ComponentRepresentation> GetAsync(string id, string realm, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/components/{id}".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
      HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, errorBody, null);
        throw new ApiException(response.StatusCode, "GET", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      ComponentRepresentation? result = JsonSerializer.Deserialize<ComponentRepresentation>(responseContent, JsonConfig.Default);
      return result ?? new ComponentRepresentation();
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "GET", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "GET", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "GET", url, ex);
      throw;
    }
  }


  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/components/{id}
  /// </summary>
  public async Task UpdateAsync(string id, string realm, Apigen.Keycloak.Admin.Models.ComponentRepresentation componentRepresentation, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/components/{id}".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
      string json = JsonSerializer.Serialize(componentRepresentation, JsonConfig.Default);
      HttpClientLog.LogTraceRequestBody(_logger, "PUT", "application/json", json);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PutAsync(url, content, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PUT", url, errorBody, null);
        throw new ApiException(response.StatusCode, "PUT", url, errorBody, response.Headers, response.Content.Headers);
      }

    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "PUT", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "PUT", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "PUT", url, ex);
      throw;
    }
  }


  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/components/{id}
  /// </summary>
  public async Task DeleteAsync(string id, string realm, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/components/{id}".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "DELETE", url);
      HttpResponseMessage response = await _httpClient.DeleteAsync(url, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "DELETE", url, errorBody, null);
        throw new ApiException(response.StatusCode, "DELETE", url, errorBody, response.Headers, response.Content.Headers);
      }

    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "DELETE", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "DELETE", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "DELETE", url, ex);
      throw;
    }
  }


  /// <summary>
  /// List of subcomponent types that are available to configure for a particular parent component.
  /// Operation: GET /admin/realms/{realm}/components/{id}/sub-component-types
  /// </summary>
  public async Task<List<ComponentTypeRepresentation>> GetAsync(string id, string realm, GetComponentRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/components/{id}/sub-component-types".BuildUrl(pathParams, request);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
      HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, errorBody, null);
        throw new ApiException(response.StatusCode, "GET", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      List<ComponentTypeRepresentation>? result = JsonSerializer.Deserialize<List<ComponentTypeRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<ComponentTypeRepresentation>();
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "GET", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "GET", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "GET", url, ex);
      throw;
    }
  }


}
