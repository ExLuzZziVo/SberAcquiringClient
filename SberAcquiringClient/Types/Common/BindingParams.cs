using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class BindingParams
    {
        /// <summary>
        /// Идентификатор созданной ранее связки
        /// </summary>
        [Display(Name = "Идентификатор созданной ранее связки")]
        public string BindingId { get; set; }

        /// <summary>
        /// Маскированный номер карты
        /// </summary>
        [Display(Name = "Маскированный номер карты")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// Срок истечения действия карты
        /// </summary>
        [Display(Name = "Срок истечения действия карты")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyyMM")]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Идентификатор клиента в системе продавца
        /// </summary>
        [Display(Name = "Идентификатор клиента в системе продавца")]
        public string ClientId { get; set; }

        /// <summary>
        /// Способ совершения платежа
        /// </summary>
        [Display(Name = "Способ совершения платежа")]
        public PaymentWay? PaymentWay { get; set; }

        /// <summary>
        /// Наименование платёжной системы
        /// </summary>
        [Display(Name = "Наименование платёжной системы")]
        public PaymentSystem? PaymentSystem { get; set; }

        /// <summary>
        /// Тип связки
        /// </summary>
        [Display(Name = "Тип связки")]
        public BindingType? BindingCategory { get; set; }
    }
}