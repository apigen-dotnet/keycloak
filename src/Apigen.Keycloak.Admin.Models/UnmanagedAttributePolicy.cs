using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UnmanagedAttributePolicy
{
    [JsonStringEnumMemberName("ENABLED")]
    ENABLED,
    [JsonStringEnumMemberName("ADMIN_VIEW")]
    ADMINVIEW,
    [JsonStringEnumMemberName("ADMIN_EDIT")]
    ADMINEDIT,
}
