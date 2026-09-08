using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = Unknown
/// 1 = Low
/// 2 = Medium
/// 3 = High
/// 4 = Custom
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BrowserFingerprintAggression
{
    Unknown = 0,
    Low = 1,
    Medium = 2,
    High = 3,
    Custom = 4,
}
