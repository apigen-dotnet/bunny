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
[JsonConverter(typeof(JsonNumberEnumConverter<BillingRecordType>))]
public enum BillingRecordType
{
    PayPal = 0,
    Crypto = 1,
    CreditCard = 2,
    MonthlyUsage = 3,
    Refund = 4,
    CouponCode = 5,
    BankTransfer = 6,
    AffiliateCredits = 7,
}
