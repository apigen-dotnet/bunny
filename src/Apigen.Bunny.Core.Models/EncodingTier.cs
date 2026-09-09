using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Free
/// 1 = Premium
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<EncodingTier>))]
public enum EncodingTier
{
    Free = 0,
    Premium = 1,
}
