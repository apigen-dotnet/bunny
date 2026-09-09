using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = NotSupported
/// 1 = Supported
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<StorageZoneS3Type>))]
public enum StorageZoneS3Type
{
    NotSupported = 0,
    Supported = 1,
}
