using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = BEGINSWITH
/// 1 = ENDSWITH
/// 2 = CONTAINS
/// 3 = CONTAINSWORD
/// 4 = STRMATCH
/// 5 = EQ
/// 6 = GE
/// 7 = GT
/// 8 = LE
/// 9 = LT
/// 12 = WITHIN
/// 14 = RX
/// 15 = STREQ
/// 17 = DETECTSQLI
/// 18 = DETECTXSS
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<WafRuleOperatorType>))]
public enum WafRuleOperatorType
{
    Beginswith = 0,
    Endswith = 1,
    Contains = 2,
    Containsword = 3,
    Strmatch = 4,
    EQ = 5,
    GE = 6,
    GT = 7,
    LE = 8,
    LT = 9,
    Within = 12,
    RX = 14,
    Streq = 15,
    Detectsqli = 17,
    Detectxss = 18,
}
