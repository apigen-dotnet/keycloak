using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    [JsonStringEnumMemberName("PENDING")]
    PENDING,
    [JsonStringEnumMemberName("EXPIRED")]
    EXPIRED,
}
