using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Ecdsa
/// 1 = Rsa
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<PrivateKeyType>))]
public enum PrivateKeyType
{
    Ecdsa = 0,
    Rsa = 1,
}
