using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Cache
/// 1 = LoadBalancer
/// 2 = PreCache
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ExecutionPhase
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
}
