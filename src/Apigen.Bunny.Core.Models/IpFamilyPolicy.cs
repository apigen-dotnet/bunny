using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = IPv4Only
/// 1 = DualStack
/// 2 = DualStackPreferIPv6
/// 3 = IPv6Only
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum IpFamilyPolicy
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
}
