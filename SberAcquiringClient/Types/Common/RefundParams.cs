using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class RefundParams
    {
        /// <summary>
        /// Номер ссылки транзакции
        /// </summary>
        [Display(Name = "Номер ссылки транзакции")]
        public long? ReferenceNumber { get; set; }

        /// <summary>
        /// Код ответа процессинга
        /// </summary>
        [Display(Name = "Код ответа процессинга")]
        public ProcessingActionCode? ActionCode { get; set; }

        /// <summary>
        /// Сумма возврата
        /// </summary>
        [Display(Name = "Сумма возврата")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Дата регистрации заказа
        /// </summary>
        [Display(Name = "Дата регистрации заказа")]
        [JsonConverter(typeof(UnixTimestampConverter), true)]
        public DateTime? Date { get; set; }
    }
}