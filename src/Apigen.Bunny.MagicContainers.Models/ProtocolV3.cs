using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProtocolV3
{
    [JsonStringEnumMemberName("tcp")]
    Tcp,
    [JsonStringEnumMemberName("udp")]
    Udp,
    [JsonStringEnumMemberName("sctp")]
    Sctp,
}
