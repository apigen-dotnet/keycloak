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
/// Client for Client Attribute Certificate operations
/// </summary>
public class ClientAttributeCertificateClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ClientAttributeCertificateClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get key info
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}
  /// </summary>
  public async Task<CertificateRepresentation> GetAsync(string realm, string clientUuid, string attr)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["attr"] = attr
    };
    string url = "realms/{realm}/clients/{client-uuid}/certificates/{attr}".BuildUrl(pathParams);

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
    CertificateRepresentation? result = JsonSerializer.Deserialize<CertificateRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new CertificateRepresentation();
  }


  /// <summary>
  /// Get a keystore file for the client, containing private key and public certificate
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/download
  /// </summary>
  public async Task<Stream> PostClientAttributeCertificateAsync(string realm, string clientUuid, string attr, Apigen.Keycloak.Admin.Models.KeyStoreConfig keyStoreConfig)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["attr"] = attr
    };
    string url = "realms/{realm}/clients/{client-uuid}/certificates/{attr}/download".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(keyStoreConfig, JsonConfig.Default);
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
      string errorContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, errorContent, ex);
      throw;
    }
    return await response.Content.ReadAsStreamAsync();
  }


  /// <summary>
  /// Generate a new certificate with new key pair
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/generate
  /// </summary>
  public async Task<CertificateRepresentation> PostClientAttributeCertificateAsync(string realm, string clientUuid, string attr)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["attr"] = attr
    };
    string url = "realms/{realm}/clients/{client-uuid}/certificates/{attr}/generate".BuildUrl(pathParams);

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
    CertificateRepresentation? result = JsonSerializer.Deserialize<CertificateRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new CertificateRepresentation();
  }


  /// <summary>
  /// Generate a new keypair and certificate, and get the private key file
  /// 
  /// Generates a keypair and certificate and serves the private key in a specified keystore format.
  /// Only generated public certificate is saved in Keycloak DB - the private key is not.
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/generate-and-download
  /// </summary>
  public async Task<Stream> PostAdminRealmsClientsCertificatesGenerateAndDownloadAsync(string realm, string clientUuid, string attr, Apigen.Keycloak.Admin.Models.KeyStoreConfig keyStoreConfig)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["attr"] = attr
    };
    string url = "realms/{realm}/clients/{client-uuid}/certificates/{attr}/generate-and-download".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(keyStoreConfig, JsonConfig.Default);
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
      string errorContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, errorContent, ex);
      throw;
    }
    return await response.Content.ReadAsStreamAsync();
  }


  /// <summary>
  /// Upload certificate and eventually private key
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/upload
  /// </summary>
  public async Task<CertificateRepresentation> PostAdminRealmsClientsCertificatesUploadAsync(string realm, string clientUuid, string attr)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["attr"] = attr
    };
    string url = "realms/{realm}/clients/{client-uuid}/certificates/{attr}/upload".BuildUrl(pathParams);

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
    CertificateRepresentation? result = JsonSerializer.Deserialize<CertificateRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new CertificateRepresentation();
  }


  /// <summary>
  /// Upload only certificate, not private key
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/upload-certificate
  /// </summary>
  public async Task<CertificateRepresentation> PostAdminRealmsClientsCertificatesUploadCertificateAsync(string realm, string clientUuid, string attr)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["client-uuid"] = clientUuid,
      ["attr"] = attr
    };
    string url = "realms/{realm}/clients/{client-uuid}/certificates/{attr}/upload-certificate".BuildUrl(pathParams);

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
    CertificateRepresentation? result = JsonSerializer.Deserialize<CertificateRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new CertificateRepresentation();
  }


  /// <summary>
  /// Uploads a certificate, prepares the jwks or public key associated, and returns the certificate representation.
  /// Operation: POST /admin/realms/{realm}/identity-provider/upload-certificate
  /// </summary>
  public async Task<CertificateRepresentation> PostClientAttributeCertificateAsync(string realm)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/identity-provider/upload-certificate".BuildUrl(pathParams);

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
    CertificateRepresentation? result = JsonSerializer.Deserialize<CertificateRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new CertificateRepresentation();
  }


}
