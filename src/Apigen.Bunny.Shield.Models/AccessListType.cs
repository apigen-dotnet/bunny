using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = IP
/// 1 = CIDR
/// 2 = ASN
/// 3 = Country
/// 4 = Organization
/// 5 = JA4
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<AccessListType>))]
public enum AccessListType
{
    IP = 0,
    Cidr = 1,
    Asn = 2,
    Country = 3,
    Organization = 4,
    JA4 = 5,
}
