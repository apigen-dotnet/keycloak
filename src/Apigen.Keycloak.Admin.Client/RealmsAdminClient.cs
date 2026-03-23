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
/// Client for Realms Admin operations
/// </summary>
public class RealmsAdminClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal RealmsAdminClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get accessible realms Returns a list of accessible realms. The list is filtered based on what realms the caller is allowed to view.
  /// Operation: GET /admin/realms
  /// </summary>
  public async Task<List<RealmRepresentation>> GetRealmsAdminAsync(GetRealmsAdminRequest? request = null)
  {
    string url = "realms".BuildUrl(request: request);

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
    List<RealmRepresentation>? result = JsonSerializer.Deserialize<List<RealmRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RealmRepresentation>();
  }


  /// <summary>
  /// Import a realm. Imports a realm from a full representation of that realm.
  /// Operation: POST /admin/realms
  /// </summary>
  public async Task PostRealmsAdminAsync()
  {
    string url = "realms";

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
  /// Get the top-level representation of the realm It will not include nested information like User and Client representations.
  /// Operation: GET /admin/realms/{realm}
  /// </summary>
  public async Task<RealmRepresentation> GetAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}".BuildUrl(pathParams);

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
    RealmRepresentation? result = JsonSerializer.Deserialize<RealmRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new RealmRepresentation();
  }


  /// <summary>
  /// Update the top-level information of the realm Any user, roles or client information in the representation will be ignored.
  /// Operation: PUT /admin/realms/{realm}
  /// </summary>
  public async Task UpdateAsync(string realm, Apigen.Keycloak.Admin.Models.RealmRepresentationRequest realmRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(realmRepresentation, JsonConfig.Default);
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
  /// Delete the realm
  /// Operation: DELETE /admin/realms/{realm}
  /// </summary>
  public async Task DeleteAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}".BuildUrl(pathParams);

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
  /// Get admin events Returns all admin events, or filters events based on URL query parameters listed here
  /// Operation: GET /admin/realms/{realm}/admin-events
  /// </summary>
  public async Task<List<AdminEventRepresentation>> GetRealmsAdminAsync(string realm, GetRealmsAdminRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/admin-events".BuildUrl(pathParams, request);

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
    List<AdminEventRepresentation>? result = JsonSerializer.Deserialize<List<AdminEventRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<AdminEventRepresentation>();
  }


  /// <summary>
  /// Delete all admin events
  /// Operation: DELETE /admin/realms/{realm}/admin-events
  /// </summary>
  public async Task DeleteRealmsAdminAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/admin-events".BuildUrl(pathParams);

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
  /// Base path for importing clients under this realm.
  /// Operation: POST /admin/realms/{realm}/client-description-converter
  /// </summary>
  public async Task<ClientRepresentation> PostRealmsAdminAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/client-description-converter".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    ClientRepresentation? result = JsonSerializer.Deserialize<ClientRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new ClientRepresentation();
  }


  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/client-policies/policies
  /// </summary>
  public async Task<ClientPoliciesRepresentation> GetAdminRealmsClientPoliciesPoliciesAsync(string realm, GetRealmsAdminRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/client-policies/policies".BuildUrl(pathParams, request);

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
    ClientPoliciesRepresentation? result = JsonSerializer.Deserialize<ClientPoliciesRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new ClientPoliciesRepresentation();
  }


  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/client-policies/policies
  /// </summary>
  public async Task PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.ClientPoliciesRepresentation clientPoliciesRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/client-policies/policies".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(clientPoliciesRepresentation, JsonConfig.Default);
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
  /// 
  /// Operation: GET /admin/realms/{realm}/client-policies/profiles
  /// </summary>
  public async Task<ClientProfilesRepresentation> GetAdminRealmsClientPoliciesProfilesAsync(string realm, GetRealmsAdminRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/client-policies/profiles".BuildUrl(pathParams, request);

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
    ClientProfilesRepresentation? result = JsonSerializer.Deserialize<ClientProfilesRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new ClientProfilesRepresentation();
  }


  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/client-policies/profiles
  /// </summary>
  public async Task PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.ClientProfilesRepresentation clientProfilesRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/client-policies/profiles".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(clientProfilesRepresentation, JsonConfig.Default);
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
  /// Get client session stats Returns a JSON map.
  /// Operation: GET /admin/realms/{realm}/client-session-stats
  /// </summary>
  public async Task<JsonElement> GetRealmsAdminAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/client-session-stats".BuildUrl(pathParams);

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
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// List all client types available in the current realm
  /// Operation: GET /admin/realms/{realm}/client-types
  /// </summary>
  public async Task<ClientTypesRepresentation> GetAdminRealmsClientTypesAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/client-types".BuildUrl(pathParams);

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
    ClientTypesRepresentation? result = JsonSerializer.Deserialize<ClientTypesRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new ClientTypesRepresentation();
  }


  /// <summary>
  /// Update a client type
  /// Operation: PUT /admin/realms/{realm}/client-types
  /// </summary>
  public async Task PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.ClientTypesRepresentation clientTypesRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/client-types".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(clientTypesRepresentation, JsonConfig.Default);
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
  /// 
  /// Operation: GET /admin/realms/{realm}/credential-registrators
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsCredentialRegistratorsAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/credential-registrators".BuildUrl(pathParams);

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
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// Get realm default client scopes. Only name and ids are returned.
  /// Operation: GET /admin/realms/{realm}/default-default-client-scopes
  /// </summary>
  public async Task<List<ClientScopeRepresentation>> GetAdminRealmsDefaultDefaultClientScopesAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/default-default-client-scopes".BuildUrl(pathParams);

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
    List<ClientScopeRepresentation>? result = JsonSerializer.Deserialize<List<ClientScopeRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ClientScopeRepresentation>();
  }


  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/default-default-client-scopes/{clientScopeId}
  /// </summary>
  public async Task UpdateAsync(string clientScopeId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["clientScopeId"] = clientScopeId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/default-default-client-scopes/{clientScopeId}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    HttpResponseMessage response = await _httpClient.PutAsync(url, null);
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
  /// 
  /// Operation: DELETE /admin/realms/{realm}/default-default-client-scopes/{clientScopeId}
  /// </summary>
  public async Task DeleteAsync(string clientScopeId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["clientScopeId"] = clientScopeId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/default-default-client-scopes/{clientScopeId}".BuildUrl(pathParams);

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
  /// Get group hierarchy.  Only name and ids are returned.
  /// Operation: GET /admin/realms/{realm}/default-groups
  /// </summary>
  public async Task<List<GroupRepresentation>> GetAdminRealmsDefaultGroupsAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/default-groups".BuildUrl(pathParams);

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
    List<GroupRepresentation>? result = JsonSerializer.Deserialize<List<GroupRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<GroupRepresentation>();
  }


  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/default-groups/{groupId}
  /// </summary>
  public async Task PutAdminRealmsDefaultGroupsAsync(string groupId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["groupId"] = groupId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/default-groups/{groupId}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    HttpResponseMessage response = await _httpClient.PutAsync(url, null);
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
  /// 
  /// Operation: DELETE /admin/realms/{realm}/default-groups/{groupId}
  /// </summary>
  public async Task DeleteAdminRealmsDefaultGroupsAsync(string groupId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["groupId"] = groupId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/default-groups/{groupId}".BuildUrl(pathParams);

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
  /// Get realm optional client scopes. Only name and ids are returned.
  /// Operation: GET /admin/realms/{realm}/default-optional-client-scopes
  /// </summary>
  public async Task<List<ClientScopeRepresentation>> GetAdminRealmsDefaultOptionalClientScopesAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/default-optional-client-scopes".BuildUrl(pathParams);

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
    List<ClientScopeRepresentation>? result = JsonSerializer.Deserialize<List<ClientScopeRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ClientScopeRepresentation>();
  }


  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/default-optional-client-scopes/{clientScopeId}
  /// </summary>
  public async Task PutAdminRealmsDefaultOptionalClientScopesAsync(string clientScopeId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["clientScopeId"] = clientScopeId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/default-optional-client-scopes/{clientScopeId}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    HttpResponseMessage response = await _httpClient.PutAsync(url, null);
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
  /// 
  /// Operation: DELETE /admin/realms/{realm}/default-optional-client-scopes/{clientScopeId}
  /// </summary>
  public async Task DeleteAdminRealmsDefaultOptionalClientScopesAsync(string clientScopeId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["clientScopeId"] = clientScopeId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/default-optional-client-scopes/{clientScopeId}".BuildUrl(pathParams);

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
  /// Get events Returns all events, or filters them based on URL query parameters listed here
  /// Operation: GET /admin/realms/{realm}/events
  /// </summary>
  public async Task<List<EventRepresentation>> GetAdminRealmsEventsAsync(string realm, GetRealmsAdminRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/events".BuildUrl(pathParams, request);

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
    List<EventRepresentation>? result = JsonSerializer.Deserialize<List<EventRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<EventRepresentation>();
  }


  /// <summary>
  /// Delete all events
  /// Operation: DELETE /admin/realms/{realm}/events
  /// </summary>
  public async Task DeleteAdminRealmsEventsAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/events".BuildUrl(pathParams);

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
  /// Get the events provider configuration Returns JSON object with events provider configuration
  /// Operation: GET /admin/realms/{realm}/events/config
  /// </summary>
  public async Task<RealmEventsConfigRepresentation> GetAdminRealmsEventsConfigAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/events/config".BuildUrl(pathParams);

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
    RealmEventsConfigRepresentation? result = JsonSerializer.Deserialize<RealmEventsConfigRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new RealmEventsConfigRepresentation();
  }


  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/events/config
  /// </summary>
  public async Task PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.RealmEventsConfigRepresentation realmEventsConfigRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/events/config".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(realmEventsConfigRepresentation, JsonConfig.Default);
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
  /// 
  /// Operation: GET /admin/realms/{realm}/group-by-path/{path}
  /// </summary>
  public async Task<GroupRepresentation> GetAsync(string path, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["path"] = path,
      ["realm"] = realm
    };
    string url = "realms/{realm}/group-by-path/{path}".BuildUrl(pathParams);

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
    GroupRepresentation? result = JsonSerializer.Deserialize<GroupRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new GroupRepresentation();
  }


  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/localization
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsLocalizationAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/localization".BuildUrl(pathParams);

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
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/localization/{locale}
  /// </summary>
  public async Task<JsonElement> GetAsync(string locale, string realm, GetRealmsAdminRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["locale"] = locale,
      ["realm"] = realm
    };
    string url = "realms/{realm}/localization/{locale}".BuildUrl(pathParams, request);

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
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// Import localization from uploaded JSON file
  /// Operation: POST /admin/realms/{realm}/localization/{locale}
  /// </summary>
  public async Task PostRealmsAdminAsync(string locale, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["locale"] = locale,
      ["realm"] = realm
    };
    string url = "realms/{realm}/localization/{locale}".BuildUrl(pathParams);

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
  /// 
  /// Operation: DELETE /admin/realms/{realm}/localization/{locale}
  /// </summary>
  public async Task DeleteAdminRealmsLocalizationAsync(string locale, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["locale"] = locale,
      ["realm"] = realm
    };
    string url = "realms/{realm}/localization/{locale}".BuildUrl(pathParams);

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
  /// 
  /// Operation: GET /admin/realms/{realm}/localization/{locale}/{key}
  /// </summary>
  public async Task<object> GetAsync(string key, string locale, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["key"] = key,
      ["locale"] = locale,
      ["realm"] = realm
    };
    string url = "realms/{realm}/localization/{locale}/{key}".BuildUrl(pathParams);

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
    return new object();
  }


  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/localization/{locale}/{key}
  /// </summary>
  public async Task UpdateAsync(string key, string locale, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["key"] = key,
      ["locale"] = locale,
      ["realm"] = realm
    };
    string url = "realms/{realm}/localization/{locale}/{key}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    HttpResponseMessage response = await _httpClient.PutAsync(url, null);
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
  /// 
  /// Operation: DELETE /admin/realms/{realm}/localization/{locale}/{key}
  /// </summary>
  public async Task DeleteAsync(string key, string locale, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["key"] = key,
      ["locale"] = locale,
      ["realm"] = realm
    };
    string url = "realms/{realm}/localization/{locale}/{key}".BuildUrl(pathParams);

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
  /// Removes all user sessions.
  /// Operation: POST /admin/realms/{realm}/logout-all
  /// </summary>
  public async Task<GlobalRequestResult> PostAdminRealmsLogoutAllAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/logout-all".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    GlobalRequestResult? result = JsonSerializer.Deserialize<GlobalRequestResult>(responseContent, JsonConfig.Default);
    return result ?? new GlobalRequestResult();
  }


  /// <summary>
  /// Partial export of existing realm into a JSON file.
  /// Operation: POST /admin/realms/{realm}/partial-export
  /// </summary>
  public async Task<RealmRepresentation> PostRealmsAdminAsync(string realm, PostRealmsAdminRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/partial-export".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    RealmRepresentation? result = JsonSerializer.Deserialize<RealmRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new RealmRepresentation();
  }


  /// <summary>
  /// Partial import from a JSON file to an existing realm.
  /// Operation: POST /admin/realms/{realm}/partialImport
  /// </summary>
  public async Task<JsonElement> PostAdminRealmsPartialImportAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/partialImport".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// Push the realm&apos;s revocation policy to any client that has an admin url associated with it.
  /// Operation: POST /admin/realms/{realm}/push-revocation
  /// </summary>
  public async Task<GlobalRequestResult> PostAdminRealmsPushRevocationAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/push-revocation".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    GlobalRequestResult? result = JsonSerializer.Deserialize<GlobalRequestResult>(responseContent, JsonConfig.Default);
    return result ?? new GlobalRequestResult();
  }


  /// <summary>
  /// Remove a specific user session.
  /// Operation: DELETE /admin/realms/{realm}/sessions/{session}
  /// </summary>
  public async Task DeleteAsync(string session, string realm, DeleteRealmsAdminRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["session"] = session,
      ["realm"] = realm
    };
    string url = "realms/{realm}/sessions/{session}".BuildUrl(pathParams, request);

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
  /// Test SMTP connection with current logged in user
  /// Operation: POST /admin/realms/{realm}/testSMTPConnection
  /// </summary>
  public async Task PostAdminRealmsTestSmtpConnectionAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/testSMTPConnection".BuildUrl(pathParams);

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
  /// 
  /// Operation: GET /admin/realms/{realm}/users-management-permissions
  /// </summary>
  public async Task<ManagementPermissionReference> GetAdminRealmsUsersManagementPermissionsAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/users-management-permissions".BuildUrl(pathParams);

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
  /// 
  /// Operation: PUT /admin/realms/{realm}/users-management-permissions
  /// </summary>
  public async Task<ManagementPermissionReference> PutRealmsAdminAsync(string realm, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/users-management-permissions".BuildUrl(pathParams);

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
