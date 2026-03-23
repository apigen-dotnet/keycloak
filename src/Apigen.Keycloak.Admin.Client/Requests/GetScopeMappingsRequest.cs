using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Get effective client roles Returns the roles for the client that are associated with the client's scope.
/// Operation: GET /admin/realms/{realm}/client-scopes/{client-scope-id}/scope-mappings/clients/{client}/composite
/// </summary>
public class GetScopeMappingsRequest : BaseRequest
{
  /// <summary>
  /// if false, return roles with their attributes
  /// </summary>
  [JsonPropertyName("briefRepresentation")]
  public bool? BriefRepresentation { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (BriefRepresentation != null)
      queryParams["briefRepresentation"] = BriefRepresentation;

    return queryParams.ToQueryString();
  }
}
