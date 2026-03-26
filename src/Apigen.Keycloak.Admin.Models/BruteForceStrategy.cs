using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BruteForceStrategy
{
    [JsonStringEnumMemberName("LINEAR")]
    Linear,
    [JsonStringEnumMemberName("MULTIPLE")]
    Multiple,
}
