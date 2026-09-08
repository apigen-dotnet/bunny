using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Unknown
/// 1 = Online
/// 2 = Offline
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DnsMonitoringStatus
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
}
