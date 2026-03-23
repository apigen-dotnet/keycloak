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
/// Client for Roles (by ID) operations
/// </summary>
public class RolesByIdClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal RolesByIdClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get a specific role&apos;s representation
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}
  /// </summary>
  public async Task<RoleRepresentation> GetAsync(string roleId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}".BuildUrl(pathParams);

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
    RoleRepresentation? result = JsonSerializer.Deserialize<RoleRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new RoleRepresentation();
  }


  /// <summary>
  /// Update the role
  /// Operation: PUT /admin/realms/{realm}/roles-by-id/{role-id}
  /// </summary>
  public async Task UpdateAsync(string roleId, string realm, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(roleRepresentation, JsonConfig.Default);
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
  /// Delete the role
  /// Operation: DELETE /admin/realms/{realm}/roles-by-id/{role-id}
  /// </summary>
  public async Task DeleteAsync(string roleId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}".BuildUrl(pathParams);

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
  /// Get role&apos;s children Returns a set of role&apos;s children provided the role is a composite.
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}/composites
  /// </summary>
  public async Task<List<RoleRepresentation>> GetRolesByIdAsync(string roleId, string realm, GetRolesByIdRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}/composites".BuildUrl(pathParams, request);

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
    List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RoleRepresentation>();
  }


  /// <summary>
  /// Make the role a composite role by associating some child roles
  /// Operation: POST /admin/realms/{realm}/roles-by-id/{role-id}/composites
  /// </summary>
  public async Task PostRolesByIdAsync(string roleId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}/composites".BuildUrl(pathParams);

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
  /// Remove a set of roles from the role&apos;s composite
  /// Operation: DELETE /admin/realms/{realm}/roles-by-id/{role-id}/composites
  /// </summary>
  public async Task DeleteRolesByIdAsync(string roleId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}/composites".BuildUrl(pathParams);

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
  /// Get client-level roles for the client that are in the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}/composites/clients/{clientUuid}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAsync(string clientUuid, string roleId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["clientUuid"] = clientUuid,
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}/composites/clients/{clientUuid}".BuildUrl(pathParams);

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
    List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RoleRepresentation>();
  }


  /// <summary>
  /// Get realm-level roles that are in the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}/composites/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetRolesByIdAsync(string roleId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}/composites/realm".BuildUrl(pathParams);

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
    List<RoleRepresentation>? result = JsonSerializer.Deserialize<List<RoleRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RoleRepresentation>();
  }


  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> GetAdminRealmsRolesByIdManagementPermissionsAsync(string roleId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}/management/permissions".BuildUrl(pathParams);

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
    ManagementPermissionReference? result = JsonSerializer.Deserialize<ManagementPermissionReference>(responseContent, JsonConfig.Default);
    return result ?? new ManagementPermissionReference();
  }


  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: PUT /admin/realms/{realm}/roles-by-id/{role-id}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> PutRolesByIdAsync(string roleId, string realm, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-id"] = roleId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles-by-id/{role-id}/management/permissions".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(managementPermissionReference, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "PUT", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    ManagementPermissionReference? result = JsonSerializer.Deserialize<ManagementPermissionReference>(responseContent, JsonConfig.Default);
    return result ?? new ManagementPermissionReference();
  }


}
