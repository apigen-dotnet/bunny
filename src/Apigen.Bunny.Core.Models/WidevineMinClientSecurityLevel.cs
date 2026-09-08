using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = None
/// 1 = L1
/// 2 = L2
/// 3 = L3
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WidevineMinClientSecurityLevel
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
}
