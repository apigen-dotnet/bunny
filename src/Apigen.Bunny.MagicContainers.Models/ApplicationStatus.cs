using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApplicationStatus
{
    [JsonStringEnumMemberName("unknown")]
    Unknown,
    [JsonStringEnumMemberName("active")]
    Active,
    [JsonStringEnumMemberName("progressing")]
    Progressing,
    [JsonStringEnumMemberName("inactive")]
    Inactive,
    [JsonStringEnumMemberName("failing")]
    Failing,
    [JsonStringEnumMemberName("suspended")]
    Suspended,
}
