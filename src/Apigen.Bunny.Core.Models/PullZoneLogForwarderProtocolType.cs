using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = UDP
/// 1 = TCP
/// 2 = TCPEncrypted
/// 3 = DataDog
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<PullZoneLogForwarderProtocolType>))]
public enum PullZoneLogForwarderProtocolType
{
    Udp = 0,
    Tcp = 1,
    TcpEncrypted = 2,
    DataDog = 3,
}
