using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Cache
/// 1 = LoadBalancer
/// 2 = PreCache
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<ExecutionPhase>))]
public enum ExecutionPhase
{
    Cache = 0,
    LoadBalancer = 1,
    PreCache = 2,
}
