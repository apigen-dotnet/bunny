using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Grade
{
    [JsonStringEnumMemberName("couldBeBetter")]
    CouldBeBetter,
    [JsonStringEnumMemberName("notBad")]
    NotBad,
    [JsonStringEnumMemberName("doingGreat")]
    DoingGreat,
}
