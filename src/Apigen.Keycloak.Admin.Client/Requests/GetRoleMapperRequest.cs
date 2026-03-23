using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Get effective realm-level role mappings This will recurse all composite roles to get the result.
/// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/realm/composite
/// </summary>
public class GetRoleMapperRequest : BaseRequest
{
  /// <summary>
  /// if false, return roles with their attributes
  /// </summary>
  [JsonPropertyName("briefRepresentation")]
  public bool? BriefRepresentation { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (BriefRepresentation != null)
      queryParams["briefRepresentation"] = BriefRepresentation;

    return queryParams.ToQueryString();
  }
}
