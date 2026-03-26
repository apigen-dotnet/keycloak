using System;
using System.Text.Json.Serialization;

namespace Apigen.Keycloak.Admin.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UnmanagedAttributePolicy
{
    [JsonStringEnumMemberName("ENABLED")]
    Enabled,
    [JsonStringEnumMemberName("ADMIN_VIEW")]
    AdminView,
    [JsonStringEnumMemberName("ADMIN_EDIT")]
    AdminEdit,
}
