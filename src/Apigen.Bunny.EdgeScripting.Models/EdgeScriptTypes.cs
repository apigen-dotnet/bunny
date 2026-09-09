using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.EdgeScripting.Models;

/// <summary>
/// 0 = DNS
/// 1 = CDN
/// 2 = Middleware
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<EdgeScriptTypes>))]
public enum EdgeScriptTypes
{
    Dns = 0,
    Cdn = 1,
    Middleware = 2,
}
