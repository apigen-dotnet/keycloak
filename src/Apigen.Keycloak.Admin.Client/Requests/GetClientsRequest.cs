using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Get clients belonging to the realm.
/// Operation: GET /admin/realms/{realm}/clients
/// </summary>
public class GetClientsRequest : BaseRequest
{
  /// <summary>
  /// filter by clientId
  /// </summary>
  [JsonPropertyName("clientId")]
  public string? ClientId { get; set; }

  /// <summary>
  /// the first result
  /// </summary>
  [JsonPropertyName("first")]
  public int? First { get; set; }

  /// <summary>
  /// the max results to return
  /// </summary>
  [JsonPropertyName("max")]
  public int? Max { get; set; }

  /// <summary>
  /// q
  /// </summary>
  [JsonPropertyName("q")]
  public string? Q { get; set; }

  /// <summary>
  /// whether this is a search query or a getClientById query
  /// </summary>
  [JsonPropertyName("search")]
  public bool? Search { get; set; }

  /// <summary>
  /// filter clients that cannot be viewed in full by admin
  /// </summary>
  [JsonPropertyName("viewableOnly")]
  public bool? ViewableOnly { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (ClientId != null)
      queryParams["clientId"] = ClientId;
    if (First != null)
      queryParams["first"] = First;
    if (Max != null)
      queryParams["max"] = Max;
    if (Q != null)
      queryParams["q"] = Q;
    if (Search != null)
      queryParams["search"] = Search;
    if (ViewableOnly != null)
      queryParams["viewableOnly"] = ViewableOnly;

    return queryParams.ToQueryString();
  }
}
