using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.MagicContainers.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SavedContainerRegistryStatus
{
    [JsonStringEnumMemberName("saved")]
    Saved,
    [JsonStringEnumMemberName("secretsValidationFailed")]
    SecretsValidationFailed,
    [JsonStringEnumMemberName("unknownErrorOccured")]
    UnknownErrorOccured,
    [JsonStringEnumMemberName("notFound")]
    NotFound,
    [JsonStringEnumMemberName("invalidInput")]
    InvalidInput,
}
