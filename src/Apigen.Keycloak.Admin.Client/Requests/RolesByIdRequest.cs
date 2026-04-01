using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Get role's children Returns a set of role's children provided the role is a composite.
/// Operation: GET /admin/realms/{realm}/roles-by-id/{role-id}/composites
/// </summary>
public class RolesByIdRequest : BaseRequest
{
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

    if (First != null)
      queryParams["first"] = First;
    if (Max != null)
      queryParams["max"] = Max;
    if (Search != null)
      queryParams["search"] = Search;

    return queryParams.ToQueryString();
  }
}
