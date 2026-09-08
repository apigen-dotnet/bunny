using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = OriginUrl
/// 1 = DnsAccelerate
/// 2 = StorageZone
/// 3 = LoadBalancer
/// 4 = EdgeScript
/// 5 = MagicContainers
/// 6 = PushZone
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PullZoneOriginType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
    __4 = 4,
    __5 = 5,
    __6 = 6,
}
