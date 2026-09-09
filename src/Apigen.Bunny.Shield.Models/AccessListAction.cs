using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = None
/// 1 = Allow
/// 2 = Block
/// 3 = Challenge
/// 4 = Log
/// 5 = Bypass
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<AccessListAction>))]
public enum AccessListAction
{
    None = 0,
    Allow = 1,
    Block = 2,
    Challenge = 3,
    Log = 4,
    Bypass = 5,
}
