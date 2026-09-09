using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = None
/// 1 = Pending
/// 2 = Processing
/// 3 = Completed
/// 4 = Failed
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<AcceleratedStatus>))]
public enum AcceleratedStatus
{
    None = 0,
    Pending = 1,
    Processing = 2,
    Completed = 3,
    Failed = 4,
}
