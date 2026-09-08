using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = ForceSSL
/// 1 = Redirect
/// 2 = OriginUrl
/// 3 = OverrideCacheTime
/// 4 = BlockRequest
/// 5 = SetResponseHeader
/// 6 = SetRequestHeader
/// 7 = ForceDownload
/// 8 = DisableTokenAuthentication
/// 9 = EnableTokenAuthentication
/// 10 = OverrideCacheTimePublic
/// 11 = IgnoreQueryString
/// 12 = DisableOptimizer
/// 13 = ForceCompression
/// 14 = SetStatusCode
/// 15 = BypassPermaCache
/// 16 = OverrideBrowserCacheTime
/// 17 = OriginStorage
/// 18 = SetNetworkRateLimit
/// 19 = SetConnectionLimit
/// 20 = SetRequestsPerSecondLimit
/// 21 = RunEdgeScript
/// 22 = OriginMagicContainers
/// 23 = DisableWAF
/// 24 = RetryOrigin
/// 25 = OverrideBrowserCacheResponseHeader
/// 26 = RemoveBrowserCacheResponseHeader
/// 27 = DisableShieldChallenge
/// 28 = DisableShield
/// 29 = DisableShieldBotDetection
/// 30 = BypassAwsS3Authentication
/// 31 = DisableShieldAccessLists
/// 32 = DisableShieldRateLimiting
/// 33 = EnableRequestCoalescing
/// 34 = DisableRequestCoalescing
/// 37 = StripCookiesClientToOrigin
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EdgeRuleActionType
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
    __14 = 14,
    __15 = 15,
    __16 = 16,
    __17 = 17,
    __18 = 18,
    __19 = 19,
    __20 = 20,
    __21 = 21,
    __22 = 22,
    __23 = 23,
    __24 = 24,
    __25 = 25,
    __26 = 26,
    __27 = 27,
    __28 = 28,
    __29 = 29,
    __30 = 30,
    __31 = 31,
    __32 = 32,
    __33 = 33,
    __34 = 34,
    __37 = 37,
}
