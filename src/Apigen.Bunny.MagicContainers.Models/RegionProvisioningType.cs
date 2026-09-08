using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RegionProvisioningType
{
    [JsonStringEnumMemberName("static")]
    Static,
    [JsonStringEnumMemberName("dynamic")]
    Dynamic,
}
