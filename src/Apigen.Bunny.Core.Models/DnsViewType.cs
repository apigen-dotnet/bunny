using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Full
/// 1 = Lite
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<DnsViewType>))]
public enum DnsViewType
{
    Full = 0,
    Lite = 1,
}
