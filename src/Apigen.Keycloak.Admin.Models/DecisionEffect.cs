using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DecisionEffect
{
    [JsonStringEnumMemberName("PERMIT")]
    PERMIT,
    [JsonStringEnumMemberName("DENY")]
    DENY,
}
