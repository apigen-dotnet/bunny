using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = UDP
/// 1 = TCP
/// 2 = TCPEncrypted
/// 3 = DataDog
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PullZoneLogForwarderProtocolType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
}
