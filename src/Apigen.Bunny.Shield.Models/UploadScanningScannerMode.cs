using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = Disabled
/// 1 = Log
/// 2 = Block
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UploadScanningScannerMode
{
    Disabled = 0,
    Log = 1,
    Block = 2,
}
