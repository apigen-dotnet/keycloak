using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DecisionStrategy
{
    [JsonStringEnumMemberName("AFFIRMATIVE")]
    Affirmative,
    [JsonStringEnumMemberName("UNANIMOUS")]
    Unanimous,
    [JsonStringEnumMemberName("CONSENSUS")]
    Consensus,
}
