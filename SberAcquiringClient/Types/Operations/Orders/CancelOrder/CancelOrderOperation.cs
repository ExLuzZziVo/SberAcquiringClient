using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;

namespace SberAcquiringClient.Types.Operations.Orders.CancelOrder
{
    /// <summary>
    /// Отмена оплаты заказа
    /// </summary>
    public class CancelOrderOperation : Operation<CancelOrderResult>
    {
        /// <summary>
        /// Отмена оплаты заказа
        /// </summary>
        /// <param name="orderId">Идентификатор заказа в платежной системе</param>
        public CancelOrderOperation(Guid orderId) : base("/payment/rest/reverse.do")
        {
            OrderId = orderId;
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
        /// <item>Должно лежать в диапазоне: 0-999999999999999999.99</item>
        /// </list>
        [Display(Name = "Сумма платежа")]
        [Range(0, 999999999999999999.99, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Дополнительные параметры
        /// </summary>
        [Display(Name = "Дополнительные параметры")]
        public Dictionary<string, string> JsonParams { get; set; }
    }
}