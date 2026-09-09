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
[JsonConverter(typeof(JsonNumberEnumConverter<OptimizerWatermarkPosition>))]
public enum OptimizerWatermarkPosition
{
    BottomLeft = 0,
    BottomRight = 1,
    TopLeft = 2,
    TopRight = 3,
    Center = 4,
    CenterStretch = 5,
}
