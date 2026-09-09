using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.EdgeScripting.Models;

/// <summary>
/// 0 = Archived
/// 1 = Live
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<EdgeScriptReleaseStatus>))]
public enum EdgeScriptReleaseStatus
{
    Archived = 0,
    Live = 1,
}
