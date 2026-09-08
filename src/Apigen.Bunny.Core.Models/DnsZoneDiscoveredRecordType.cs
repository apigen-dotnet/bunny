using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = A
/// 1 = AAAA
/// 2 = CNAME
/// 3 = TXT
/// 4 = MX
/// 8 = SRV
/// 9 = CAA
/// 10 = PTR
/// 12 = NS
/// 13 = Svcb
/// 14 = HTTPS
/// 15 = TLSA
/// 16 = SOA
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DnsZoneDiscoveredRecordType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
    __4 = 4,
    __8 = 8,
    __9 = 9,
    __10 = 10,
    __12 = 12,
    __13 = 13,
    __14 = 14,
    __15 = 15,
    __16 = 16,
}
