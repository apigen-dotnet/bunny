using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = MatchAny
/// 1 = MatchAll
/// 2 = MatchNone
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<TriggerMatchingTypes>))]
public enum TriggerMatchingTypes
{
    MatchAny = 0,
    MatchAll = 1,
    MatchNone = 2,
}
