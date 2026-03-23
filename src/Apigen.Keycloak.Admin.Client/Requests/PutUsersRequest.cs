using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Send an email to the user with a link they can click to execute particular actions.
/// Operation: PUT /admin/realms/{realm}/users/{user-id}/execute-actions-email
/// </summary>
public class PutUsersRequest : BaseRequest
{
  /// <summary>
  /// Client id
  /// </summary>
  [JsonPropertyName("client_id")]
  public string? ClientId { get; set; }

  /// <summary>
  /// Number of seconds after which the generated token expires
  /// </summary>
  [JsonPropertyName("lifespan")]
  public int? Lifespan { get; set; }

  /// <summary>
  /// Redirect uri
  /// </summary>
  [JsonPropertyName("redirect_uri")]
  public string? RedirectUri { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (ClientId != null)
      queryParams["client_id"] = ClientId;
    if (Lifespan != null)
      queryParams["lifespan"] = Lifespan;
    if (RedirectUri != null)
      queryParams["redirect_uri"] = RedirectUri;

    return queryParams.ToQueryString();
  }
}
