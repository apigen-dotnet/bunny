using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RemoveContainerRegistryResponseStatus
{
    [JsonStringEnumMemberName("notFound")]
    NotFound,
    [JsonStringEnumMemberName("inUse")]
    InUse,
    [JsonStringEnumMemberName("removed")]
    Removed,
}
