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
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AcceleratedStatus
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
    __4 = 4,
}
