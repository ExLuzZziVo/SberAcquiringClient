using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class CardAuthInfo
    {
        //Pan or MaskedPan?
        [Display(Name = "Маскированный номер карты")]
        public string MaskedPan { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyyMM")]
        [Display(Name = "Срок истечения действия карты")]
        public DateTime? Expiration { get; set; }

        [Display(Name = "Имя держателя карты")]
        public string CardholderName { get; set; }

        [Display(Name = "Код авторизации платежа")]
        public string ApprovalCode { get; set; }

        [Display(Name = "Флаг, указывающий были ли средства принудительно возвращены покупателю банком")]
        public bool? Chargeback { get; set; }

        [Display(Name = "Наименование платёжной системы")]
        public PaymentSystem? PaymentSystem { get; set; }

        [Display(Name = "Дополнительные сведения о корпоративных картах")]
        public string Product { get; set; }

        [Display(Name = "Дополнительные сведения о категории корпоративных карт")]
        public string ProductCategory { get; set; }
    }
}