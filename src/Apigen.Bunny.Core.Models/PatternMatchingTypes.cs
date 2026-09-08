using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = MatchAny
/// 1 = MatchAll
/// 2 = MatchNone
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PatternMatchingTypes
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
}
