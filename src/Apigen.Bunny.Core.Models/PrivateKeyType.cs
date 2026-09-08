using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Ecdsa
/// 1 = Rsa
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PrivateKeyType
{
    __0 = 0,
    __1 = 1,
}
