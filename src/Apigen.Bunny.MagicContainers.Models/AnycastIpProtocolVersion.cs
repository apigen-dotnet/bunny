using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AnycastIpProtocolVersion
{
    [JsonStringEnumMemberName("iPv4")]
    IPv4,
}
