using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Activate workflow for resource
/// Operation: POST /admin/realms/{realm}/workflows/{id}/activate/{type}/{resourceId}
/// </summary>
public class PostWorkflowsRequest : BaseRequest
{
  /// <summary>
  /// Optional value representing the time to schedule the first workflow step. The value is either an integer representing the seconds from now, an integer followed by &apos;ms&apos; representing milliseconds from now, or an ISO-8601 date string.
  /// </summary>
  [JsonPropertyName("notBefore")]
  public string? NotBefore { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (NotBefore != null)
      queryParams["notBefore"] = NotBefore;

    return queryParams.ToQueryString();
  }
}
