using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PolicyEnforcementMode
{
    [JsonStringEnumMemberName("ENFORCING")]
    Enforcing,
    [JsonStringEnumMemberName("PERMISSIVE")]
    Permissive,
    [JsonStringEnumMemberName("DISABLED")]
    Disabled,
}
