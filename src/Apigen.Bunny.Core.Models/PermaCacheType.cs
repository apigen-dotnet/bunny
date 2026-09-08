using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Automatic
/// 1 = Manual
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PermaCacheType
{
    __0 = 0,
    __1 = 1,
}
