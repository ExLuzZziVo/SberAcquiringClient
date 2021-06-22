using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class BindingParams
    {
        [Display(Name = "Идентификатор созданной ранее связки")]
        public string BindingId { get; set; }

        [Display(Name = "Маскированный номер карты")]
        public string MaskedPan { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyyMM")]
        [Display(Name = "Срок истечения действия карты")]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "Идентификатор клиента в системе магазина")]
        public string ClientId { get; set; }

        [Display(Name = "Способ совершения платежа")]
        public PaymentWay? PaymentWay { get; set; }

        [Display(Name = "Наименование платёжной системы")]
        public PaymentSystem? PaymentSystem { get; set; }

        [Display(Name = "Тип связки")] public BindingType? BindingCategory { get; set; }
    }
}