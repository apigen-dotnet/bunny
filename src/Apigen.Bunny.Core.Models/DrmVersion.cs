using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Basic
/// 1 = Enterprise
/// 2 = BasicV2
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<DrmVersion>))]
public enum DrmVersion
{
    Basic = 0,
    Enterprise = 1,
    BasicV2 = 2,
}
