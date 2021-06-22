using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;

namespace SberAcquiringClient.Types.Operations.Orders.CancelOrder
{
    public class CancelOrderOperation : Operation<CancelOrderResult>
    {
        public CancelOrderOperation(Guid orderId) : base("/payment/rest/reverse.do")
        {
            OrderId = orderId;
        }

        [Display(Name = "Номер заказа в платежной системе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public Guid OrderId { get; }

        [Display(Name = "Сумма платежа")]
        [Range(0, 999999999999999999.99, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount { get; set; }

        [Display(Name = "Дополнительные параметры")]
        public Dictionary<string, string> JsonParams { get; set; }
    }
}