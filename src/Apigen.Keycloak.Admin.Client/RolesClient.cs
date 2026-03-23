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
/// Client for Roles operations
/// </summary>
public class RolesClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal RolesClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all roles for the realm or client
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles
  /// </summary>
  public async Task<List<RoleRepresentation>> GetRolesAsync(string realm, string clientUuid, GetRolesRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles".BuildUrl(pathParams, request);

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
  /// Create a new role for the realm or client
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/roles
  /// </summary>
  public async Task PostRolesAsync(string realm, string clientUuid, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(roleRepresentation, JsonConfig.Default);
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
  /// Get a role by name
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}
  /// </summary>
  public async Task<RoleRepresentation> GetAsync(string roleName, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}".BuildUrl(pathParams);

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
  /// Update a role by name
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}
  /// </summary>
  public async Task UpdateAsync(string roleName, string realm, string clientUuid, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}".BuildUrl(pathParams);

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
  /// Delete a role by name
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}
  /// </summary>
  public async Task DeleteAsync(string roleName, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}".BuildUrl(pathParams);

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
  /// Get composites of the role
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites
  /// </summary>
  public async Task<List<RoleRepresentation>> GetRolesAsync(string roleName, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites".BuildUrl(pathParams);

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
  /// Add a composite to the role
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites
  /// </summary>
  public async Task PostRolesAsync(string roleName, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites".BuildUrl(pathParams);

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
  /// Remove roles from the role&apos;s composite
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites
  /// </summary>
  public async Task DeleteRolesAsync(string roleName, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites".BuildUrl(pathParams);

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
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites/clients/{client-uuid}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsRolesCompositesClientsAsync(string clientUuid, string roleName, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["client-uuid"] = clientUuid,
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites/clients/{client-uuid}".BuildUrl(pathParams);

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
  /// Get realm-level roles of the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsRolesCompositesRealmAsync(string roleName, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}/composites/realm".BuildUrl(pathParams);

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
  /// Returns a stream of groups that have the specified role name
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/groups
  /// </summary>
  public async Task<List<UserRepresentation>> GetRolesAsync(string roleName, string realm, string clientUuid, GetRolesRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}/groups".BuildUrl(pathParams, request);

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
    List<UserRepresentation>? result = JsonSerializer.Deserialize<List<UserRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<UserRepresentation>();
  }


  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> GetAdminRealmsClientsRolesManagementPermissionsAsync(string roleName, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}/management/permissions".BuildUrl(pathParams);

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
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> PutRolesAsync(string roleName, string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}/management/permissions".BuildUrl(pathParams);

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


  /// <summary>
  /// Returns a stream of users that have the specified role name.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles/{role-name}/users
  /// </summary>
  public async Task<List<UserRepresentation>> GetAdminRealmsClientsRolesUsersAsync(string roleName, string realm, string clientUuid, GetRolesRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/roles/{role-name}/users".BuildUrl(pathParams, request);

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
    List<UserRepresentation>? result = JsonSerializer.Deserialize<List<UserRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<UserRepresentation>();
  }


  /// <summary>
  /// Get all roles for the realm or client
  /// Operation: GET /admin/realms/{realm}/roles
  /// </summary>
  public async Task<List<RoleRepresentation>> GetRolesAsync(string realm, GetRolesRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles".BuildUrl(pathParams, request);

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
  /// Create a new role for the realm or client
  /// Operation: POST /admin/realms/{realm}/roles
  /// </summary>
  public async Task PostRolesAsync(string realm, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(roleRepresentation, JsonConfig.Default);
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
  /// Get a role by name
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}
  /// </summary>
  public async Task<RoleRepresentation> GetAsync(string roleName, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}".BuildUrl(pathParams);

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
  /// Update a role by name
  /// Operation: PUT /admin/realms/{realm}/roles/{role-name}
  /// </summary>
  public async Task UpdateAsync(string roleName, string realm, Apigen.Keycloak.Admin.Models.RoleRepresentation roleRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}".BuildUrl(pathParams);

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
  /// Delete a role by name
  /// Operation: DELETE /admin/realms/{realm}/roles/{role-name}
  /// </summary>
  public async Task DeleteAsync(string roleName, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}".BuildUrl(pathParams);

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
  /// Get composites of the role
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/composites
  /// </summary>
  public async Task<List<RoleRepresentation>> GetRolesAsync(string roleName, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}/composites".BuildUrl(pathParams);

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
  /// Add a composite to the role
  /// Operation: POST /admin/realms/{realm}/roles/{role-name}/composites
  /// </summary>
  public async Task PostRolesAsync(string roleName, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}/composites".BuildUrl(pathParams);

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
  /// Remove roles from the role&apos;s composite
  /// Operation: DELETE /admin/realms/{realm}/roles/{role-name}/composites
  /// </summary>
  public async Task DeleteRolesAsync(string roleName, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}/composites".BuildUrl(pathParams);

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
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/composites/clients/{client-uuid}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsRolesCompositesClientsAsync(string clientUuid, string roleName, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["client-uuid"] = clientUuid,
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}/composites/clients/{client-uuid}".BuildUrl(pathParams);

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
  /// Get realm-level roles of the role&apos;s composite
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/composites/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsRolesCompositesRealmAsync(string roleName, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}/composites/realm".BuildUrl(pathParams);

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
  /// Returns a stream of groups that have the specified role name
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/groups
  /// </summary>
  public async Task<List<UserRepresentation>> GetAdminRealmsRolesGroupsAsync(string roleName, string realm, GetRolesRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}/groups".BuildUrl(pathParams, request);

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
    List<UserRepresentation>? result = JsonSerializer.Deserialize<List<UserRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<UserRepresentation>();
  }


  /// <summary>
  /// Return object stating whether role Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> GetAdminRealmsRolesManagementPermissionsAsync(string roleName, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}/management/permissions".BuildUrl(pathParams);

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
  /// Operation: PUT /admin/realms/{realm}/roles/{role-name}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> PutRolesAsync(string roleName, string realm, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}/management/permissions".BuildUrl(pathParams);

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


  /// <summary>
  /// Returns a stream of users that have the specified role name.
  /// Operation: GET /admin/realms/{realm}/roles/{role-name}/users
  /// </summary>
  public async Task<List<UserRepresentation>> GetAdminRealmsRolesUsersAsync(string roleName, string realm, GetRolesRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["role-name"] = roleName,
      ["realm"] = realm
    };
    string url = "realms/{realm}/roles/{role-name}/users".BuildUrl(pathParams, request);

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
    List<UserRepresentation>? result = JsonSerializer.Deserialize<List<UserRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<UserRepresentation>();
  }


}
