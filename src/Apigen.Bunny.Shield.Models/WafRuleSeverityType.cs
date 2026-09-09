using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = NOTICE
/// 1 = WARNING
/// 2 = CRITICAL
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<WafRuleSeverityType>))]
public enum WafRuleSeverityType
{
    Notice = 0,
    Warning = 1,
    Critical = 2,
}
