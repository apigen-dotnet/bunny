using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = DetectOnly
/// 1 = ActiveStandard
/// 2 = ActiveAggressive
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<ShieldDDosProtectionType>))]
public enum ShieldDDosProtectionType
{
    DetectOnly = 0,
    ActiveStandard = 1,
    ActiveAggressive = 2,
}
