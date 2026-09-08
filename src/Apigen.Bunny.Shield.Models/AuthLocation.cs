using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// Where an authentication credential is transmitted in the HTTP request.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AuthLocation
{
    [JsonStringEnumMemberName("Header")]
    Header,
    [JsonStringEnumMemberName("Query")]
    Query,
    [JsonStringEnumMemberName("Cookie")]
    Cookie,
}
