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
/// Client for Client Role Mappings operations
/// </summary>
public class ClientRoleMappingsClient
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
  public async Task<List<RoleRepresentation>> GetAsync(string realm, string groupId, string clientId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RoleRepresentation>();
  }


  /// <summary>
  /// Add client-level roles to the user or group role mapping
  /// Operation: POST /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task PostClientRoleMappingsAsync(string realm, string groupId, string clientId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Delete client-level roles from user or group role mapping
  /// Operation: DELETE /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task DeleteAsync(string realm, string groupId, string clientId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Get available client-level roles that can be mapped to the user or group
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetClientRoleMappingsAsync(string realm, string groupId, string clientId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/available".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RoleRepresentation>();
  }


  /// <summary>
  /// Get effective client-level role mappings This recurses any composite roles
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetClientRoleMappingsAsync(string realm, string groupId, string clientId, GetClientRoleMappingsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/composite".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RoleRepresentation>();
  }


  /// <summary>
  /// Get client-level role mappings for the user or group, and the app
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsClientsAsync(string realm, string userId, string clientId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RoleRepresentation>();
  }


  /// <summary>
  /// Add client-level roles to the user or group role mapping
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task PostAdminRealmsUsersRoleMappingsClientsAsync(string realm, string userId, string clientId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Delete client-level roles from user or group role mapping
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}
  /// </summary>
  public async Task DeleteAdminRealmsUsersRoleMappingsClientsAsync(string realm, string userId, string clientId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Get available client-level roles that can be mapped to the user or group
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsClientsAvailableAsync(string realm, string userId, string clientId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/available".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RoleRepresentation>();
  }


  /// <summary>
  /// Get effective client-level role mappings This recurses any composite roles
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsClientsCompositeAsync(string realm, string userId, string clientId, GetClientRoleMappingsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId,
      ["client-id"] = clientId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/clients/{client-id}/composite".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RoleRepresentation>();
  }


}
