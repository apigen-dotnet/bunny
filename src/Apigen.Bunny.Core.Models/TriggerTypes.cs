using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = Url
/// 1 = RequestHeader
/// 2 = ResponseHeader
/// 3 = UrlExtension
/// 4 = CountryCode
/// 5 = RemoteIP
/// 6 = UrlQueryString
/// 7 = RandomChance
/// 8 = StatusCode
/// 9 = RequestMethod
/// 10 = CookieValue
/// 11 = CountryStateCode
/// 12 = OriginRetryAttemptCount
/// 13 = OriginConnectionError
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<TriggerTypes>))]
public enum TriggerTypes
{
    Url = 0,
    RequestHeader = 1,
    ResponseHeader = 2,
    UrlExtension = 3,
    CountryCode = 4,
    RemoteIP = 5,
    UrlQueryString = 6,
    RandomChance = 7,
    StatusCode = 8,
    RequestMethod = 9,
    CookieValue = 10,
    CountryStateCode = 11,
    OriginRetryAttemptCount = 12,
    OriginConnectionError = 13,
}
