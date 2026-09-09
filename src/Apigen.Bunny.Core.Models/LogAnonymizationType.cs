using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = OneDigit
/// 1 = Drop
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<LogAnonymizationType>))]
public enum LogAnonymizationType
{
    OneDigit = 0,
    Drop = 1,
}
