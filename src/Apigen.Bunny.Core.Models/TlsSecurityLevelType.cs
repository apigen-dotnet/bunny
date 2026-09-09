using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Legacy
/// 1 = Compatible
/// 2 = ModernOnly
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<TlsSecurityLevelType>))]
public enum TlsSecurityLevelType
{
    Legacy = 0,
    Compatible = 1,
    ModernOnly = 2,
}
