using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ScopeEnforcementMode
{
    [JsonStringEnumMemberName("ALL")]
    ALL,
    [JsonStringEnumMemberName("ANY")]
    ANY,
    [JsonStringEnumMemberName("DISABLED")]
    DISABLED,
}
