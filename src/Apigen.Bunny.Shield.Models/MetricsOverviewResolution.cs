using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = Auto
/// 1 = TwoMinutes
/// 2 = TenMinutes
/// 3 = Hourly
/// 4 = Daily
/// 5 = Weekly
/// 6 = Monthly
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<MetricsOverviewResolution>))]
public enum MetricsOverviewResolution
{
    Auto = 0,
    TwoMinutes = 1,
    TenMinutes = 2,
    Hourly = 3,
    Daily = 4,
    Weekly = 5,
    Monthly = 6,
}
