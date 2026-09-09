using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Unknown
/// 1 = Http01
/// 2 = Dns01
/// 3 = Custom
/// 4 = Managed
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<CertificateProvisionType>))]
public enum CertificateProvisionType
{
    Unknown = 0,
    Http01 = 1,
    Dns01 = 2,
    Custom = 3,
    Managed = 4,
}
