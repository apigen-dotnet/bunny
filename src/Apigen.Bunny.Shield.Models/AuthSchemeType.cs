using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// The type of security scheme as defined in the OpenAPI specification.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AuthSchemeType
{
    [JsonStringEnumMemberName("ApiKey")]
    ApiKey,
    [JsonStringEnumMemberName("Http")]
    Http,
    [JsonStringEnumMemberName("OAuth2")]
    OAuth2,
    [JsonStringEnumMemberName("OpenIdConnect")]
    OpenIdConnect,
}
