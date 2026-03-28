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
/// Client for Groups operations
/// </summary>
public class GroupsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal GroupsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get group hierarchy.  Only `name` and `id` are returned.  `subGroups` are only returned when using the `search` or `q` parameter. If none of these parameters is provided, the top-level groups are returned without `subGroups` being filled.
  /// Operation: GET /admin/realms/{realm}/groups
  /// </summary>
  public async Task<List<GroupRepresentation>> GetGroupsAsync(string realm, GetGroupsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/groups".BuildUrl(pathParams, request);

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
    List<GroupRepresentation>? result = JsonSerializer.Deserialize<List<GroupRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<GroupRepresentation>();
  }


  /// <summary>
  /// create or add a top level realm groupSet or create child.
  /// Operation: POST /admin/realms/{realm}/groups
  /// </summary>
  public async Task PostGroupsAsync(string realm, Apigen.Keycloak.Admin.Models.GroupRepresentation groupRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/groups".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(groupRepresentation, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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
  /// Returns the groups counts.
  /// Operation: GET /admin/realms/{realm}/groups/count
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsGroupsCountAsync(string realm, GetGroupsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/groups/count".BuildUrl(pathParams, request);

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
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}
  /// </summary>
  public async Task<GroupRepresentation> GetAsync(string realm, string groupId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}".BuildUrl(pathParams);

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
    GroupRepresentation? result = JsonSerializer.Deserialize<GroupRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new GroupRepresentation();
  }


  /// <summary>
  /// Update group, ignores subgroups.
  /// Operation: PUT /admin/realms/{realm}/groups/{group-id}
  /// </summary>
  public async Task UpdateAsync(string realm, string groupId, Apigen.Keycloak.Admin.Models.GroupRepresentation groupRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(groupRepresentation, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "PUT", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/groups/{group-id}
  /// </summary>
  public async Task DeleteAsync(string realm, string groupId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}".BuildUrl(pathParams);

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
  /// Return a paginated list of subgroups that have a parent group corresponding to the group on the URL
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/children
  /// </summary>
  public async Task<List<GroupRepresentation>> GetGroupsAsync(string realm, string groupId, GetGroupsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/children".BuildUrl(pathParams, request);

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
    List<GroupRepresentation>? result = JsonSerializer.Deserialize<List<GroupRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<GroupRepresentation>();
  }


  /// <summary>
  /// Set or create child.
  /// Operation: POST /admin/realms/{realm}/groups/{group-id}/children
  /// </summary>
  public async Task PostGroupsAsync(string realm, string groupId, Apigen.Keycloak.Admin.Models.GroupRepresentation groupRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/children".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(groupRepresentation, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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
  /// Return object stating whether client Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> GetGroupsAsync(string realm, string groupId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/management/permissions".BuildUrl(pathParams);

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
    ManagementPermissionReference? result = JsonSerializer.Deserialize<ManagementPermissionReference>(responseContent, JsonConfig.Default);
    return result ?? new ManagementPermissionReference();
  }


  /// <summary>
  /// Return object stating whether client Authorization permissions have been initialized or not and a reference
  /// Operation: PUT /admin/realms/{realm}/groups/{group-id}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> PutGroupsAsync(string realm, string groupId, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/management/permissions".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(managementPermissionReference, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "PUT", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    ManagementPermissionReference? result = JsonSerializer.Deserialize<ManagementPermissionReference>(responseContent, JsonConfig.Default);
    return result ?? new ManagementPermissionReference();
  }


  /// <summary>
  /// Get users Returns a stream of users, filtered according to query parameters
  /// Operation: GET /admin/realms/{realm}/groups/{group-id}/members
  /// </summary>
  public async Task<List<UserRepresentation>> GetAdminRealmsGroupsMembersAsync(string realm, string groupId, GetGroupsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["group-id"] = groupId
    };
    string url = "realms/{realm}/groups/{group-id}/members".BuildUrl(pathParams, request);

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
    List<UserRepresentation>? result = JsonSerializer.Deserialize<List<UserRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<UserRepresentation>();
  }


}
