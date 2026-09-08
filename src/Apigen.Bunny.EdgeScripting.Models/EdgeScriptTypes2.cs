using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.EdgeScripting.Models;

/// <summary>
/// 0 = DNS
/// 1 = CDN
/// 2 = Middleware
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EdgeScriptTypes2
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
}
