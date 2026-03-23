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
/// Client for Client Registration Policy operations
/// </summary>
public class ClientRegistrationPolicyClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ClientRegistrationPolicyClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Base path for retrieve providers with the configProperties properly filled
  /// Operation: GET /admin/realms/{realm}/client-registration-policy/providers
  /// </summary>
  public async Task<List<ComponentTypeRepresentation>> GetClientRegistrationPolicyAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/client-registration-policy/providers".BuildUrl(pathParams);

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
    List<ComponentTypeRepresentation>? result = JsonSerializer.Deserialize<List<ComponentTypeRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<ComponentTypeRepresentation>();
  }


}
