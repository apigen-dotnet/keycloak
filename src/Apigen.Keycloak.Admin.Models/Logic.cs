using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Logic
{
    [JsonStringEnumMemberName("POSITIVE")]
    POSITIVE,
    [JsonStringEnumMemberName("NEGATIVE")]
    NEGATIVE,
}
