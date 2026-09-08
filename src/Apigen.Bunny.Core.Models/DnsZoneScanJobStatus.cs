using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Pending
/// 1 = InProgress
/// 2 = Completed
/// 3 = Failed
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DnsZoneScanJobStatus
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
}
