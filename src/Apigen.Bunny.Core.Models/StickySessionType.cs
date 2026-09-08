using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Off
/// 1 = On
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StickySessionType
{
    __0 = 0,
    __1 = 1,
}
