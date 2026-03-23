using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Partial export of existing realm into a JSON file.
/// Operation: POST /admin/realms/{realm}/partial-export
/// </summary>
public class PostRealmsAdminRequest : BaseRequest
{
  /// <summary>
  /// exportClients
  /// </summary>
  [JsonPropertyName("exportClients")]
  public bool? ExportClients { get; set; }

  /// <summary>
  /// exportGroupsAndRoles
  /// </summary>
  [JsonPropertyName("exportGroupsAndRoles")]
  public bool? ExportGroupsAndRoles { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (ExportClients != null)
      queryParams["exportClients"] = ExportClients;
    if (ExportGroupsAndRoles != null)
      queryParams["exportGroupsAndRoles"] = ExportGroupsAndRoles;

    return queryParams.ToQueryString();
  }
}
