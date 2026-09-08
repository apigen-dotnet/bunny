using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Light
/// 1 = Dark
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PreloadingScreenTheme
{
    __0 = 0,
    __1 = 1,
}
