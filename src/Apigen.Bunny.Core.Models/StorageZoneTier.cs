using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Standard
/// 1 = Edge
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<StorageZoneTier>))]
public enum StorageZoneTier
{
    Standard = 0,
    Edge = 1,
}
