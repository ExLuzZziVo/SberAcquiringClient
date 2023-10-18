#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using SberAcquiringClient.Types.Enums;

#endregion

namespace SberAcquiringClient.Types.Common
{
    public class CardAuthInfo
    {
        //Pan or MaskedPan?
        /// <summary>
        /// Маскированный номер карты
        /// </summary>
        [Display(Name = "Маскированный номер карты")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// Срок истечения действия карты
        /// </summary>
        [Display(Name = "Срок истечения действия карты")]
        [CustomDateTimeConverter("yyyyMM")]
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// Имя держателя карты
        /// </summary>
        [Display(Name = "Имя держателя карты")]
        public string CardholderName { get; set; }

        /// <summary>
        /// Код авторизации платежа
        /// </summary>
        [Display(Name = "Код авторизации платежа")]
        public string ApprovalCode { get; set; }

        /// <summary>
        /// Флаг, указывающий были ли средства принудительно возвращены покупателю банком
        /// </summary>
        [Display(Name = "Флаг, указывающий были ли средства принудительно возвращены покупателю банком")]
        public bool? Chargeback { get; set; }

        /// <summary>
        /// Наименование платёжной системы
        /// </summary>
        [Display(Name = "Наименование платёжной системы")]
        public PaymentSystem? PaymentSystem { get; set; }

        /// <summary>
        /// Дополнительные сведения о корпоративных картах
        /// </summary>
        [Display(Name = "Дополнительные сведения о корпоративных картах")]
        public string Product { get; set; }

        /// <summary>
        /// Дополнительные сведения о категории корпоративных карт
        /// </summary>
        [Display(Name = "Дополнительные сведения о категории корпоративных карт")]
        public string ProductCategory { get; set; }
    }
}