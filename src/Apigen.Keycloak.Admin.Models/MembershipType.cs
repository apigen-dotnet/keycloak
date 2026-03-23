using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MembershipType
{
    [JsonStringEnumMemberName("UNMANAGED")]
    UNMANAGED,
    [JsonStringEnumMemberName("MANAGED")]
    MANAGED,
}
