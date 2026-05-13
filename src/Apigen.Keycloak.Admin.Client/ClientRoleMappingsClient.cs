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
/// Client for Client Role Mappings operations
/// </summary>
public partial class ClientRoleMappingsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ClientRoleMappingsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get client-level role mappings for the user or group, and the app
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAsync(string realm, string groupId, string clientId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

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
  /// Add client-level roles to the user or group role mapping
  /// Operation: POST /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task PostClientRoleMappingsAsync(string realm, string groupId, string clientId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

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
  /// Delete client-level roles from user or group role mapping
  /// Operation: DELETE /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task DeleteAsync(string realm, string groupId, string clientId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

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
  /// Get available client-level roles that can be mapped to the user or group
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetClientRoleMappingsAsync(string realm, string groupId, string clientId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/available".BuildUrl(pathParams);

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
  /// Get effective client-level role mappings This recurses any composite roles
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetClientRoleMappingsAsync(string realm, string groupId, string clientId, GetClientRoleMappingsRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/composite".BuildUrl(pathParams, request);

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
  /// Get client-level role mappings for the user or group, and the app
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsClientsAsync(string realm, string userId, string clientId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

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
  /// Add client-level roles to the user or group role mapping
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task PostAdminRealmsUsersRoleMappingsClientsAsync(string realm, string userId, string clientId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

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
  /// Delete client-level roles from user or group role mapping
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task DeleteAdminRealmsUsersRoleMappingsClientsAsync(string realm, string userId, string clientId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

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
  /// Get available client-level roles that can be mapped to the user or group
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsClientsAvailableAsync(string realm, string userId, string clientId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/available".BuildUrl(pathParams);

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
  /// Get effective client-level role mappings This recurses any composite roles
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsClientsCompositeAsync(string realm, string userId, string clientId, GetClientRoleMappingsRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/composite".BuildUrl(pathParams, request);

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
