using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Request parameters for Get users Returns a stream of users, filtered according to query parameters.
/// Operation: GET /admin/realms/{realm}/users
/// </summary>
public class UsersRequest : BaseRequest
{
  /// <summary>
  /// Boolean which defines whether brief representations are returned (default: false)
  /// </summary>
  [JsonPropertyName("briefRepresentation")]
  public bool? BriefRepresentation { get; set; }

  /// <summary>
  /// A String contained in email, or the complete email, if param &quot;exact&quot; is true
  /// </summary>
  [JsonPropertyName("email")]
  public string? Email { get; set; }

  /// <summary>
  /// whether the email has been verified
  /// </summary>
  [JsonPropertyName("emailVerified")]
  public bool? EmailVerified { get; set; }

  /// <summary>
  /// Boolean representing if user is enabled or not
  /// </summary>
  [JsonPropertyName("enabled")]
  public bool? Enabled { get; set; }

  /// <summary>
  /// Boolean which defines whether the params &quot;last&quot;, &quot;first&quot;, &quot;email&quot; and &quot;username&quot; must match exactly
  /// </summary>
  [JsonPropertyName("exact")]
  public bool? Exact { get; set; }

  /// <summary>
  /// Pagination offset
  /// </summary>
  [JsonPropertyName("first")]
  public int? First { get; set; }

  /// <summary>
  /// A String contained in firstName, or the complete firstName, if param &quot;exact&quot; is true
  /// </summary>
  [JsonPropertyName("firstName")]
  public string? FirstName { get; set; }

  /// <summary>
  /// The alias of an Identity Provider linked to the user
  /// </summary>
  [JsonPropertyName("idpAlias")]
  public string? IdpAlias { get; set; }

  /// <summary>
  /// The userId at an Identity Provider linked to the user
  /// </summary>
  [JsonPropertyName("idpUserId")]
  public string? IdpUserId { get; set; }

  /// <summary>
  /// A String contained in lastName, or the complete lastName, if param &quot;exact&quot; is true
  /// </summary>
  [JsonPropertyName("lastName")]
  public string? LastName { get; set; }

  /// <summary>
  /// Maximum results size (defaults to 100)
  /// </summary>
  [JsonPropertyName("max")]
  public int? Max { get; set; }

  /// <summary>
  /// A query to search for custom attributes, in the format &apos;key1:value2 key2:value2&apos;
  /// </summary>
  [JsonPropertyName("q")]
  public string? Q { get; set; }

  /// <summary>
  /// A String contained in username, first or last name, or email. Default search behavior is prefix-based (e.g., foo or foo*). Use *foo* for infix search and &quot;foo&quot; for exact search.
  /// </summary>
  [JsonPropertyName("search")]
  public string? Search { get; set; }

  /// <summary>
  /// A String contained in username, or the complete username, if param &quot;exact&quot; is true
  /// </summary>
  [JsonPropertyName("username")]
  public string? Username { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (BriefRepresentation != null)
      queryParams["briefRepresentation"] = BriefRepresentation;
    if (Email != null)
      queryParams["email"] = Email;
    if (EmailVerified != null)
      queryParams["emailVerified"] = EmailVerified;
    if (Enabled != null)
      queryParams["enabled"] = Enabled;
    if (Exact != null)
      queryParams["exact"] = Exact;
    if (First != null)
      queryParams["first"] = First;
    if (FirstName != null)
      queryParams["firstName"] = FirstName;
    if (IdpAlias != null)
      queryParams["idpAlias"] = IdpAlias;
    if (IdpUserId != null)
      queryParams["idpUserId"] = IdpUserId;
    if (LastName != null)
      queryParams["lastName"] = LastName;
    if (Max != null)
      queryParams["max"] = Max;
    if (Q != null)
      queryParams["q"] = Q;
    if (Search != null)
      queryParams["search"] = Search;
    if (Username != null)
      queryParams["username"] = Username;

    return queryParams.ToQueryString();
  }
}
