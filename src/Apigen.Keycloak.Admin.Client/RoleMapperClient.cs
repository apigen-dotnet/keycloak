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
/// Client for Role Mapper operations
/// </summary>
public class RoleMapperClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal RoleMapperClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get role mappings
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings
  /// </summary>
  public async Task<MappingsRepresentation> GetRoleMapperAsync(string realm, string groupId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings".BuildUrl(pathParams);

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
    MappingsRepresentation? result = JsonSerializer.Deserialize<MappingsRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new MappingsRepresentation();
  }


  /// <summary>
  /// Get realm-level role mappings
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsGroupsRoleMappingsRealmAsync(string realm, string groupId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/realm".BuildUrl(pathParams);

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
  /// Add realm-level role mappings to the user
  /// Operation: POST /admin/realms/{realm}/groups/{group-id}/role-mappings/realm
  /// </summary>
  public async Task PostRoleMapperAsync(string realm, string groupId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/realm".BuildUrl(pathParams);

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
  /// Delete realm-level role mappings
  /// Operation: DELETE /admin/realms/{realm}/groups/{group-id}/role-mappings/realm
  /// </summary>
  public async Task DeleteRoleMapperAsync(string realm, string groupId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/realm".BuildUrl(pathParams);

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
  /// Get realm-level roles that can be mapped
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/realm/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsGroupsRoleMappingsRealmAvailableAsync(string realm, string groupId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/realm/available".BuildUrl(pathParams);

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
  /// Get effective realm-level role mappings This will recurse all composite roles to get the result.
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/realm/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetRoleMapperAsync(string realm, string groupId, GetRoleMapperRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/role-mappings/realm/composite".BuildUrl(pathParams, request);

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
  /// Get role mappings
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings
  /// </summary>
  public async Task<MappingsRepresentation> GetAdminRealmsUsersRoleMappingsAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings".BuildUrl(pathParams);

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
    MappingsRepresentation? result = JsonSerializer.Deserialize<MappingsRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new MappingsRepresentation();
  }


  /// <summary>
  /// Get realm-level role mappings
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsRealmAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/realm".BuildUrl(pathParams);

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
  /// Add realm-level role mappings to the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/role-mappings/realm
  /// </summary>
  public async Task PostAdminRealmsUsersRoleMappingsRealmAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/realm".BuildUrl(pathParams);

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
  /// Delete realm-level role mappings
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/role-mappings/realm
  /// </summary>
  public async Task DeleteAdminRealmsUsersRoleMappingsRealmAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/realm".BuildUrl(pathParams);

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
  /// Get realm-level roles that can be mapped
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/realm/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsRealmAvailableAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/realm/available".BuildUrl(pathParams);

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
  /// Get effective realm-level role mappings This will recurse all composite roles to get the result.
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/role-mappings/realm/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsUsersRoleMappingsRealmCompositeAsync(string realm, string userId, GetRoleMapperRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/role-mappings/realm/composite".BuildUrl(pathParams, request);

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
