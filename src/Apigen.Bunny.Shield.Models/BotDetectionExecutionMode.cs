using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = LogOnly
/// 1 = Challenge
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BotDetectionExecutionMode
{
    LogOnly = 0,
    Challenge = 1,
}
