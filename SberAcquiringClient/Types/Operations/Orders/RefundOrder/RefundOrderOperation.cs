using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;

namespace SberAcquiringClient.Types.Operations.Orders.RefundOrder
{
    /// <summary>
    /// Возврат заказа
    /// </summary>
    public class RefundOrderOperation : Operation<RefundOrderResult>
    {
        /// <summary>
        /// Возврат заказа
        /// </summary>
        /// <param name="orderId">Идентификатор заказа в платежной системе</param>
        /// <param name="amount">Сумма платежа. По умолчанию: 0 (на всю сумму)</param>
        public RefundOrderOperation(Guid orderId, decimal amount) : base("/payment/rest/refund.do")
        {
            if (!amount.IsInRange(0.01m, 999999999999999999.99m))
            {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Amount)).GetPropertyDisplayName(), 0.01, 999999999999999999.99));
            }

            OrderId = orderId;
            Amount = amount;
        }

        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public Guid OrderId { get; }

        /// <summary>
        /// Сумма для возврата
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.01-999999999999999999.99</item>
        /// </list>
        [Display(Name = "Сумма для возврата")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0.01, 999999999999999999.99, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal Amount { get; }

        /// <summary>
        /// Код валюты платежа ISO 4217
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.PositiveNumberPattern"/></item>
        /// <item>Максимальная длина: 3</item>
        /// </list>
        [Display(Name = "Код валюты платежа ISO 4217")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.PositiveNumberPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Currency { get; set; }
    }
}