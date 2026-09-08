using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = None
/// 1 = Latency
/// 2 = Geolocation
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DnsSmartRoutingType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
}
