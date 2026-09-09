using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Light
/// 1 = Dark
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<PreloadingScreenTheme>))]
public enum PreloadingScreenTheme
{
    Light = 0,
    Dark = 1,
}
