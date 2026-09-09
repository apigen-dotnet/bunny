using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = None
/// 1 = VPNs
/// 2 = Datacenters
/// 4 = Proxies
/// 8 = TorExitNodes
/// 16 = Botnets
/// 32 = VulnerabilityScanners
/// 64 = WebScrapers
/// 128 = SearchEngines
/// 256 = SearchEngineCrawlers
/// 512 = AiSearch
/// 1024 = AiCrawlers
/// 2048 = AiAgents
/// 4096 = PagePreview
/// 8192 = InternetTools
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<AccessListCategory>))]
public enum AccessListCategory
{
    None = 0,
    VPNs = 1,
    Datacenters = 2,
    Proxies = 4,
    TorExitNodes = 8,
    Botnets = 16,
    VulnerabilityScanners = 32,
    WebScrapers = 64,
    SearchEngines = 128,
    SearchEngineCrawlers = 256,
    AiSearch = 512,
    AiCrawlers = 1024,
    AiAgents = 2048,
    PagePreview = 4096,
    InternetTools = 8192,
}
