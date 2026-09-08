using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EndpointType
{
    [JsonStringEnumMemberName("cdn")]
    Cdn,
    [JsonStringEnumMemberName("anycast")]
    Anycast,
    [JsonStringEnumMemberName("publicIp")]
    PublicIp,
}
