using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.EdgeScripting.Models;

/// <summary>
/// 0 = Archived
/// 1 = Live
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EdgeScriptReleaseStatus
{
    __0 = 0,
    __1 = 1,
}
