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
/// Client for Scope Mappings operations
/// </summary>
public partial class ScopeMappingsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ScopeMappingsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all scope mappings for the client
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings
  /// </summary>
  public async Task<MappingsRepresentation> GetScopeMappingsAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings".BuildUrl(pathParams);

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
      MappingsRepresentation? result = JsonSerializer.Deserialize<MappingsRepresentation>(responseContent, JsonConfig.Default);
      return result ?? new MappingsRepresentation();
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
  /// Get the roles associated with a client&apos;s scope Returns roles for the client.
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAsync(string realm, string clientScopeId, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Add client-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task PostScopeMappingsAsync(string realm, string clientScopeId, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// Remove client-level roles from the client&apos;s scope.
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task DeleteAsync(string realm, string clientScopeId, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// The available client-level roles Returns the roles for the client that can be associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetScopeMappingsAsync(string realm, string clientScopeId, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/available".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get effective client roles Returns the roles for the client that are associated with the client&apos;s scope.
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetScopeMappingsAsync(string realm, string clientScopeId, string client, GetScopeMappingsRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/composite".BuildUrl(pathParams, request);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get realm-level roles associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientScopesScopeMappingsRealmAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Add a set of realm-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task PostScopeMappingsAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Remove a set of realm-level roles from the client&apos;s scope
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task DeleteScopeMappingsAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Get realm-level roles that are available to attach to this client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientScopesScopeMappingsRealmAvailableAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/available".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetScopeMappingsAsync(string realm, string clientScopeId, GetScopeMappingsRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/composite".BuildUrl(pathParams, request);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get all scope mappings for the client
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings
  /// </summary>
  public async Task<MappingsRepresentation> GetAdminRealmsClientTemplatesScopeMappingsAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings".BuildUrl(pathParams);

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
      MappingsRepresentation? result = JsonSerializer.Deserialize<MappingsRepresentation>(responseContent, JsonConfig.Default);
      return result ?? new MappingsRepresentation();
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
  /// Get the roles associated with a client&apos;s scope Returns roles for the client.
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsClientsAsync(string realm, string clientScopeId, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Add client-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task PostAdminRealmsClientTemplatesScopeMappingsClientsAsync(string realm, string clientScopeId, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// Remove client-level roles from the client&apos;s scope.
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task DeleteAdminRealmsClientTemplatesScopeMappingsClientsAsync(string realm, string clientScopeId, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// The available client-level roles Returns the roles for the client that can be associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsClientsAvailableAsync(string realm, string clientScopeId, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/available".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get effective client roles Returns the roles for the client that are associated with the client&apos;s scope.
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsClientsCompositeAsync(string realm, string clientScopeId, string client, GetScopeMappingsRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/composite".BuildUrl(pathParams, request);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get realm-level roles associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsRealmAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Add a set of realm-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task PostAdminRealmsClientTemplatesScopeMappingsRealmAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Remove a set of realm-level roles from the client&apos;s scope
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task DeleteAdminRealmsClientTemplatesScopeMappingsRealmAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Get realm-level roles that are available to attach to this client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsRealmAvailableAsync(string realm, string clientScopeId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/available".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsRealmCompositeAsync(string realm, string clientScopeId, GetScopeMappingsRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/composite".BuildUrl(pathParams, request);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get all scope mappings for the client
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings
  /// </summary>
  public async Task<MappingsRepresentation> GetAdminRealmsClientsScopeMappingsAsync(string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings".BuildUrl(pathParams);

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
      MappingsRepresentation? result = JsonSerializer.Deserialize<MappingsRepresentation>(responseContent, JsonConfig.Default);
      return result ?? new MappingsRepresentation();
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
  /// Get the roles associated with a client&apos;s scope Returns roles for the client.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsClientsAsync(string realm, string clientUuid, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Add client-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}
  /// </summary>
  public async Task PostAdminRealmsClientsScopeMappingsClientsAsync(string realm, string clientUuid, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// Remove client-level roles from the client&apos;s scope.
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}
  /// </summary>
  public async Task DeleteAdminRealmsClientsScopeMappingsClientsAsync(string realm, string clientUuid, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// The available client-level roles Returns the roles for the client that can be associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsClientsAvailableAsync(string realm, string clientUuid, string client, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/available".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get effective client roles Returns the roles for the client that are associated with the client&apos;s scope.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsClientsCompositeAsync(string realm, string clientUuid, string client, GetScopeMappingsRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/composite".BuildUrl(pathParams, request);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get realm-level roles associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsRealmAsync(string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Add a set of realm-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm
  /// </summary>
  public async Task PostAdminRealmsClientsScopeMappingsRealmAsync(string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Remove a set of realm-level roles from the client&apos;s scope
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm
  /// </summary>
  public async Task DeleteAdminRealmsClientsScopeMappingsRealmAsync(string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Get realm-level roles that are available to attach to this client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsRealmAvailableAsync(string realm, string clientUuid, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm/available".BuildUrl(pathParams);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
  /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsRealmCompositeAsync(string realm, string clientUuid, GetScopeMappingsRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm/composite".BuildUrl(pathParams, request);

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
      List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
      return result ?? new List<RoleRepresentation>();
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
