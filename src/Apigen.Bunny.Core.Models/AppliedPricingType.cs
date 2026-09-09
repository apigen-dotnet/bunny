using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = ListPrice
/// 1 = UserOverride
/// 2 = ResourceOverride
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<AppliedPricingType>))]
public enum AppliedPricingType
{
    ListPrice = 0,
    UserOverride = 1,
    ResourceOverride = 2,
}
