using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = None
/// 1 = Ping
/// 2 = Http
/// 3 = Monitor
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DnsMonitoringType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
}
