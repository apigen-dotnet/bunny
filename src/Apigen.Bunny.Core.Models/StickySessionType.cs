using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Off
/// 1 = On
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<StickySessionType>))]
public enum StickySessionType
{
    Off = 0,
    On = 1,
}
