using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Premium
/// 1 = Volume
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<PullZoneType>))]
public enum PullZoneType
{
    Premium = 0,
    Volume = 1,
}
