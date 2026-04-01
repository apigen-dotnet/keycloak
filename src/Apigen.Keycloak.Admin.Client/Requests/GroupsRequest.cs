using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Get group hierarchy.  Only `name` and `id` are returned.  `subGroups` are only returned when using the `search` or `q` parameter. If none of these parameters is provided, the top-level groups are returned without `subGroups` being filled.
/// Operation: GET /admin/realms/{realm}/groups
/// </summary>
public class GroupsRequest : BaseRequest
{
  /// <summary>
  /// briefRepresentation
  /// </summary>
  [JsonPropertyName("briefRepresentation")]
  public bool? BriefRepresentation { get; set; }

  /// <summary>
  /// exact
  /// </summary>
  [JsonPropertyName("exact")]
  public bool? Exact { get; set; }

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
  /// populateHierarchy
  /// </summary>
  [JsonPropertyName("populateHierarchy")]
  public bool? PopulateHierarchy { get; set; }

  /// <summary>
  /// q
  /// </summary>
  [JsonPropertyName("q")]
  public string? Q { get; set; }

  /// <summary>
  /// search
  /// </summary>
  [JsonPropertyName("search")]
  public string? Search { get; set; }

  /// <summary>
  /// Boolean which defines whether to return the count of subgroups for each group (default: true
  /// </summary>
  [JsonPropertyName("subGroupsCount")]
  public bool? SubGroupsCount { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (BriefRepresentation != null)
      queryParams["briefRepresentation"] = BriefRepresentation;
    if (Exact != null)
      queryParams["exact"] = Exact;
    if (First != null)
      queryParams["first"] = First;
    if (Max != null)
      queryParams["max"] = Max;
    if (PopulateHierarchy != null)
      queryParams["populateHierarchy"] = PopulateHierarchy;
    if (Q != null)
      queryParams["q"] = Q;
    if (Search != null)
      queryParams["search"] = Search;
    if (SubGroupsCount != null)
      queryParams["subGroupsCount"] = SubGroupsCount;

    return queryParams.ToQueryString();
  }
}
