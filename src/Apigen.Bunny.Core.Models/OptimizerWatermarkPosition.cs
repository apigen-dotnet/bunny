using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = BottomLeft
/// 1 = BottomRight
/// 2 = TopLeft
/// 3 = TopRight
/// 4 = Center
/// 5 = CenterStretch
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OptimizerWatermarkPosition
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
    __4 = 4,
    __5 = 5,
}
