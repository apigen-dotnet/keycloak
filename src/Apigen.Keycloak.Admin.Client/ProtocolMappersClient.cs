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
/// Client for Protocol Mappers operations
/// </summary>
public partial class ProtocolMappersClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ProtocolMappersClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Create multiple mappers
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/add-models
  /// </summary>
  public async Task PostProtocolMappersAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/add-models".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      HttpResponseMessage response = await _httpClient.PostAsync(url, null, cancellationToken);
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
  /// Get mappers
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetProtocolMappersAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models".BuildUrl(pathParams);

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
      List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<ProtocolMapperRepresentation>();
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
  /// Create a mapper
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models
  /// </summary>
  public async Task PostProtocolMappersAsync(string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Get mapper by id
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task<ProtocolMapperRepresentation> GetAsync(string id, string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
      ProtocolMapperRepresentation? result = JsonSerializer.Deserialize<ProtocolMapperRepresentation>(responseContent, JsonConfig.Default);
      return result ?? new ProtocolMapperRepresentation();
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
  /// Update the mapper
  /// Operation: PUT /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task UpdateAsync(string id, string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
      string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Delete the mapper
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task DeleteAsync(string id, string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
  /// Get mappers by name for a specific protocol
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/protocol/{protocol}
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientScopesProtocolMappersProtocolAsync(string protocol, string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["protocol"] = protocol,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/protocol/{protocol}".BuildUrl(pathParams);

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
      List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<ProtocolMapperRepresentation>();
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
  /// Create multiple mappers
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/add-models
  /// </summary>
  public async Task PostAdminRealmsClientTemplatesProtocolMappersAddModelsAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/add-models".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      HttpResponseMessage response = await _httpClient.PostAsync(url, null, cancellationToken);
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
  /// Get mappers
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientTemplatesProtocolMappersModelsAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models".BuildUrl(pathParams);

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
      List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<ProtocolMapperRepresentation>();
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
  /// Create a mapper
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models
  /// </summary>
  public async Task PostAdminRealmsClientTemplatesProtocolMappersModelsAsync(string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Get mapper by id
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task<ProtocolMapperRepresentation> GetAdminRealmsClientTemplatesProtocolMappersModelsAsync(string id, string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
      ProtocolMapperRepresentation? result = JsonSerializer.Deserialize<ProtocolMapperRepresentation>(responseContent, JsonConfig.Default);
      return result ?? new ProtocolMapperRepresentation();
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
  /// Update the mapper
  /// Operation: PUT /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task PutAdminRealmsClientTemplatesProtocolMappersModelsAsync(string id, string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
      string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Delete the mapper
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task DeleteAdminRealmsClientTemplatesProtocolMappersModelsAsync(string id, string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
  /// Get mappers by name for a specific protocol
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/protocol/{protocol}
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientTemplatesProtocolMappersProtocolAsync(string protocol, string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["protocol"] = protocol,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/protocol/{protocol}".BuildUrl(pathParams);

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
      List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<ProtocolMapperRepresentation>();
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
  /// Create multiple mappers
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/add-models
  /// </summary>
  public async Task PostAdminRealmsClientsProtocolMappersAddModelsAsync(string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/add-models".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      HttpResponseMessage response = await _httpClient.PostAsync(url, null, cancellationToken);
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
  /// Get mappers
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientsProtocolMappersModelsAsync(string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models".BuildUrl(pathParams);

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
      List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<ProtocolMapperRepresentation>();
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
  /// Create a mapper
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models
  /// </summary>
  public async Task PostAdminRealmsClientsProtocolMappersModelsAsync(string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Get mapper by id
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}
  /// </summary>
  public async Task<ProtocolMapperRepresentation> GetAdminRealmsClientsProtocolMappersModelsAsync(string id, string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
      ProtocolMapperRepresentation? result = JsonSerializer.Deserialize<ProtocolMapperRepresentation>(responseContent, JsonConfig.Default);
      return result ?? new ProtocolMapperRepresentation();
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
  /// Update the mapper
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}
  /// </summary>
  public async Task PutAdminRealmsClientsProtocolMappersModelsAsync(string id, string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
      string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Delete the mapper
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}
  /// </summary>
  public async Task DeleteAdminRealmsClientsProtocolMappersModelsAsync(string id, string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
  /// Get mappers by name for a specific protocol
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/protocol/{protocol}
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientsProtocolMappersProtocolAsync(string protocol, string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["protocol"] = protocol,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/protocol/{protocol}".BuildUrl(pathParams);

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
      List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<ProtocolMapperRepresentation>();
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
