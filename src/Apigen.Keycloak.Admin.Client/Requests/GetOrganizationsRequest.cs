using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Returns a paginated list of organizations filtered according to the specified parameters
/// Operation: GET /admin/realms/{realm}/organizations
/// </summary>
public class GetOrganizationsRequest : BaseRequest
{
  /// <summary>
  /// if false, return the full representation. Otherwise, only the basic fields are returned.
  /// </summary>
  [JsonPropertyName("briefRepresentation")]
  public bool? BriefRepresentation { get; set; }

  /// <summary>
  /// Boolean which defines whether the param &apos;search&apos; must match exactly or not
  /// </summary>
  [JsonPropertyName("exact")]
  public bool? Exact { get; set; }

  /// <summary>
  /// The position of the first result to be processed (pagination offset)
  /// </summary>
  [JsonPropertyName("first")]
  public int? First { get; set; }

  /// <summary>
  /// The maximum number of results to be returned - defaults to 10
  /// </summary>
  [JsonPropertyName("max")]
  public int? Max { get; set; }

  /// <summary>
  /// A query to search for custom attributes, in the format &apos;key1:value2 key2:value2&apos;
  /// </summary>
  [JsonPropertyName("q")]
  public string? Q { get; set; }

  /// <summary>
  /// A String representing either an organization name or domain
  /// </summary>
  [JsonPropertyName("search")]
  public string? Search { get; set; }

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
    if (Q != null)
      queryParams["q"] = Q;
    if (Search != null)
      queryParams["search"] = Search;

    return queryParams.ToQueryString();
  }
}
