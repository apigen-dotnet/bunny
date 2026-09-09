using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Unknown
/// 1 = Online
/// 2 = Offline
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<DnsMonitoringStatus>))]
public enum DnsMonitoringStatus
{
    Unknown = 0,
    Online = 1,
    Offline = 2,
}
