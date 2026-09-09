using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Off
/// 1 = Simple
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<OptimizerHtmlToMarkdownType>))]
public enum OptimizerHtmlToMarkdownType
{
    Off = 0,
    Simple = 1,
}
