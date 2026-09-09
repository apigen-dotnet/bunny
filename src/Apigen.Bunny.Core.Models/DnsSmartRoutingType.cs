using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = None
/// 1 = Latency
/// 2 = Geolocation
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<DnsSmartRoutingType>))]
public enum DnsSmartRoutingType
{
    None = 0,
    Latency = 1,
    Geolocation = 2,
}
