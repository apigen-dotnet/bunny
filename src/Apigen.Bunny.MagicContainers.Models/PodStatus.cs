using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PodStatus
{
    [JsonStringEnumMemberName("notScheduled")]
    NotScheduled,
    [JsonStringEnumMemberName("scheduled")]
    Scheduled,
    [JsonStringEnumMemberName("ready")]
    Ready,
    [JsonStringEnumMemberName("deleting")]
    Deleting,
}
