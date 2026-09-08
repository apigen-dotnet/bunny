using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LogOrdering
{
    [JsonStringEnumMemberName("Ascending")]
    Ascending,
    [JsonStringEnumMemberName("Descending")]
    Descending,
}
