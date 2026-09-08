using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = None
/// 1 = Block
/// 2 = Allow
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BotCategoryAction
{
    None = 0,
    Block = 1,
    Allow = 2,
}
