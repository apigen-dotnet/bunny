using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = OneDigit
/// 1 = Drop
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LogAnonymizationType
{
    __0 = 0,
    __1 = 1,
}
