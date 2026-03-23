using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EnforcementMode
{
    [JsonStringEnumMemberName("PERMISSIVE")]
    PERMISSIVE,
    [JsonStringEnumMemberName("ENFORCING")]
    ENFORCING,
    [JsonStringEnumMemberName("DISABLED")]
    DISABLED,
}
