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
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CertificateProvisionType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
    __4 = 4,
}
