using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum KeyUse
{
    [JsonStringEnumMemberName("SIG")]
    SIG,
    [JsonStringEnumMemberName("ENC")]
    ENC,
    [JsonStringEnumMemberName("JWT_SVID")]
    JWTSVID,
}
