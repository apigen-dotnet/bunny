using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 1 = Block
/// 2 = Log
/// 3 = Challenge
/// 4 = Allow
/// 5 = Bypass
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<WafRuleActionType>))]
public enum WafRuleActionType
{
    Block = 1,
    Log = 2,
    Challenge = 3,
    Allow = 4,
    Bypass = 5,
}
