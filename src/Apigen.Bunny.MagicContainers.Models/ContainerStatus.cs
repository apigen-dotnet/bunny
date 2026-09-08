using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContainerStatus
{
    [JsonStringEnumMemberName("notStarted")]
    NotStarted,
    [JsonStringEnumMemberName("started")]
    Started,
    [JsonStringEnumMemberName("ready")]
    Ready,
}
