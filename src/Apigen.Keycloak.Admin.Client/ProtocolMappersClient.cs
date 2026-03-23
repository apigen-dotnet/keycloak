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
/// Client for Protocol Mappers operations
/// </summary>
public class ProtocolMappersClient
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
  public async Task PostProtocolMappersAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/add-models".BuildUrl(pathParams);

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
  /// Get mappers
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetProtocolMappersAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models".BuildUrl(pathParams);

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
    List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ProtocolMapperRepresentation>();
  }


  /// <summary>
  /// Create a mapper
  /// Operation: POST /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models
  /// </summary>
  public async Task PostProtocolMappersAsync(string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Get mapper by id
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task<ProtocolMapperRepresentation> GetAsync(string id, string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
    ProtocolMapperRepresentation? result = JsonSerializer.Deserialize<ProtocolMapperRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new ProtocolMapperRepresentation();
  }


  /// <summary>
  /// Update the mapper
  /// Operation: PUT /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task UpdateAsync(string id, string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Delete the mapper
  /// Operation: DELETE /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task DeleteAsync(string id, string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
  /// Get mappers by name for a specific protocol
  /// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/protocol/{protocol}
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientScopesProtocolMappersProtocolAsync(string protocol, string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["protocol"] = protocol,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-scopes/{client-scope-id}/protocol-mappers/protocol/{protocol}".BuildUrl(pathParams);

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
    List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ProtocolMapperRepresentation>();
  }


  /// <summary>
  /// Create multiple mappers
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/add-models
  /// </summary>
  public async Task PostAdminRealmsClientTemplatesProtocolMappersAddModelsAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/add-models".BuildUrl(pathParams);

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
  /// Get mappers
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientTemplatesProtocolMappersModelsAsync(string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models".BuildUrl(pathParams);

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
    List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ProtocolMapperRepresentation>();
  }


  /// <summary>
  /// Create a mapper
  /// Operation: POST /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models
  /// </summary>
  public async Task PostAdminRealmsClientTemplatesProtocolMappersModelsAsync(string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Get mapper by id
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task<ProtocolMapperRepresentation> GetAdminRealmsClientTemplatesProtocolMappersModelsAsync(string id, string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
    ProtocolMapperRepresentation? result = JsonSerializer.Deserialize<ProtocolMapperRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new ProtocolMapperRepresentation();
  }


  /// <summary>
  /// Update the mapper
  /// Operation: PUT /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task PutAdminRealmsClientTemplatesProtocolMappersModelsAsync(string id, string realm, string clientScopeId, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Delete the mapper
  /// Operation: DELETE /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}
  /// </summary>
  public async Task DeleteAdminRealmsClientTemplatesProtocolMappersModelsAsync(string id, string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
  /// Get mappers by name for a specific protocol
  /// Operation: GET /admin/realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/protocol/{protocol}
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientTemplatesProtocolMappersProtocolAsync(string protocol, string realm, string clientScopeId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["protocol"] = protocol,
      ["realm"] = realm,
      ["client-scope-id"] = clientScopeId
    };
    string url = "realms/{realm}/client-templates/{client-scope-id}/protocol-mappers/protocol/{protocol}".BuildUrl(pathParams);

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
    List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ProtocolMapperRepresentation>();
  }


  /// <summary>
  /// Create multiple mappers
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/add-models
  /// </summary>
  public async Task PostAdminRealmsClientsProtocolMappersAddModelsAsync(string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/add-models".BuildUrl(pathParams);

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
  /// Get mappers
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientsProtocolMappersModelsAsync(string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models".BuildUrl(pathParams);

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
    List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ProtocolMapperRepresentation>();
  }


  /// <summary>
  /// Create a mapper
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models
  /// </summary>
  public async Task PostAdminRealmsClientsProtocolMappersModelsAsync(string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Get mapper by id
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}
  /// </summary>
  public async Task<ProtocolMapperRepresentation> GetAdminRealmsClientsProtocolMappersModelsAsync(string id, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
    ProtocolMapperRepresentation? result = JsonSerializer.Deserialize<ProtocolMapperRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new ProtocolMapperRepresentation();
  }


  /// <summary>
  /// Update the mapper
  /// Operation: PUT /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}
  /// </summary>
  public async Task PutAdminRealmsClientsProtocolMappersModelsAsync(string id, string realm, string clientUuid, Apigen.Keycloak.Admin.Models.ProtocolMapperRepresentation protocolMapperRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(protocolMapperRepresentation, JsonConfig.Default);
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
  /// Delete the mapper
  /// Operation: DELETE /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}
  /// </summary>
  public async Task DeleteAdminRealmsClientsProtocolMappersModelsAsync(string id, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/models/{id}".BuildUrl(pathParams);

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
  /// Get mappers by name for a specific protocol
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/protocol-mappers/protocol/{protocol}
  /// </summary>
  public async Task<List<ProtocolMapperRepresentation>> GetAdminRealmsClientsProtocolMappersProtocolAsync(string protocol, string realm, string clientUuid)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["protocol"] = protocol,
      ["realm"] = realm,
      ["client-uuid"] = clientUuid
    };
    string url = "realms/{realm}/clients/{client-uuid}/protocol-mappers/protocol/{protocol}".BuildUrl(pathParams);

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
    List<ProtocolMapperRepresentation>? result = JsonSerializer.Deserialize<List<ProtocolMapperRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ProtocolMapperRepresentation>();
  }


}
