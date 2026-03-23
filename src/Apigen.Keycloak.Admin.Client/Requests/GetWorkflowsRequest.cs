using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for List workflows
/// Operation: GET /admin/realms/{realm}/workflows
/// </summary>
public class GetWorkflowsRequest : BaseRequest
{
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
  /// A String representing the workflow name - either partial or exact
  /// </summary>
  [JsonPropertyName("search")]
  public string? Search { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Exact != null)
      queryParams["exact"] = Exact;
    if (First != null)
      queryParams["first"] = First;
    if (Max != null)
      queryParams["max"] = Max;
    if (Search != null)
      queryParams["search"] = Search;

    return queryParams.ToQueryString();
  }
}
