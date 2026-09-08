using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = ListPrice
/// 1 = UserOverride
/// 2 = ResourceOverride
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AppliedPricingType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
}
