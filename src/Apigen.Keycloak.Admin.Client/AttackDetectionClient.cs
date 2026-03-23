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
/// Client for Attack Detection operations
/// </summary>
public class AttackDetectionClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal AttackDetectionClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Clear any user login failures for all users This can release temporary disabled users
  /// Operation: DELETE /admin/realms/{realm}/attack-detection/brute-force/users
  /// </summary>
  public async Task DeleteAttackDetectionAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/attack-detection/brute-force/users".BuildUrl(pathParams);

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
  /// Get status of a username in brute force detection
  /// Operation: GET /admin/realms/{realm}/attack-detection/brute-force/users/{userId}
  /// </summary>
  public async Task<JsonElement> GetAsync(string userId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["userId"] = userId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/attack-detection/brute-force/users/{userId}".BuildUrl(pathParams);

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
  /// Clear any user login failures for the user This can release temporary disabled user
  /// Operation: DELETE /admin/realms/{realm}/attack-detection/brute-force/users/{userId}
  /// </summary>
  public async Task DeleteAsync(string userId, string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["userId"] = userId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/attack-detection/brute-force/users/{userId}".BuildUrl(pathParams);

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
