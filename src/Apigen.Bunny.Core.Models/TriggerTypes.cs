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
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TriggerTypes
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
    __4 = 4,
    __5 = 5,
    __6 = 6,
    __7 = 7,
    __8 = 8,
    __9 = 9,
    __10 = 10,
    __11 = 11,
    __12 = 12,
    __13 = 13,
}
