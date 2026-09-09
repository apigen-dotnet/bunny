using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = IPv4Only
/// 1 = DualStack
/// 2 = DualStackPreferIPv6
/// 3 = IPv6Only
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<IpFamilyPolicy>))]
public enum IpFamilyPolicy
{
    IPv4Only = 0,
    DualStack = 1,
    DualStackPreferIPv6 = 2,
    IPv6Only = 3,
}
