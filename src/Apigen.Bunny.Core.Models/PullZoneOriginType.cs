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
[JsonConverter(typeof(JsonNumberEnumConverter<PullZoneOriginType>))]
public enum PullZoneOriginType
{
    OriginUrl = 0,
    DnsAccelerate = 1,
    StorageZone = 2,
    LoadBalancer = 3,
    EdgeScript = 4,
    MagicContainers = 5,
    PushZone = 6,
}
