using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class PaymentAmountInfo
    {
        /// <summary>
        /// Сумма, захолдированная на карте
        /// </summary>
        [Display(Name = "Сумма, захолдированная на карте")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? ApprovedAmount { get; set; }

        /// <summary>
        /// Сумма, подтвержденная для списания с карты
        /// </summary>
        [Display(Name = "Сумма, подтвержденная для списания с карты")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? DepositedAmount { get; set; }

        /// <summary>
        /// Сумма возврата
        /// </summary>
        [Display(Name = "Сумма возврата")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? RefundedAmount { get; set; }

        /// <summary>
        /// Состояние оплаты
        /// </summary>
        [Display(Name = "Состояние оплаты")]
        public TransactionState? PaymentState { get; set; }

        /// <summary>
        /// Сумма комиссии
        /// </summary>
        [Display(Name = "Сумма комиссии")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? FeeAmount { get; set; }

        /// <summary>
        /// Сумма заказа + комиссия
        /// </summary>
        [Display(Name = "Сумма заказа + комиссия")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? TotalAmount { get; set; }
    }
}