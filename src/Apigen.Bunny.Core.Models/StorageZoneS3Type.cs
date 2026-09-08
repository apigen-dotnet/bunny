using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = NotSupported
/// 1 = Supported
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StorageZoneS3Type
{
    __0 = 0,
    __1 = 1,
}
