using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Premium
/// 1 = Volume
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PullZoneType
{
    __0 = 0,
    __1 = 1,
}
