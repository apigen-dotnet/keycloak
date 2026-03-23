using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DecisionStrategy
{
    [JsonStringEnumMemberName("AFFIRMATIVE")]
    AFFIRMATIVE,
    [JsonStringEnumMemberName("UNANIMOUS")]
    UNANIMOUS,
    [JsonStringEnumMemberName("CONSENSUS")]
    CONSENSUS,
}
