using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = None
/// 1 = L1
/// 2 = L2
/// 3 = L3
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<WidevineMinClientSecurityLevel>))]
public enum WidevineMinClientSecurityLevel
{
    None = 0,
    L1 = 1,
    L2 = 2,
    L3 = 3,
}
