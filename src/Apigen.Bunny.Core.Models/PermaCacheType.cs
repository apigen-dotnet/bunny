using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Automatic
/// 1 = Manual
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<PermaCacheType>))]
public enum PermaCacheType
{
    Automatic = 0,
    Manual = 1,
}
