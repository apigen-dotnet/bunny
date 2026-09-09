using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 0 = None
/// 1 = SEO
/// 2 = AIScraper
/// 3 = AITool
/// 4 = Tool
/// 5 = Ads
/// 6 = Preview
/// 7 = Social
/// 255 = System
/// </summary>
[JsonConverter(typeof(JsonNumberEnumConverter<BotCategory>))]
public enum BotCategory
{
    None = 0,
    Seo = 1,
    AIScraper = 2,
    AITool = 3,
    Tool = 4,
    Ads = 5,
    Preview = 6,
    Social = 7,
}
