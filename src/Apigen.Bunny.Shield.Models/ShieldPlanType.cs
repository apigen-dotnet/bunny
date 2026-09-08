using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = Basic
/// 1 = Advanced
/// 2 = Business
/// 3 = Enterprise
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ShieldPlanType
{
    Basic = 0,
    Advanced = 1,
    Business = 2,
    Enterprise = 3,
}
