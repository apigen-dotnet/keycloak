using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /admin/realms/{realm}/components
/// </summary>
public class ComponentRequest : BaseRequest
{
  /// <summary>
  /// name
  /// </summary>
  [JsonPropertyName("name")]
  public string? Name { get; set; }

  /// <summary>
  /// parent
  /// </summary>
  [JsonPropertyName("parent")]
  public string? Parent { get; set; }

  /// <summary>
  /// type
  /// </summary>
  [JsonPropertyName("type")]
  public string? Type { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Name != null)
      queryParams["name"] = Name;
    if (Parent != null)
      queryParams["parent"] = Parent;
    if (Type != null)
      queryParams["type"] = Type;

    return queryParams.ToQueryString();
  }
}
