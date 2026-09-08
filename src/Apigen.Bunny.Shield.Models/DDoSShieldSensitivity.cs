using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = Off
/// 1 = Low
/// 2 = Medium
/// 3 = High
/// 4 = Challenge
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DDoSShieldSensitivity
{
    Off = 0,
    Low = 1,
    Medium = 2,
    High = 3,
    Challenge = 4,
}
