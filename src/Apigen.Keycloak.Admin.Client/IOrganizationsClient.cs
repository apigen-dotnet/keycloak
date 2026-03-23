using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Organizations operations
/// </summary>
public interface IOrganizationsClient
{
  /// <summary>
  /// Returns a paginated list of organizations filtered according to the specified parameters
  /// Operation: GET /admin/realms/{realm}/organizations
  /// </summary>
  Task<List<OrganizationRepresentation>> GetOrganizationsAsync(string realm, GetOrganizationsRequest? request = null);

  /// <summary>
  /// Creates a new organization
  /// Operation: POST /admin/realms/{realm}/organizations
  /// </summary>
  Task PostOrganizationsAsync(string realm, Apigen.Keycloak.Admin.Models.OrganizationRepresentation organizationRepresentation);

  /// <summary>
  /// Returns the organizations counts.
  /// Operation: GET /admin/realms/{realm}/organizations/count
  /// </summary>
  Task<JsonElement> GetAdminRealmsOrganizationsCountAsync(string realm, GetOrganizationsRequest? request = null);

  /// <summary>
  /// Returns the organizations associated with the user that has the specified id
  /// Operation: GET /admin/realms/{realm}/organizations/members/{member-id}/organizations
  /// </summary>
  Task<List<OrganizationRepresentation>> GetOrganizationsAsync(string memberId, string realm, GetOrganizationsRequest? request = null);

  /// <summary>
  /// Returns the organization representation
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}
  /// </summary>
  Task<OrganizationRepresentation> GetAsync(string realm, string orgId);

  /// <summary>
  /// Updates the organization
  /// Operation: PUT /admin/realms/{realm}/organizations/{org-id}
  /// </summary>
  Task UpdateAsync(string realm, string orgId, Apigen.Keycloak.Admin.Models.OrganizationRepresentation organizationRepresentation);

  /// <summary>
  /// Deletes the organization
  /// Operation: DELETE /admin/realms/{realm}/organizations/{org-id}
  /// </summary>
  Task DeleteAsync(string realm, string orgId);

  /// <summary>
  /// Returns all identity providers associated with the organization
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/identity-providers
  /// </summary>
  Task<List<IdentityProviderRepresentation>> GetOrganizationsAsync(string realm, string orgId);

  /// <summary>
  /// Adds the identity provider with the specified id to the organization
  /// Operation: POST /admin/realms/{realm}/organizations/{org-id}/identity-providers
  /// </summary>
  Task PostOrganizationsAsync(string realm, string orgId);

  /// <summary>
  /// Returns the identity provider associated with the organization that has the specified alias
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/identity-providers/{alias}
  /// </summary>
  Task<IdentityProviderRepresentation> GetAsync(string alias, string realm, string orgId);

  /// <summary>
  /// Removes the identity provider with the specified alias from the organization
  /// Operation: DELETE /admin/realms/{realm}/organizations/{org-id}/identity-providers/{alias}
  /// </summary>
  Task DeleteAsync(string alias, string realm, string orgId);

  /// <summary>
  /// Returns a paginated list of organization members filtered according to the specified parameters
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/members
  /// </summary>
  Task<List<MemberRepresentation>> GetAdminRealmsOrganizationsMembersAsync(string realm, string orgId, GetOrganizationsRequest? request = null);

  /// <summary>
  /// Adds the user with the specified id as a member of the organization
  /// Operation: POST /admin/realms/{realm}/organizations/{org-id}/members
  /// </summary>
  Task PostAdminRealmsOrganizationsMembersAsync(string realm, string orgId);

  /// <summary>
  /// Returns number of members in the organization.
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/members/count
  /// </summary>
  Task<JsonElement> GetAdminRealmsOrganizationsMembersCountAsync(string realm, string orgId);

  /// <summary>
  /// Invites an existing user to the organization, using the specified user id
  /// Operation: POST /admin/realms/{realm}/organizations/{org-id}/members/invite-existing-user
  /// </summary>
  Task PostAdminRealmsOrganizationsMembersInviteExistingUserAsync(string realm, string orgId);

  /// <summary>
  /// Invites an existing user or sends a registration link to a new user, based on the provided e-mail address.
  /// Operation: POST /admin/realms/{realm}/organizations/{org-id}/members/invite-user
  /// </summary>
  Task PostAdminRealmsOrganizationsMembersInviteUserAsync(string realm, string orgId);

  /// <summary>
  /// Returns the member of the organization with the specified id
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/members/{member-id}
  /// </summary>
  Task<MemberRepresentation> GetAdminRealmsOrganizationsMembersAsync(string memberId, string realm, string orgId);

  /// <summary>
  /// Removes the user with the specified id from the organization
  /// Operation: DELETE /admin/realms/{realm}/organizations/{org-id}/members/{member-id}
  /// </summary>
  Task DeleteAdminRealmsOrganizationsMembersAsync(string memberId, string realm, string orgId);

  /// <summary>
  /// Returns the organizations associated with the user that has the specified id
  /// Operation: GET /admin/realms/{realm}/organizations/{org-id}/members/{member-id}/organizations
  /// </summary>
  Task<List<OrganizationRepresentation>> GetOrganizationsAsync(string memberId, string realm, string orgId, GetOrganizationsRequest? request = null);

}
