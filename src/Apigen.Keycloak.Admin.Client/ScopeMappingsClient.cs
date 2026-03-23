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
/// Client for Scope Mappings operations
/// </summary>
public class ScopeMappingsClient
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
  public async Task<MappingsRepresentation> GetScopeMappingsAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings".BuildUrl(pathParams);

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
    MappingsRepresentation? result = JsonSerializer.Deserialize<MappingsRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new MappingsRepresentation();
  }


  /// <summary>
  /// Get the roles associated with a client&apos;s scope Returns roles for the client.
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAsync(string realm, string clientScopeId, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// Add client-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task PostScopeMappingsAsync(string realm, string clientScopeId, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// Remove client-level roles from the client&apos;s scope.
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task DeleteAsync(string realm, string clientScopeId, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// The available client-level roles Returns the roles for the client that can be associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetScopeMappingsAsync(string realm, string clientScopeId, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/available".BuildUrl(pathParams);

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
  /// Get effective client roles Returns the roles for the client that are associated with the client&apos;s scope.
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetScopeMappingsAsync(string realm, string clientScopeId, string client, GetScopeMappingsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/composite".BuildUrl(pathParams, request);

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
  /// Get realm-level roles associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientScopesScopeMappingsRealmAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Add a set of realm-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task PostScopeMappingsAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Remove a set of realm-level roles from the client&apos;s scope
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task DeleteScopeMappingsAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Get realm-level roles that are available to attach to this client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientScopesScopeMappingsRealmAvailableAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/available".BuildUrl(pathParams);

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
  /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetScopeMappingsAsync(string realm, string clientScopeId, GetScopeMappingsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/realm/composite".BuildUrl(pathParams, request);

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
  /// Get all scope mappings for the client
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings
  /// </summary>
  public async Task<MappingsRepresentation> GetAdminRealmsClientTemplatesScopeMappingsAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings".BuildUrl(pathParams);

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
    MappingsRepresentation? result = JsonSerializer.Deserialize<MappingsRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new MappingsRepresentation();
  }


  /// <summary>
  /// Get the roles associated with a client&apos;s scope Returns roles for the client.
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsClientsAsync(string realm, string clientScopeId, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// Add client-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task PostAdminRealmsClientTemplatesScopeMappingsClientsAsync(string realm, string clientScopeId, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// Remove client-level roles from the client&apos;s scope.
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}
  /// </summary>
  public async Task DeleteAdminRealmsClientTemplatesScopeMappingsClientsAsync(string realm, string clientScopeId, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// The available client-level roles Returns the roles for the client that can be associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsClientsAvailableAsync(string realm, string clientScopeId, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/available".BuildUrl(pathParams);

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
  /// Get effective client roles Returns the roles for the client that are associated with the client&apos;s scope.
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsClientsCompositeAsync(string realm, string clientScopeId, string client, GetScopeMappingsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId,
      ["client"] = client
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/clients/{client}/composite".BuildUrl(pathParams, request);

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
  /// Get realm-level roles associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsRealmAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Add a set of realm-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task PostAdminRealmsClientTemplatesScopeMappingsRealmAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Remove a set of realm-level roles from the client&apos;s scope
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm
  /// </summary>
  public async Task DeleteAdminRealmsClientTemplatesScopeMappingsRealmAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Get realm-level roles that are available to attach to this client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsRealmAvailableAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/available".BuildUrl(pathParams);

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
  /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientTemplatesScopeMappingsRealmCompositeAsync(string realm, string clientScopeId, GetScopeMappingsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/scope-mappings/realm/composite".BuildUrl(pathParams, request);

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
  /// Get all scope mappings for the client
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings
  /// </summary>
  public async Task<MappingsRepresentation> GetAdminRealmsClientsScopeMappingsAsync(string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings".BuildUrl(pathParams);

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
    MappingsRepresentation? result = JsonSerializer.Deserialize<MappingsRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new MappingsRepresentation();
  }


  /// <summary>
  /// Get the roles associated with a client&apos;s scope Returns roles for the client.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsClientsAsync(string realm, string clientUuid, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// Add client-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}
  /// </summary>
  public async Task PostAdminRealmsClientsScopeMappingsClientsAsync(string realm, string clientUuid, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// Remove client-level roles from the client&apos;s scope.
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}
  /// </summary>
  public async Task DeleteAdminRealmsClientsScopeMappingsClientsAsync(string realm, string clientUuid, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}".BuildUrl(pathParams);

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
  /// The available client-level roles Returns the roles for the client that can be associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsClientsAvailableAsync(string realm, string clientUuid, string client)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/available".BuildUrl(pathParams);

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
  /// Get effective client roles Returns the roles for the client that are associated with the client&apos;s scope.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsClientsCompositeAsync(string realm, string clientUuid, string client, GetScopeMappingsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["client"] = client
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/clients/{client}/composite".BuildUrl(pathParams, request);

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
  /// Get realm-level roles associated with the client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsRealmAsync(string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Add a set of realm-level roles to the client&apos;s scope
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm
  /// </summary>
  public async Task PostAdminRealmsClientsScopeMappingsRealmAsync(string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Remove a set of realm-level roles from the client&apos;s scope
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm
  /// </summary>
  public async Task DeleteAdminRealmsClientsScopeMappingsRealmAsync(string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm".BuildUrl(pathParams);

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
  /// Get realm-level roles that are available to attach to this client&apos;s scope
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm/available
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsRealmAvailableAsync(string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm/available".BuildUrl(pathParams);

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
  /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/scope-mappings/realm/composite
  /// </summary>
  public async Task<List<RoleRepresentation>> GetAdminRealmsClientsScopeMappingsRealmCompositeAsync(string realm, string clientUuid, GetScopeMappingsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/scope-mappings/realm/composite".BuildUrl(pathParams, request);

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


}
