using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Pending
/// 1 = InProgress
/// 2 = Completed
/// 3 = Failed
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<DnsZoneScanJobStatus>))]
public enum DnsZoneScanJobStatus
{
    Pending = 0,
    InProgress = 1,
    Completed = 2,
    Failed = 3,
}
