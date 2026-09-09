using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = Ignore
/// 1 = LogOnly
/// 2 = DisableRule
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<ReviewActionType>))]
public enum ReviewActionType
{
    Ignore = 0,
    LogOnly = 1,
    DisableRule = 2,
}
