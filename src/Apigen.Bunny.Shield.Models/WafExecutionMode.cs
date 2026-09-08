using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = Log
/// 1 = Block
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WafExecutionMode
{
    Log = 0,
    Block = 1,
}
