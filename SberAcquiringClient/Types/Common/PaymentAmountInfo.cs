using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class PaymentAmountInfo
    {
        [Display(Name = "Сумма, захолдированная на карте")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? ApprovedAmount { get; set; }

        [Display(Name = "Сумма, подтвержденная для списания с карты")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? DepositedAmount { get; set; }

        [Display(Name = "Сумма возврата")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? RefundedAmount { get; set; }

        [Display(Name = "Состояние оплаты")] public TransactionState? PaymentState { get; set; }

        [Display(Name = "Сумма комиссии")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? FeeAmount { get; set; }

        [Display(Name = "Сумма заказа + комиссия")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? TotalAmount { get; set; }
    }
}