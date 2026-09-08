using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApplicationRuntimeType
{
    [JsonStringEnumMemberName("shared")]
    Shared,
    [JsonStringEnumMemberName("reserved")]
    Reserved,
}
