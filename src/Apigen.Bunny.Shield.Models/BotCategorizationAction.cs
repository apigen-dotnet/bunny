using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = None
/// 1 = Block
/// 2 = Allow
/// 3 = Ignore
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BotCategorizationAction
{
    None = 0,
    Block = 1,
    Allow = 2,
    Ignore = 3,
}
