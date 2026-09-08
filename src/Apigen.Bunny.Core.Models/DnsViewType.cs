using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Full
/// 1 = Lite
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DnsViewType
{
    __0 = 0,
    __1 = 1,
}
