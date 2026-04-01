using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for List identity providers
/// Operation: GET /admin/realms/{realm}/identity-provider/instances
/// </summary>
public class IdentityProvidersRequest : BaseRequest
{
  /// <summary>
  /// Boolean which defines whether brief representations are returned (default: false)
  /// </summary>
  [JsonPropertyName("briefRepresentation")]
  public bool? BriefRepresentation { get; set; }

  /// <summary>
  /// Filter by identity providers capability
  /// </summary>
  [JsonPropertyName("capability")]
  public string? Capability { get; set; }

  /// <summary>
  /// Pagination offset
  /// </summary>
  [JsonPropertyName("first")]
  public int? First { get; set; }

  /// <summary>
  /// Maximum results size (defaults to 100)
  /// </summary>
  [JsonPropertyName("max")]
  public int? Max { get; set; }

  /// <summary>
  /// Boolean which defines if only realm-level IDPs (not associated with orgs) should be returned (default: false)
  /// </summary>
  [JsonPropertyName("realmOnly")]
  public bool? RealmOnly { get; set; }

  /// <summary>
  /// Filter specific providers by name. Search can be prefix (name*), contains (*name*) or exact (&quot;name&quot;). Default prefixed.
  /// </summary>
  [JsonPropertyName("search")]
  public string? Search { get; set; }

  /// <summary>
  /// Filter by identity providers type
  /// </summary>
  [JsonPropertyName("type")]
  public string? Type { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (BriefRepresentation != null)
      queryParams["briefRepresentation"] = BriefRepresentation;
    if (Capability != null)
      queryParams["capability"] = Capability;
    if (First != null)
      queryParams["first"] = First;
    if (Max != null)
      queryParams["max"] = Max;
    if (RealmOnly != null)
      queryParams["realmOnly"] = RealmOnly;
    if (Search != null)
      queryParams["search"] = Search;
    if (Type != null)
      queryParams["type"] = Type;

    return queryParams.ToQueryString();
  }
}
