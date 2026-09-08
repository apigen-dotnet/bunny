using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Free
/// 1 = Premium
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EncodingTier
{
    __0 = 0,
    __1 = 1,
}
