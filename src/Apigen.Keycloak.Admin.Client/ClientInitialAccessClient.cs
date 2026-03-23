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
/// Client for Client Initial Access operations
/// </summary>
public class ClientInitialAccessClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ClientInitialAccessClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// 
  /// Operation: GET /admin/realms/{realm}/clients-initial-access
  /// </summary>
  public async Task<List<ClientInitialAccessPresentation>> GetClientInitialAccessAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/clients-initial-access".BuildUrl(pathParams);

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
    List<ClientInitialAccessPresentation>? result = JsonSerializer.Deserialize<List<ClientInitialAccessPresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ClientInitialAccessPresentation>();
  }


  /// <summary>
  /// Create a new initial access token.
  /// Operation: POST /admin/realms/{realm}/clients-initial-access
  /// </summary>
  public async Task<ClientInitialAccessCreatePresentation> PostClientInitialAccessAsync(string realm, Apigen.Keycloak.Admin.Models.ClientInitialAccessCreatePresentation clientInitialAccessCreatePresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/clients-initial-access".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(clientInitialAccessCreatePresentation, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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
    ClientInitialAccessCreatePresentation? result = JsonSerializer.Deserialize<ClientInitialAccessCreatePresentation>(responseContent, JsonConfig.Default);
    return result ?? new ClientInitialAccessCreatePresentation();
  }


  /// <summary>
  /// 
  /// Operation: DELETE /admin/realms/{realm}/clients-initial-access/{id}
  /// </summary>
  public async Task DeleteAsync(string id, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm
    };
    string url = "realms/{realm}/clients-initial-access/{id}".BuildUrl(pathParams);

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


}
