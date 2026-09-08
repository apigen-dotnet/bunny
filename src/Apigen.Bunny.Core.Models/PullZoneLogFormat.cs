using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Plain
/// 1 = JSON
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PullZoneLogFormat
{
    __0 = 0,
    __1 = 1,
}
