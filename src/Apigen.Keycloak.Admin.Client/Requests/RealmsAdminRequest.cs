using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Get accessible realms Returns a list of accessible realms. The list is filtered based on what realms the caller is allowed to view.
/// Operation: GET /admin/realms
/// </summary>
public class RealmsAdminRequest : BaseRequest
{
  /// <summary>
  /// briefRepresentation
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
