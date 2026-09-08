using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Standard
/// 1 = Edge
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StorageZoneTier
{
    __0 = 0,
    __1 = 1,
}
