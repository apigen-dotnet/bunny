using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Basic
/// 1 = Enterprise
/// 2 = BasicV2
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DrmVersion
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
}
