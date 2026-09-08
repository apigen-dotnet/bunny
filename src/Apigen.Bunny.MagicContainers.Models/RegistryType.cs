using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RegistryType
{
    [JsonStringEnumMemberName("dockerHub")]
    DockerHub,
    [JsonStringEnumMemberName("gitHub")]
    GitHub,
    [JsonStringEnumMemberName("bunnyRegistry")]
    BunnyRegistry,
}
