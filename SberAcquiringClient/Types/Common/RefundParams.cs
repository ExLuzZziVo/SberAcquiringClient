using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class RefundParams
    {
        [Display(Name = "Номер ссылки транзакции")]
        public long? ReferenceNumber { get; set; }

        [Display(Name = "Код ответа процессинга")]
        public ProcessingActionCode? ActionCode { get; set; }

        [Display(Name = "Сумма возврата")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount { get; set; }

        [Display(Name = "Дата регистрации заказа")]
        [JsonConverter(typeof(UnixTimestampConverter), true)]
        public DateTime? Date { get; set; }
    }
}