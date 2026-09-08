using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Shield.Models;

/// <summary>
/// 1 = CMDLINE
/// 2 = COMPRESSWHITESPACE
/// 3 = CSSDECODE
/// 4 = HEXENCODE
/// 5 = HTMLENTITYDECODE
/// 6 = JSDECODE
/// 7 = LENGTH
/// 8 = LOWERCASE
/// 9 = MD5
/// 10 = NORMALIZEPATH
/// 11 = NORMALISEPATH
/// 12 = NORMALIZEPATHWIN
/// 13 = NORMALISEPATHWIN
/// 14 = REMOVECOMMENTS
/// 15 = REMOVENULLS
/// 16 = REMOVEWHITESPACE
/// 17 = REPLACECOMMENTS
/// 18 = SHA1
/// 19 = URLDECODE
/// 20 = URLDECODEUNI
/// 21 = UTF8TOUNICODE
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WafRuleTransformationType
{
    Cmdline = 1,
    Compresswhitespace = 2,
    Cssdecode = 3,
    Hexencode = 4,
    Htmlentitydecode = 5,
    Jsdecode = 6,
    Length = 7,
    Lowercase = 8,
    MD5 = 9,
    Normalizepath = 10,
    Normalisepath = 11,
    Normalizepathwin = 12,
    Normalisepathwin = 13,
    Removecomments = 14,
    Removenulls = 15,
    Removewhitespace = 16,
    Replacecomments = 17,
    Sha1 = 18,
    Urldecode = 19,
    Urldecodeuni = 20,
    Utf8Tounicode = 21,
}
