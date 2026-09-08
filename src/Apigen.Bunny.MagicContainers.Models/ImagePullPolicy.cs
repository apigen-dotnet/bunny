using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ImagePullPolicy
{
    [JsonStringEnumMemberName("always")]
    Always,
    [JsonStringEnumMemberName("ifNotPresent")]
    IfNotPresent,
}
