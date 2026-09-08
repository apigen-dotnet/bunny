using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VolumeStatus
{
    [JsonStringEnumMemberName("unknown")]
    Unknown,
    [JsonStringEnumMemberName("attached")]
    Attached,
    [JsonStringEnumMemberName("detached")]
    Detached,
    [JsonStringEnumMemberName("extending")]
    Extending,
    [JsonStringEnumMemberName("deleting")]
    Deleting,
    [JsonStringEnumMemberName("creating")]
    Creating,
    [JsonStringEnumMemberName("notScheduled")]
    NotScheduled,
    [JsonStringEnumMemberName("scheduled")]
    Scheduled,
    [JsonStringEnumMemberName("failed")]
    Failed,
    [JsonStringEnumMemberName("maintenance")]
    Maintenance,
}
