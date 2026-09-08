using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiGuardianRateLimitType
{
    [JsonStringEnumMemberName("Global")]
    Global,
    [JsonStringEnumMemberName("IP")]
    IP,
}
