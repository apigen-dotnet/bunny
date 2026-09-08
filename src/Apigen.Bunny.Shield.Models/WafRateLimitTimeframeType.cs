using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 1 = PerSecond
/// 10 = PerTenSeconds
/// 60 = PerOneMinute
/// 300 = PerFiveMinutes
/// 900 = PerFifteenMinutes
/// 3600 = PerOneHour
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WafRateLimitTimeframeType
{
    PerSecond = 1,
    PerTenSeconds = 10,
    PerOneMinute = 60,
    PerFiveMinutes = 300,
    PerFifteenMinutes = 900,
    PerOneHour = 3600,
}
