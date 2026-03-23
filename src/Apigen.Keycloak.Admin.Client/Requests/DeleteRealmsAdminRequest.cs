using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Remove a specific user session.
/// Operation: DELETE /admin/realms/{realm}/sessions/{session}
/// </summary>
public class DeleteRealmsAdminRequest : BaseRequest
{
  /// <summary>
  /// isOffline
  /// </summary>
  [JsonPropertyName("isOffline")]
  public bool? IsOffline { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (IsOffline != null)
      queryParams["isOffline"] = IsOffline;

    return queryParams.ToQueryString();
  }
}
