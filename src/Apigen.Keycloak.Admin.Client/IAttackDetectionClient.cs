using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Attack Detection operations
/// </summary>
public interface IAttackDetectionClient
{
  /// <summary>
  /// Clear any user login failures for all users This can release temporary disabled users
  /// Operation: DELETE /admin/realms/{realm}/attack-detection/brute-force/users
  /// </summary>
  Task DeleteAttackDetectionAsync(string realm);

  /// <summary>
  /// Get status of a username in brute force detection
  /// Operation: GET /admin/realms/{realm}/attack-detection/brute-force/users/{userId}
  /// </summary>
  Task<JsonElement> GetAsync(string userId, string realm);

  /// <summary>
  /// Clear any user login failures for the user This can release temporary disabled user
  /// Operation: DELETE /admin/realms/{realm}/attack-detection/brute-force/users/{userId}
  /// </summary>
  Task DeleteAsync(string userId, string realm);

}
