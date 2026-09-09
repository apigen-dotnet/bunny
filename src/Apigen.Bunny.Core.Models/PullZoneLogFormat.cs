using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Plain
/// 1 = JSON
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<PullZoneLogFormat>))]
public enum PullZoneLogFormat
{
    Plain = 0,
    Json = 1,
}
