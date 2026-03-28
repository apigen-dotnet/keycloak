using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apigen.Keycloak.Admin.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Main API client for accessing all resources
/// </summary>
public class KeycloakAdminClient
{
  private readonly HttpClient _httpClient;
  private readonly bool _disposeHttpClient;
  private readonly ILogger? _logger;

  /// <summary>
  /// Client for Realms Admin operations
  /// </summary>
  public RealmsAdminClient RealmsAdmin { get; }

  /// <summary>
  /// Client for Attack Detection operations
  /// </summary>
  public AttackDetectionClient AttackDetection { get; }

  /// <summary>
  /// Client for Authentication Management operations
  /// </summary>
  public AuthenticationManagementClient AuthenticationManagement { get; }

  /// <summary>
  /// Client for Client Registration Policy operations
  /// </summary>
  public ClientRegistrationPolicyClient ClientRegistrationPolicy { get; }

  /// <summary>
  /// Client for Client Scopes operations
  /// </summary>
  public ClientScopesClient ClientScopes { get; }

  /// <summary>
  /// Client for Protocol Mappers operations
  /// </summary>
  public ProtocolMappersClient ProtocolMappers { get; }

  /// <summary>
  /// Client for Scope Mappings operations
  /// </summary>
  public ScopeMappingsClient ScopeMappings { get; }

  /// <summary>
  /// Client for Clients operations
  /// </summary>
  public ClientsClient Clients { get; }

  /// <summary>
  /// Client for Client Initial Access operations
  /// </summary>
  public ClientInitialAccessClient ClientInitialAccess { get; }

  /// <summary>
  /// Client for Client Attribute Certificate operations
  /// </summary>
  public ClientAttributeCertificateClient ClientAttributeCertificate { get; }

  /// <summary>
  /// Client for Roles operations
  /// </summary>
  public RolesClient Roles { get; }

  /// <summary>
  /// Client for Component operations
  /// </summary>
  public ComponentClient Component { get; }

  /// <summary>
  /// Client for Groups operations
  /// </summary>
  public GroupsClient Groups { get; }

  /// <summary>
  /// Client for Role Mapper operations
  /// </summary>
  public RoleMapperClient RoleMapper { get; }

  /// <summary>
  /// Client for Client Role Mappings operations
  /// </summary>
  public ClientRoleMappingsClient ClientRoleMappings { get; }

  /// <summary>
  /// Client for Identity Providers operations
  /// </summary>
  public IdentityProvidersClient IdentityProviders { get; }

  /// <summary>
  /// Client for Key operations
  /// </summary>
  public KeyClient Key { get; }

  /// <summary>
  /// Client for Organizations operations
  /// </summary>
  public OrganizationsClient Organizations { get; }

  /// <summary>
  /// Client for Roles (by ID) operations
  /// </summary>
  public RolesByIdClient RolesById { get; }

  /// <summary>
  /// Client for Users operations
  /// </summary>
  public UsersClient Users { get; }

  /// <summary>
  /// Client for Workflows operations
  /// </summary>
  public WorkflowsClient Workflows { get; }

  /// <summary>
  /// Initialize client with a pre-configured HttpClient
  /// </summary>
  /// <param name="httpClient">Pre-configured HttpClient with base address, auth headers, etc.</param>
  /// <param name="logger">Optional logger for request/response logging</param>
  public KeycloakAdminClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _disposeHttpClient = false;
    _logger = logger;

    RealmsAdmin = new RealmsAdminClient(_httpClient, _logger);
    AttackDetection = new AttackDetectionClient(_httpClient, _logger);
    AuthenticationManagement = new AuthenticationManagementClient(_httpClient, _logger);
    ClientRegistrationPolicy = new ClientRegistrationPolicyClient(_httpClient, _logger);
    ClientScopes = new ClientScopesClient(_httpClient, _logger);
    ProtocolMappers = new ProtocolMappersClient(_httpClient, _logger);
    ScopeMappings = new ScopeMappingsClient(_httpClient, _logger);
    Clients = new ClientsClient(_httpClient, _logger);
    ClientInitialAccess = new ClientInitialAccessClient(_httpClient, _logger);
    ClientAttributeCertificate = new ClientAttributeCertificateClient(_httpClient, _logger);
    Roles = new RolesClient(_httpClient, _logger);
    Component = new ComponentClient(_httpClient, _logger);
    Groups = new GroupsClient(_httpClient, _logger);
    RoleMapper = new RoleMapperClient(_httpClient, _logger);
    ClientRoleMappings = new ClientRoleMappingsClient(_httpClient, _logger);
    IdentityProviders = new IdentityProvidersClient(_httpClient, _logger);
    Key = new KeyClient(_httpClient, _logger);
    Organizations = new OrganizationsClient(_httpClient, _logger);
    RolesById = new RolesByIdClient(_httpClient, _logger);
    Users = new UsersClient(_httpClient, _logger);
    Workflows = new WorkflowsClient(_httpClient, _logger);
  }

  private KeycloakAdminClient(HttpClient httpClient, bool disposeHttpClient, ILogger? logger)
  {
    _httpClient = httpClient;
    _disposeHttpClient = disposeHttpClient;
    _logger = logger;

    RealmsAdmin = new RealmsAdminClient(_httpClient, _logger);
    AttackDetection = new AttackDetectionClient(_httpClient, _logger);
    AuthenticationManagement = new AuthenticationManagementClient(_httpClient, _logger);
    ClientRegistrationPolicy = new ClientRegistrationPolicyClient(_httpClient, _logger);
    ClientScopes = new ClientScopesClient(_httpClient, _logger);
    ProtocolMappers = new ProtocolMappersClient(_httpClient, _logger);
    ScopeMappings = new ScopeMappingsClient(_httpClient, _logger);
    Clients = new ClientsClient(_httpClient, _logger);
    ClientInitialAccess = new ClientInitialAccessClient(_httpClient, _logger);
    ClientAttributeCertificate = new ClientAttributeCertificateClient(_httpClient, _logger);
    Roles = new RolesClient(_httpClient, _logger);
    Component = new ComponentClient(_httpClient, _logger);
    Groups = new GroupsClient(_httpClient, _logger);
    RoleMapper = new RoleMapperClient(_httpClient, _logger);
    ClientRoleMappings = new ClientRoleMappingsClient(_httpClient, _logger);
    IdentityProviders = new IdentityProvidersClient(_httpClient, _logger);
    Key = new KeyClient(_httpClient, _logger);
    Organizations = new OrganizationsClient(_httpClient, _logger);
    RolesById = new RolesByIdClient(_httpClient, _logger);
    Users = new UsersClient(_httpClient, _logger);
    Workflows = new WorkflowsClient(_httpClient, _logger);
  }

  private static HttpClient CreateTokenAuthHttpClient(string apiToken, string baseUrl, string headerName, bool useBearer)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    if (useBearer)
    {
      client.DefaultRequestHeaders.Add(headerName, $"Bearer {apiToken}");
    }
    else
    {
      client.DefaultRequestHeaders.Add(headerName, apiToken);
    }

    return client;
  }

  private static HttpClient CreateBasicAuthHttpClient(string username, string password, string baseUrl)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    string credentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{username}:{password}"));
    client.DefaultRequestHeaders.Add("Authorization", $"Basic {credentials}");

    return client;
  }

  private static HttpClient CreateCookieAuthHttpClient(string token, string cookieName, string baseUrl)
  {
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    System.Net.CookieContainer cookies = new();
    cookies.Add(new Uri(normalizedBaseUrl), new System.Net.Cookie(cookieName, token));
    HttpClientHandler handler = new() { CookieContainer = cookies };
    HttpClient client = new(handler) { BaseAddress = new Uri(normalizedBaseUrl) };

    return client;
  }

  /// <summary>
  /// Dispose resources
  /// </summary>
  public void Dispose()
  {
    if (_disposeHttpClient)
    {
      _httpClient?.Dispose();
    }
  }
}
