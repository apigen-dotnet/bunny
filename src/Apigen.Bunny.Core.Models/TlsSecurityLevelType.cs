using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Legacy
/// 1 = Compatible
/// 2 = ModernOnly
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TlsSecurityLevelType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
}
