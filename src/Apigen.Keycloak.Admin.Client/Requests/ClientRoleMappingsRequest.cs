using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Get effective client-level role mappings This recurses any composite roles
/// Operation: GET /admin/realms/{realm}/groups/{group-id}/role-mappings/clients/{client-id}/composite
/// </summary>
public class ClientRoleMappingsRequest : BaseRequest
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
