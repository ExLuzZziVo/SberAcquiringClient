#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Resources;
using SberAcquiringClient.Types.Converters;

#endregion

namespace SberAcquiringClient.Types.Operations.Orders.DepositOrder
{
    /// <summary>
    /// Завершение заказа
    /// </summary>
    public class DepositOrderOperation : Operation<DepositOrderResult>
    {
        /// <summary>
        /// Завершение заказа
        /// </summary>
        /// <param name="orderId">Идентификатор заказа в платежной системе</param>
        /// <param name="amount">Сумма платежа. По умолчанию: 0 (на всю сумму)</param>
        public DepositOrderOperation(Guid orderId, decimal amount = 0) : base("/payment/rest/deposit.do")
        {
            if (!amount.IsInRange(0, 999999999999999999.99m))
            {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Amount)).GetPropertyDisplayName(), 0, 999999999999999999.99));
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
        /// Сумма платежа
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0-999999999999999999.99</item>
        /// </list>
        [Display(Name = "Сумма платежа")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0, 999999999999999999.99, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal Amount { get; }
    }
}