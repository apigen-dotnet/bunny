using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DataGranularity
{
    [JsonStringEnumMemberName("Daily")]
    Daily,
    [JsonStringEnumMemberName("Hourly")]
    Hourly,
    [JsonStringEnumMemberName("Minute")]
    Minute,
}
