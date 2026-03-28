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
/// Client for Identity Providers operations
/// </summary>
public class IdentityProvidersClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal IdentityProvidersClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Import identity provider from JSON body
  /// Operation: POST /admin/realms/{realm}/identity-provider/import-config
  /// </summary>
  public async Task<JsonElement> PostIdentityProvidersAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/identity-provider/import-config".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// List identity providers
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances
  /// </summary>
  public async Task<List<IdentityProviderRepresentation>> GetIdentityProvidersAsync(string realm, GetIdentityProvidersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/identity-provider/instances".BuildUrl(pathParams, request);

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
    List<IdentityProviderRepresentation>? result = JsonSerializer.Deserialize<List<IdentityProviderRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<IdentityProviderRepresentation>();
  }


  /// <summary>
  /// Create a new identity provider
  /// Operation: POST /admin/realms/{realm}/identity-provider/instances
  /// </summary>
  public async Task PostIdentityProvidersAsync(string realm, Apigen.Keycloak.Admin.Models.IdentityProviderRepresentation identityProviderRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/identity-provider/instances".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(identityProviderRepresentation, JsonConfig.Default);
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
  /// Get the identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}
  /// </summary>
  public async Task<IdentityProviderRepresentation> GetAsync(string realm, string alias)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}".BuildUrl(pathParams);

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
    IdentityProviderRepresentation? result = JsonSerializer.Deserialize<IdentityProviderRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new IdentityProviderRepresentation();
  }


  /// <summary>
  /// Update the identity provider
  /// Operation: PUT /admin/realms/{realm}/identity-provider/instances/{alias}
  /// </summary>
  public async Task UpdateAsync(string realm, string alias, Apigen.Keycloak.Admin.Models.IdentityProviderRepresentation identityProviderRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(identityProviderRepresentation, JsonConfig.Default);
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
  /// Delete the identity provider
  /// Operation: DELETE /admin/realms/{realm}/identity-provider/instances/{alias}
  /// </summary>
  public async Task DeleteAsync(string realm, string alias)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}".BuildUrl(pathParams);

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
  /// Export public broker configuration for identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/export
  /// </summary>
  public async Task GetIdentityProvidersAsync(string realm, string alias, GetIdentityProvidersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/export".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// Return object stating whether client Authorization permissions have been initialized or not and a reference
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> GetIdentityProvidersAsync(string realm, string alias)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/management/permissions".BuildUrl(pathParams);

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
  /// Operation: PUT /admin/realms/{realm}/identity-provider/instances/{alias}/management/permissions
  /// </summary>
  public async Task<ManagementPermissionReference> PutIdentityProvidersAsync(string realm, string alias, Apigen.Keycloak.Admin.Models.ManagementPermissionReference managementPermissionReference)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/management/permissions".BuildUrl(pathParams);

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
  /// Get mapper types for identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/mapper-types
  /// </summary>
  public async Task<object> GetAdminRealmsIdentityProviderInstancesMapperTypesAsync(string realm, string alias)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/mapper-types".BuildUrl(pathParams);

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
    return new object();
  }


  /// <summary>
  /// Get mappers for identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/mappers
  /// </summary>
  public async Task<List<IdentityProviderMapperRepresentation>> GetAdminRealmsIdentityProviderInstancesMappersAsync(string realm, string alias)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/mappers".BuildUrl(pathParams);

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
    List<IdentityProviderMapperRepresentation>? result = JsonSerializer.Deserialize<List<IdentityProviderMapperRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<IdentityProviderMapperRepresentation>();
  }


  /// <summary>
  /// Add a mapper to identity provider
  /// Operation: POST /admin/realms/{realm}/identity-provider/instances/{alias}/mappers
  /// </summary>
  public async Task PostIdentityProvidersAsync(string realm, string alias, Apigen.Keycloak.Admin.Models.IdentityProviderMapperRepresentation identityProviderMapperRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/mappers".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(identityProviderMapperRepresentation, JsonConfig.Default);
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
  /// Get mapper by id for the identity provider
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/mappers/{id}
  /// </summary>
  public async Task<IdentityProviderMapperRepresentation> GetAsync(string id, string realm, string alias)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/mappers/{id}".BuildUrl(pathParams);

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
    IdentityProviderMapperRepresentation? result = JsonSerializer.Deserialize<IdentityProviderMapperRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new IdentityProviderMapperRepresentation();
  }


  /// <summary>
  /// Update a mapper for the identity provider
  /// Operation: PUT /admin/realms/{realm}/identity-provider/instances/{alias}/mappers/{id}
  /// </summary>
  public async Task UpdateAsync(string id, string realm, string alias, Apigen.Keycloak.Admin.Models.IdentityProviderMapperRepresentation identityProviderMapperRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/mappers/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(identityProviderMapperRepresentation, JsonConfig.Default);
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
  /// Delete a mapper for the identity provider
  /// Operation: DELETE /admin/realms/{realm}/identity-provider/instances/{alias}/mappers/{id}
  /// </summary>
  public async Task DeleteAsync(string id, string realm, string alias)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/mappers/{id}".BuildUrl(pathParams);

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
  /// Reaload keys for the identity provider if the provider supports it, &quot;true&quot; is returned if reload was performed, &quot;false&quot; if not.
  /// Operation: GET /admin/realms/{realm}/identity-provider/instances/{alias}/reload-keys
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsIdentityProviderInstancesReloadKeysAsync(string realm, string alias)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["alias"] = alias
    };
    string url = "realms/{realm}/identity-provider/instances/{alias}/reload-keys".BuildUrl(pathParams);

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
  /// Get the identity provider factory for that provider id
  /// Operation: GET /admin/realms/{realm}/identity-provider/providers/{provider_id}
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsIdentityProviderProvidersAsync(string providerId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["provider_id"] = providerId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/identity-provider/providers/{provider_id}".BuildUrl(pathParams);

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


}
