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
/// Client for Organizations operations
/// </summary>
public class OrganizationsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal OrganizationsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Returns a paginated list of organizations filtered according to the specified parameters
  /// Operation: GET /admin/realms/{realm}/organizations
  /// </summary>
  public async Task<List<OrganizationRepresentation>> GetOrganizationsAsync(string realm, GetOrganizationsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/organizations".BuildUrl(pathParams, request);

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
    List<OrganizationRepresentation>? result = JsonSerializer.Deserialize<List<OrganizationRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<OrganizationRepresentation>();
  }


  /// <summary>
  /// Creates a new organization
  /// Operation: POST /admin/realms/{realm}/organizations
  /// </summary>
  public async Task PostOrganizationsAsync(string realm, Apigen.Keycloak.Admin.Models.OrganizationRepresentation organizationRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/organizations".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(organizationRepresentation, JsonConfig.Default);
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
  /// Returns the organizations counts.
  /// Operation: GET /admin/realms/{realm}/organizations/count
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsOrganizationsCountAsync(string realm, GetOrganizationsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm
    };
    string url = "realms/{realm}/organizations/count".BuildUrl(pathParams, request);

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
  /// Returns the organizations associated with the user that has the specified id
  /// Operation: GET /admin/realms/{realm}/organizations/members/{member-id}/organizations
  /// </summary>
  public async Task<List<OrganizationRepresentation>> GetOrganizationsAsync(string memberId, string realm, GetOrganizationsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["member-id"] = memberId,
      ["realm"] = realm
    };
    string url = "realms/{realm}/organizations/members/{member-id}/organizations".BuildUrl(pathParams, request);

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
    List<OrganizationRepresentation>? result = JsonSerializer.Deserialize<List<OrganizationRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<OrganizationRepresentation>();
  }


  /// <summary>
  /// Returns the organization representation
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}
  /// </summary>
  public async Task<OrganizationRepresentation> GetAsync(string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}".BuildUrl(pathParams);

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
    OrganizationRepresentation? result = JsonSerializer.Deserialize<OrganizationRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new OrganizationRepresentation();
  }


  /// <summary>
  /// Updates the organization
  /// Operation: PUT /admin/realms/{realm}/organizations/{org-id}
  /// </summary>
  public async Task UpdateAsync(string realm, string orgId, Apigen.Keycloak.Admin.Models.OrganizationRepresentation organizationRepresentation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(organizationRepresentation, JsonConfig.Default);
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
  /// Deletes the organization
  /// Operation: DELETE /admin/realms/{realm}/organizations/{org-id}
  /// </summary>
  public async Task DeleteAsync(string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}".BuildUrl(pathParams);

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
  /// Returns all identity providers associated with the organization
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/identity-providers
  /// </summary>
  public async Task<List<IdentityProviderRepresentation>> GetOrganizationsAsync(string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/identity-providers".BuildUrl(pathParams);

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
    List<IdentityProviderRepresentation>? result = JsonSerializer.Deserialize<List<IdentityProviderRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<IdentityProviderRepresentation>();
  }


  /// <summary>
  /// Adds the identity provider with the specified id to the organization
  /// Operation: POST /admin/realms/{realm}/organizations/{org-id}/identity-providers
  /// </summary>
  public async Task PostOrganizationsAsync(string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/identity-providers".BuildUrl(pathParams);

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
  /// Returns the identity provider associated with the organization that has the specified alias
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/identity-providers/{alias}
  /// </summary>
  public async Task<IdentityProviderRepresentation> GetAsync(string alias, string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/identity-providers/{alias}".BuildUrl(pathParams);

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
    IdentityProviderRepresentation? result = JsonSerializer.Deserialize<IdentityProviderRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new IdentityProviderRepresentation();
  }


  /// <summary>
  /// Removes the identity provider with the specified alias from the organization
  /// Operation: DELETE /admin/realms/{realm}/organizations/{org-id}/identity-providers/{alias}
  /// </summary>
  public async Task DeleteAsync(string alias, string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["alias"] = alias,
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/identity-providers/{alias}".BuildUrl(pathParams);

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
  /// Get invitations for the organization
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/invitations
  /// </summary>
  public async Task<List<OrganizationInvitationRepresentation>> GetAdminRealmsOrganizationsInvitationsAsync(string realm, string orgId, GetOrganizationsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/invitations".BuildUrl(pathParams, request);

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
    List<OrganizationInvitationRepresentation>? result = JsonSerializer.Deserialize<List<OrganizationInvitationRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<OrganizationInvitationRepresentation>();
  }


  /// <summary>
  /// Get invitation by ID
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/invitations/{id}
  /// </summary>
  public async Task<OrganizationInvitationRepresentation> GetAdminRealmsOrganizationsInvitationsAsync(string id, string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/invitations/{id}".BuildUrl(pathParams);

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
    OrganizationInvitationRepresentation? result = JsonSerializer.Deserialize<OrganizationInvitationRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new OrganizationInvitationRepresentation();
  }


  /// <summary>
  /// Delete an invitation
  /// Operation: DELETE /admin/realms/{realm}/organizations/{org-id}/invitations/{id}
  /// </summary>
  public async Task DeleteAdminRealmsOrganizationsInvitationsAsync(string id, string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/invitations/{id}".BuildUrl(pathParams);

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
  /// Resend an invitation
  /// Operation: POST /admin/realms/{realm}/organizations/{org-id}/invitations/{id}/resend
  /// </summary>
  public async Task PostOrganizationsAsync(string id, string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/invitations/{id}/resend".BuildUrl(pathParams);

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
  /// Returns a paginated list of organization members filtered according to the specified parameters
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/members
  /// </summary>
  public async Task<List<MemberRepresentation>> GetAdminRealmsOrganizationsMembersAsync(string realm, string orgId, GetOrganizationsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/members".BuildUrl(pathParams, request);

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
    List<MemberRepresentation>? result = JsonSerializer.Deserialize<List<MemberRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<MemberRepresentation>();
  }


  /// <summary>
  /// Adds the user with the specified id as a member of the organization
  /// Operation: POST /admin/realms/{realm}/organizations/{org-id}/members
  /// </summary>
  public async Task PostAdminRealmsOrganizationsMembersAsync(string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/members".BuildUrl(pathParams);

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
  /// Returns number of members in the organization.
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/members/count
  /// </summary>
  public async Task<JsonElement> GetAdminRealmsOrganizationsMembersCountAsync(string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/members/count".BuildUrl(pathParams);

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
  /// Invites an existing user to the organization, using the specified user id
  /// Operation: POST /admin/realms/{realm}/organizations/{org-id}/members/invite-existing-user
  /// </summary>
  public async Task PostAdminRealmsOrganizationsMembersInviteExistingUserAsync(string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/members/invite-existing-user".BuildUrl(pathParams);

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
  /// Invites an existing user or sends a registration link to a new user, based on the provided e-mail address.
  /// Operation: POST /admin/realms/{realm}/organizations/{org-id}/members/invite-user
  /// </summary>
  public async Task PostAdminRealmsOrganizationsMembersInviteUserAsync(string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/members/invite-user".BuildUrl(pathParams);

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
  /// Returns the member of the organization with the specified id
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/members/{member-id}
  /// </summary>
  public async Task<MemberRepresentation> GetAdminRealmsOrganizationsMembersAsync(string memberId, string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["member-id"] = memberId,
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/members/{member-id}".BuildUrl(pathParams);

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
    MemberRepresentation? result = JsonSerializer.Deserialize<MemberRepresentation>(responseContent, JsonConfig.Default);
    return result ?? new MemberRepresentation();
  }


  /// <summary>
  /// Removes the user with the specified id from the organization
  /// Operation: DELETE /admin/realms/{realm}/organizations/{org-id}/members/{member-id}
  /// </summary>
  public async Task DeleteAdminRealmsOrganizationsMembersAsync(string memberId, string realm, string orgId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["member-id"] = memberId,
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/members/{member-id}".BuildUrl(pathParams);

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
  /// Returns the organizations associated with the user that has the specified id
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/members/{member-id}/organizations
  /// </summary>
  public async Task<List<OrganizationRepresentation>> GetOrganizationsAsync(string memberId, string realm, string orgId, GetOrganizationsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["member-id"] = memberId,
      ["realm"] = realm,
      ["org-id"] = orgId
    };
    string url = "realms/{realm}/organizations/{org-id}/members/{member-id}/organizations".BuildUrl(pathParams, request);

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
    List<OrganizationRepresentation>? result = JsonSerializer.Deserialize<List<OrganizationRepresentation>>(responseContent, JsonConfig.Default);
    return result ?? new List<OrganizationRepresentation>();
  }


}
