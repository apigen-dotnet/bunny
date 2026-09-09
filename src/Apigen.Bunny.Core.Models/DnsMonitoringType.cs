using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = None
/// 1 = Ping
/// 2 = Http
/// 3 = Monitor
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<DnsMonitoringType>))]
public enum DnsMonitoringType
{
    None = 0,
    Ping = 1,
    Http = 2,
    Monitor = 3,
}
