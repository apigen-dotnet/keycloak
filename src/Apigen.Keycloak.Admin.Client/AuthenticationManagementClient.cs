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
/// Client for Authentication Management operations
/// </summary>
public class AuthenticationManagementClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal AuthenticationManagementClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get authenticator providers Returns a stream of authenticator providers.
  /// Operation: GET /admin/realms/{realm}/authentication/authenticator-providers
  /// </summary>
  public async Task<JsonElement> GetAuthenticationManagementAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/authenticator-providers".BuildUrl(pathParams);

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
  /// Get client authenticator providers Returns a stream of client authenticator providers.
  /// Operation: GET /admin/realms/{realm}/authentication/client-authenticator-providers
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsAuthenticationClientAuthenticatorProvidersAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/client-authenticator-providers".BuildUrl(pathParams);

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
  /// Create new authenticator configuration
  /// Operation: POST /admin/realms/{realm}/authentication/config
  /// </summary>
  public async Task PostAuthenticationManagementAsync(string realm, Apigen.Keycloak.Admin.Models.AuthenticatorConfigRepresentation authenticatorConfigRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/config".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(authenticatorConfigRepresentation, JsonConfig.Default);
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
  /// Get authenticator provider&apos;s configuration description
  /// Operation: GET /admin/realms/{realm}/authentication/config-description/{providerId}
  /// </summary>
  public async Task<AuthenticatorConfigInfoRepresentation> GetAsync(string providerId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["providerId"] = providerId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/config-description/{providerId}".BuildUrl(pathParams);

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
    AuthenticatorConfigInfoRepresentation? result = JsonSerializer.Deserialize<AuthenticatorConfigInfoRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new AuthenticatorConfigInfoRepresentation();
  }


  /// <summary>
  /// Get authenticator configuration
  /// Operation: GET /admin/realms/{realm}/authentication/config/{id}
  /// </summary>
  public async Task<AuthenticatorConfigRepresentation> GetAdminRealmsAuthenticationConfigAsync(string id, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/config/{id}".BuildUrl(pathParams);

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
    AuthenticatorConfigRepresentation? result = JsonSerializer.Deserialize<AuthenticatorConfigRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new AuthenticatorConfigRepresentation();
  }


  /// <summary>
  /// Update authenticator configuration
  /// Operation: PUT /admin/realms/{realm}/authentication/config/{id}
  /// </summary>
  public async Task UpdateAsync(string id, string realm, Apigen.Keycloak.Admin.Models.AuthenticatorConfigRepresentation authenticatorConfigRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/config/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(authenticatorConfigRepresentation, JsonConfig.Default);
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
  /// Delete authenticator configuration
  /// Operation: DELETE /admin/realms/{realm}/authentication/config/{id}
  /// </summary>
  public async Task DeleteAsync(string id, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/config/{id}".BuildUrl(pathParams);

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
  /// Add new authentication execution
  /// Operation: POST /admin/realms/{realm}/authentication/executions
  /// </summary>
  public async Task PostAuthenticationManagementAsync(string realm, Apigen.Keycloak.Admin.Models.AuthenticationExecutionRepresentation authenticationExecutionRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/executions".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(authenticationExecutionRepresentation, JsonConfig.Default);
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
  /// Get Single Execution
  /// Operation: GET /admin/realms/{realm}/authentication/executions/{executionId}
  /// </summary>
  public async Task<AuthenticationExecutionRepresentation> GetAdminRealmsAuthenticationExecutionsAsync(string executionId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["executionId"] = executionId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/executions/{executionId}".BuildUrl(pathParams);

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
    AuthenticationExecutionRepresentation? result = JsonSerializer.Deserialize<AuthenticationExecutionRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new AuthenticationExecutionRepresentation();
  }


  /// <summary>
  /// Delete execution
  /// Operation: DELETE /admin/realms/{realm}/authentication/executions/{executionId}
  /// </summary>
  public async Task DeleteAdminRealmsAuthenticationExecutionsAsync(string executionId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["executionId"] = executionId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/executions/{executionId}".BuildUrl(pathParams);

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
  /// Update execution with new configuration
  /// Operation: POST /admin/realms/{realm}/authentication/executions/{executionId}/config
  /// </summary>
  public async Task PostAuthenticationManagementAsync(string executionId, string realm, Apigen.Keycloak.Admin.Models.AuthenticatorConfigRepresentation authenticatorConfigRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["executionId"] = executionId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/executions/{executionId}/config".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(authenticatorConfigRepresentation, JsonConfig.Default);
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
  /// Get execution&apos;s configuration
  /// Operation: GET /admin/realms/{realm}/authentication/executions/{executionId}/config/{id}
  /// </summary>
  public async Task<AuthenticatorConfigRepresentation> GetAsync(string executionId, string id, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["executionId"] = executionId,
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/executions/{executionId}/config/{id}".BuildUrl(pathParams);

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
    AuthenticatorConfigRepresentation? result = JsonSerializer.Deserialize<AuthenticatorConfigRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new AuthenticatorConfigRepresentation();
  }


  /// <summary>
  /// Lower execution&apos;s priority
  /// Operation: POST /admin/realms/{realm}/authentication/executions/{executionId}/lower-priority
  /// </summary>
  public async Task PostAuthenticationManagementAsync(string executionId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["executionId"] = executionId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/executions/{executionId}/lower-priority".BuildUrl(pathParams);

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
  /// Raise execution&apos;s priority
  /// Operation: POST /admin/realms/{realm}/authentication/executions/{executionId}/raise-priority
  /// </summary>
  public async Task PostAdminRealmsAuthenticationExecutionsRaisePriorityAsync(string executionId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["executionId"] = executionId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/executions/{executionId}/raise-priority".BuildUrl(pathParams);

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
  /// Get authentication flows Returns a stream of authentication flows.
  /// Operation: GET /admin/realms/{realm}/authentication/flows
  /// </summary>
  public async Task<List<AuthenticationFlowRepresentation>> GetAdminRealmsAuthenticationFlowsAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows".BuildUrl(pathParams);

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
    List<AuthenticationFlowRepresentation>? result = JsonSerializer.Deserialize<List<AuthenticationFlowRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<AuthenticationFlowRepresentation>();
  }


  /// <summary>
  /// Create a new authentication flow
  /// Operation: POST /admin/realms/{realm}/authentication/flows
  /// </summary>
  public async Task PostAuthenticationManagementAsync(string realm, Apigen.Keycloak.Admin.Models.AuthenticationFlowRepresentation authenticationFlowRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(authenticationFlowRepresentation, JsonConfig.Default);
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
  /// Copy existing authentication flow under a new name The new name is given as &apos;newName&apos; attribute of the passed JSON object
  /// Operation: POST /admin/realms/{realm}/authentication/flows/{flowAlias}/copy
  /// </summary>
  public async Task PostAdminRealmsAuthenticationFlowsCopyAsync(string flowAlias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["flowAlias"] = flowAlias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows/{flowAlias}/copy".BuildUrl(pathParams);

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
  /// Get authentication executions for a flow
  /// Operation: GET /admin/realms/{realm}/authentication/flows/{flowAlias}/executions
  /// </summary>
  public async Task<List<AuthenticationExecutionInfoRepresentation>> GetAuthenticationManagementAsync(string flowAlias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["flowAlias"] = flowAlias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows/{flowAlias}/executions".BuildUrl(pathParams);

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
    List<AuthenticationExecutionInfoRepresentation>? result = JsonSerializer.Deserialize<List<AuthenticationExecutionInfoRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<AuthenticationExecutionInfoRepresentation>();
  }


  /// <summary>
  /// Update authentication executions of a Flow
  /// Operation: PUT /admin/realms/{realm}/authentication/flows/{flowAlias}/executions
  /// </summary>
  public async Task PutAuthenticationManagementAsync(string flowAlias, string realm, Apigen.Keycloak.Admin.Models.AuthenticationExecutionInfoRepresentation authenticationExecutionInfoRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["flowAlias"] = flowAlias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows/{flowAlias}/executions".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(authenticationExecutionInfoRepresentation, JsonConfig.Default);
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
  /// Add new authentication execution to a flow
  /// Operation: POST /admin/realms/{realm}/authentication/flows/{flowAlias}/executions/execution
  /// </summary>
  public async Task PostAdminRealmsAuthenticationFlowsExecutionsExecutionAsync(string flowAlias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["flowAlias"] = flowAlias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows/{flowAlias}/executions/execution".BuildUrl(pathParams);

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
  /// Add new flow with new execution to existing flow
  /// Operation: POST /admin/realms/{realm}/authentication/flows/{flowAlias}/executions/flow
  /// </summary>
  public async Task PostAdminRealmsAuthenticationFlowsExecutionsFlowAsync(string flowAlias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["flowAlias"] = flowAlias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows/{flowAlias}/executions/flow".BuildUrl(pathParams);

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
  /// Get authentication flow for id
  /// Operation: GET /admin/realms/{realm}/authentication/flows/{id}
  /// </summary>
  public async Task<AuthenticationFlowRepresentation> GetAdminRealmsAuthenticationFlowsAsync(string id, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows/{id}".BuildUrl(pathParams);

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
    AuthenticationFlowRepresentation? result = JsonSerializer.Deserialize<AuthenticationFlowRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new AuthenticationFlowRepresentation();
  }


  /// <summary>
  /// Update an authentication flow
  /// Operation: PUT /admin/realms/{realm}/authentication/flows/{id}
  /// </summary>
  public async Task UpdateAsync(string id, string realm, Apigen.Keycloak.Admin.Models.AuthenticationFlowRepresentation authenticationFlowRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(authenticationFlowRepresentation, JsonConfig.Default);
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
  /// Delete an authentication flow
  /// Operation: DELETE /admin/realms/{realm}/authentication/flows/{id}
  /// </summary>
  public async Task DeleteAdminRealmsAuthenticationFlowsAsync(string id, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/flows/{id}".BuildUrl(pathParams);

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
  /// Get form action providers Returns a stream of form action providers.
  /// Operation: GET /admin/realms/{realm}/authentication/form-action-providers
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsAuthenticationFormActionProvidersAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/form-action-providers".BuildUrl(pathParams);

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
  /// Get form providers Returns a stream of form providers.
  /// Operation: GET /admin/realms/{realm}/authentication/form-providers
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsAuthenticationFormProvidersAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/form-providers".BuildUrl(pathParams);

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
  /// Get configuration descriptions for all clients
  /// Operation: GET /admin/realms/{realm}/authentication/per-client-config-description
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsAuthenticationPerClientConfigDescriptionAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/per-client-config-description".BuildUrl(pathParams);

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
  /// Register a new required actions
  /// Operation: POST /admin/realms/{realm}/authentication/register-required-action
  /// </summary>
  public async Task PostAuthenticationManagementAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/register-required-action".BuildUrl(pathParams);

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
  /// Get required actions Returns a stream of required actions.
  /// Operation: GET /admin/realms/{realm}/authentication/required-actions
  /// </summary>
  public async Task<List<RequiredActionProviderRepresentation>> GetAdminRealmsAuthenticationRequiredActionsAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions".BuildUrl(pathParams);

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
    List<RequiredActionProviderRepresentation>? result = JsonSerializer.Deserialize<List<RequiredActionProviderRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<RequiredActionProviderRepresentation>();
  }


  /// <summary>
  /// Get required action for alias
  /// Operation: GET /admin/realms/{realm}/authentication/required-actions/{alias}
  /// </summary>
  public async Task<RequiredActionProviderRepresentation> GetAdminRealmsAuthenticationRequiredActionsAsync(string alias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions/{alias}".BuildUrl(pathParams);

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
    RequiredActionProviderRepresentation? result = JsonSerializer.Deserialize<RequiredActionProviderRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new RequiredActionProviderRepresentation();
  }


  /// <summary>
  /// Update required action
  /// Operation: PUT /admin/realms/{realm}/authentication/required-actions/{alias}
  /// </summary>
  public async Task UpdateAsync(string alias, string realm, Apigen.Keycloak.Admin.Models.RequiredActionProviderRepresentation requiredActionProviderRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions/{alias}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(requiredActionProviderRepresentation, JsonConfig.Default);
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
  /// Delete required action
  /// Operation: DELETE /admin/realms/{realm}/authentication/required-actions/{alias}
  /// </summary>
  public async Task DeleteAdminRealmsAuthenticationRequiredActionsAsync(string alias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions/{alias}".BuildUrl(pathParams);

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
  /// Get RequiredAction configuration
  /// Operation: GET /admin/realms/{realm}/authentication/required-actions/{alias}/config
  /// </summary>
  public async Task<RequiredActionConfigRepresentation> GetAdminRealmsAuthenticationRequiredActionsConfigAsync(string alias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions/{alias}/config".BuildUrl(pathParams);

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
    RequiredActionConfigRepresentation? result = JsonSerializer.Deserialize<RequiredActionConfigRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new RequiredActionConfigRepresentation();
  }


  /// <summary>
  /// Update RequiredAction configuration
  /// Operation: PUT /admin/realms/{realm}/authentication/required-actions/{alias}/config
  /// </summary>
  public async Task PutAuthenticationManagementAsync(string alias, string realm, Apigen.Keycloak.Admin.Models.RequiredActionConfigRepresentation requiredActionConfigRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions/{alias}/config".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(requiredActionConfigRepresentation, JsonConfig.Default);
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
  /// Delete RequiredAction configuration
  /// Operation: DELETE /admin/realms/{realm}/authentication/required-actions/{alias}/config
  /// </summary>
  public async Task DeleteAuthenticationManagementAsync(string alias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions/{alias}/config".BuildUrl(pathParams);

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
  /// Get RequiredAction provider configuration description
  /// Operation: GET /admin/realms/{realm}/authentication/required-actions/{alias}/config-description
  /// </summary>
  public async Task<RequiredActionConfigInfoRepresentation> GetAdminRealmsAuthenticationRequiredActionsConfigDescriptionAsync(string alias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions/{alias}/config-description".BuildUrl(pathParams);

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
    RequiredActionConfigInfoRepresentation? result = JsonSerializer.Deserialize<RequiredActionConfigInfoRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new RequiredActionConfigInfoRepresentation();
  }


  /// <summary>
  /// Lower required action&apos;s priority
  /// Operation: POST /admin/realms/{realm}/authentication/required-actions/{alias}/lower-priority
  /// </summary>
  public async Task PostAdminRealmsAuthenticationRequiredActionsLowerPriorityAsync(string alias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions/{alias}/lower-priority".BuildUrl(pathParams);

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
  /// Raise required action&apos;s priority
  /// Operation: POST /admin/realms/{realm}/authentication/required-actions/{alias}/raise-priority
  /// </summary>
  public async Task PostAdminRealmsAuthenticationRequiredActionsRaisePriorityAsync(string alias, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/required-actions/{alias}/raise-priority".BuildUrl(pathParams);

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
  /// Get unregistered required actions Returns a stream of unregistered required actions.
  /// Operation: GET /admin/realms/{realm}/authentication/unregistered-required-actions
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsAuthenticationUnregisteredRequiredActionsAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/authentication/unregistered-required-actions".BuildUrl(pathParams);

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


}
