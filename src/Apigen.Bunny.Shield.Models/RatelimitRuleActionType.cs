using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 1 = RateLimit
/// 2 = Log
/// 3 = Challenge
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<RatelimitRuleActionType>))]
public enum RatelimitRuleActionType
{
    RateLimit = 1,
    Log = 2,
    Challenge = 3,
}
