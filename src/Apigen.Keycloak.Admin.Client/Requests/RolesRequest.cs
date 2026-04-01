using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Get all roles for the realm or client
/// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/roles
/// </summary>
public class RolesRequest : BaseRequest
{
  /// <summary>
  /// briefRepresentation
  /// </summary>
  [JsonPropertyName("briefRepresentation")]
  public bool? BriefRepresentation { get; set; }

  /// <summary>
  /// first
  /// </summary>
  [JsonPropertyName("first")]
  public int? First { get; set; }

  /// <summary>
  /// max
  /// </summary>
  [JsonPropertyName("max")]
  public int? Max { get; set; }

  /// <summary>
  /// search
  /// </summary>
  [JsonPropertyName("search")]
  public string? Search { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (BriefRepresentation != null)
      queryParams["briefRepresentation"] = BriefRepresentation;
    if (First != null)
      queryParams["first"] = First;
    if (Max != null)
      queryParams["max"] = Max;
    if (Search != null)
      queryParams["search"] = Search;

    return queryParams.ToQueryString();
  }
}
