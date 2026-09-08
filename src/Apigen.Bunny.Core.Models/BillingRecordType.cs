using System;
using System.Text.Json.Serialization;

namespace Apigen.Bunny.Core.Models;

/// <summary>
/// 0 = PayPal
/// 1 = Crypto
/// 2 = CreditCard
/// 3 = MonthlyUsage
/// 4 = Refund
/// 5 = CouponCode
/// 6 = BankTransfer
/// 7 = AffiliateCredits
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BillingRecordType
{
    __0 = 0,
    __1 = 1,
    __2 = 2,
    __3 = 3,
    __4 = 4,
    __5 = 5,
    __6 = 6,
    __7 = 7,
}
