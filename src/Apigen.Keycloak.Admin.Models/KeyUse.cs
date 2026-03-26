using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum KeyUse
{
    [JsonStringEnumMemberName("SIG")]
    Sig,
    [JsonStringEnumMemberName("ENC")]
    Enc,
    [JsonStringEnumMemberName("JWT_SVID")]
    JwtSvid,
}
