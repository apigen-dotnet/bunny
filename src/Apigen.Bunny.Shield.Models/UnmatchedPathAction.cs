using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = Block
/// 1 = Log
/// 2 = Ignore
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UnmatchedPathAction
{
    Block = 0,
    Log = 1,
    Ignore = 2,
}
