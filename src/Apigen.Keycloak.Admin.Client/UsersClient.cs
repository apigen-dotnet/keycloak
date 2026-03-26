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
/// Client for Users operations
/// </summary>
public class UsersClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal UsersClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get users Returns a stream of users, filtered according to query parameters.
  /// Operation: GET /admin/realms/{realm}/users
  /// </summary>
  public async Task<List<UserRepresentation>> GetUsersAsync(string realm, GetUsersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/users".BuildUrl(pathParams, request);

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
  /// Create a new user Username must be unique.
  /// Operation: POST /admin/realms/{realm}/users
  /// </summary>
  public async Task PostUsersAsync(string realm, Apigen.Keycloak.Admin.Models.UserRepresentation userRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/users".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(userRepresentation, JsonConfig.Default);
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
  /// Returns the number of users that match the given criteria.
  /// Operation: GET /admin/realms/{realm}/users/count
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsUsersCountAsync(string realm, GetUsersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/users/count".BuildUrl(pathParams, request);

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
  /// Operation: GET /admin/realms/{realm}/users/profile
  /// </summary>
  public async Task<UPConfig> GetUsersAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/users/profile".BuildUrl(pathParams);

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
    UPConfig? result = JsonSerializer.Deserialize<UPConfig>(responseContent, JsonConfig.Default);
    return result ?? new UPConfig();
  }


  /// <summary>
  /// 
  /// Operation: PUT /admin/realms/{realm}/users/profile
  /// </summary>
  public async Task<UPConfig> PutUsersAsync(string realm, Apigen.Keycloak.Admin.Models.UPConfig upConfig)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/users/profile".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(upConfig, JsonConfig.Default);
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
    UPConfig? result = JsonSerializer.Deserialize<UPConfig>(responseContent, JsonConfig.Default);
    return result ?? new UPConfig();
  }


  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/profile/metadata
  /// </summary>
  public async Task<UserProfileMetadata> GetAdminRealmsUsersProfileMetadataAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/users/profile/metadata".BuildUrl(pathParams);

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
    UserProfileMetadata? result = JsonSerializer.Deserialize<UserProfileMetadata>(responseContent, JsonConfig.Default);
    return result ?? new UserProfileMetadata();
  }


  /// <summary>
  /// Get representation of the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}
  /// </summary>
  public async Task<UserRepresentation> GetAsync(string realm, string userId, GetUsersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}".BuildUrl(pathParams, request);

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
    UserRepresentation? result = JsonSerializer.Deserialize<UserRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new UserRepresentation();
  }


  /// <summary>
  /// Update the user
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}
  /// </summary>
  public async Task UpdateAsync(string realm, string userId, Apigen.Keycloak.Admin.Models.UserRepresentation userRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(userRepresentation, JsonConfig.Default);
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
  /// Delete the user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}
  /// </summary>
  public async Task DeleteAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}".BuildUrl(pathParams);

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
  /// Return credential types, which are provided by the user storage where user is stored.
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/configured-user-storage-credential-types
  /// </summary>
  public async Task<JsonElement> GetUsersAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/configured-user-storage-credential-types".BuildUrl(pathParams);

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
  /// Get consents granted by the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/consents
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsUsersConsentsAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/consents".BuildUrl(pathParams);

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
  /// Revoke consent and offline tokens for particular client from user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/consents/{client}
  /// </summary>
  public async Task DeleteAsync(string client, string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["client"] = client,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/consents/{client}".BuildUrl(pathParams);

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
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/credentials
  /// </summary>
  public async Task<List<CredentialRepresentation>> GetAdminRealmsUsersCredentialsAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/credentials".BuildUrl(pathParams);

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
    List<CredentialRepresentation>? result = JsonSerializer.Deserialize<List<CredentialRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<CredentialRepresentation>();
  }


  /// <summary>
  /// Remove a credential for a user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}
  /// </summary>
  public async Task DeleteAdminRealmsUsersCredentialsAsync(string credentialId, string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["credentialId"] = credentialId,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/credentials/{credentialId}".BuildUrl(pathParams);

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
  /// Move a credential to a position behind another credential
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}
  /// </summary>
  public async Task PostUsersAsync(string credentialId, string newPreviousCredentialId, string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["credentialId"] = credentialId,
      ["newPreviousCredentialId"] = newPreviousCredentialId,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}".BuildUrl(pathParams);

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
  /// Move a credential to a first position in the credentials list of the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}/moveToFirst
  /// </summary>
  public async Task PostUsersAsync(string credentialId, string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["credentialId"] = credentialId,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/credentials/{credentialId}/moveToFirst".BuildUrl(pathParams);

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
  /// Update a credential label for a user
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/credentials/{credentialId}/userLabel
  /// </summary>
  public async Task PutUsersAsync(string credentialId, string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["credentialId"] = credentialId,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/credentials/{credentialId}/userLabel".BuildUrl(pathParams);

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
  /// Disable all credentials for a user of a specific type
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/disable-credential-types
  /// </summary>
  public async Task PutUsersAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/disable-credential-types".BuildUrl(pathParams);

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
  /// Send an email to the user with a link they can click to execute particular actions.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/execute-actions-email
  /// </summary>
  public async Task PutUsersAsync(string realm, string userId, PutUsersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/execute-actions-email".BuildUrl(pathParams, request);

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
  /// Get social logins associated with the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/federated-identity
  /// </summary>
  public async Task<List<FederatedIdentityRepresentation>> GetAdminRealmsUsersFederatedIdentityAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/federated-identity".BuildUrl(pathParams);

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
    List<FederatedIdentityRepresentation>? result = JsonSerializer.Deserialize<List<FederatedIdentityRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<FederatedIdentityRepresentation>();
  }


  /// <summary>
  /// Add a social login provider to the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/federated-identity/{provider}
  /// </summary>
  public async Task PostUsersAsync(string provider, string realm, string userId, Apigen.Keycloak.Admin.Models.FederatedIdentityRepresentation federatedIdentityRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["provider"] = provider,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/federated-identity/{provider}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(federatedIdentityRepresentation, JsonConfig.Default);
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
  /// Remove a social login provider from user
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/federated-identity/{provider}
  /// </summary>
  public async Task DeleteAdminRealmsUsersFederatedIdentityAsync(string provider, string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["provider"] = provider,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/federated-identity/{provider}".BuildUrl(pathParams);

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
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/groups
  /// </summary>
  public async Task<List<GroupRepresentation>> GetUsersAsync(string realm, string userId, GetUsersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/groups".BuildUrl(pathParams, request);

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
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/groups/count
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsUsersGroupsCountAsync(string realm, string userId, GetUsersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/groups/count".BuildUrl(pathParams, request);

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
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/groups/{groupId}
  /// </summary>
  public async Task UpdateAsync(string groupId, string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["groupId"] = groupId,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/groups/{groupId}".BuildUrl(pathParams);

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
  /// Operation: DELETE /admin/realms/{realm}/users/{user-id}/groups/{groupId}
  /// </summary>
  public async Task DeleteAdminRealmsUsersGroupsAsync(string groupId, string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["groupId"] = groupId,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/groups/{groupId}".BuildUrl(pathParams);

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
  /// Impersonate the user
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/impersonation
  /// </summary>
  public async Task<JsonElement> PostUsersAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/impersonation".BuildUrl(pathParams);

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
  /// Remove all user sessions associated with the user Also send notification to all clients that have an admin URL to invalidate the sessions for the particular user.
  /// Operation: POST /admin/realms/{realm}/users/{user-id}/logout
  /// </summary>
  public async Task PostAdminRealmsUsersLogoutAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/logout".BuildUrl(pathParams);

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
  /// Get offline sessions associated with the user and client
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/offline-sessions/{clientUuid}
  /// </summary>
  public async Task<List<UserSessionRepresentation>> GetAsync(string clientUuid, string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["clientUuid"] = clientUuid,
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/offline-sessions/{clientUuid}".BuildUrl(pathParams);

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
    List<UserSessionRepresentation>? result = JsonSerializer.Deserialize<List<UserSessionRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<UserSessionRepresentation>();
  }


  /// <summary>
  /// Set up a new password for the user.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/reset-password
  /// </summary>
  public async Task PutUsersAsync(string realm, string userId, Apigen.Keycloak.Admin.Models.CredentialRepresentation credentialRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/reset-password".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(credentialRepresentation, JsonConfig.Default);
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
  /// Send an email to the user with a link they can click to reset their password.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/reset-password-email
  /// </summary>
  public async Task PutAdminRealmsUsersResetPasswordEmailAsync(string realm, string userId, PutUsersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/reset-password-email".BuildUrl(pathParams, request);

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
  /// Send an email-verification email to the user An email contains a link the user can click to verify their email address.
  /// Operation: PUT /admin/realms/{realm}/users/{user-id}/send-verify-email
  /// </summary>
  public async Task PutAdminRealmsUsersSendVerifyEmailAsync(string realm, string userId, PutUsersRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/send-verify-email".BuildUrl(pathParams, request);

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
  /// Get sessions associated with the user
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/sessions
  /// </summary>
  public async Task<List<UserSessionRepresentation>> GetAdminRealmsUsersSessionsAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/sessions".BuildUrl(pathParams);

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
    List<UserSessionRepresentation>? result = JsonSerializer.Deserialize<List<UserSessionRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<UserSessionRepresentation>();
  }


  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/users/{user-id}/unmanagedAttributes
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsUsersUnmanagedAttributesAsync(string realm, string userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["user-id"] = userId
    };
    string url = "realms/{realm}/users/{user-id}/unmanagedAttributes".BuildUrl(pathParams);

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
