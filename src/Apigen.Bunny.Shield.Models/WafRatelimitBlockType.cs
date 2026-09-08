using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 30 = ForThirtySeconds
/// 60 = ForOneMinute
/// 300 = ForFiveMinutes
/// 900 = ForFifteenMinutes
/// 1800 = ForThirtyMinutes
/// 3600 = ForOneHour
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WafRatelimitBlockType
{
    ForThirtySeconds = 30,
    ForOneMinute = 60,
    ForFiveMinutes = 300,
    ForFifteenMinutes = 900,
    ForThirtyMinutes = 1800,
    ForOneHour = 3600,
}
