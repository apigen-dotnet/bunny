using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = DetectOnly
/// 1 = ActiveStandard
/// 2 = ActiveAggressive
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ShieldDDosProtectionType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
}
