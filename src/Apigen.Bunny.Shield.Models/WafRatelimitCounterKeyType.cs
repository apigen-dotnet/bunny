using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = IP
/// 1 = Host
/// 2 = Country
/// 3 = City
/// 4 = ASN
/// 5 = Organization
/// 6 = JA4
/// 7 = IP_JA4
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WafRatelimitCounterKeyType
{
    IP = 0,
    Host = 1,
    Country = 2,
    City = 3,
    Asn = 4,
    Organization = 5,
    JA4 = 6,
    IPJA4 = 7,
}
