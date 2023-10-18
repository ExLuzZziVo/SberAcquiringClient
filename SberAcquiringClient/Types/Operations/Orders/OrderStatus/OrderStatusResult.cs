#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using SberAcquiringClient.Types.Common;
using SberAcquiringClient.Types.Converters;

#endregion

namespace SberAcquiringClient.Types.Operations.Orders.OrderStatus
{
    /// <summary>
    /// Результат получения статуса заказа
    /// </summary>
    public class OrderStatusResult : OperationResult
    {
        /// <summary>
        /// Состояние заказа
        /// </summary>
        [Display(Name = "Состояние заказа")]
        public Enums.OrderStatus? OrderStatus { get; set; }

        /// <summary>
        /// Идентификатор заказа в системе продавца
        /// </summary>
        [Display(Name = "Идентификатор заказа в системе продавца")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Маскированный номер карты
        /// </summary>
        [Display(Name = "Маскированный номер карты")]
        public string Pan { get; set; }

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
        /// Сумма платежа
        /// </summary>
        [Display(Name = "Сумма платежа")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Код валюты платежа ISO 4217
        /// </summary>
        [Display(Name = "Код валюты платежа ISO 4217")]
        public string Currency { get; set; }

        /// <summary>
        /// Код авторизации платежа
        /// </summary>
        [Display(Name = "Код авторизации платежа")]
        public string ApprovalCode { get; set; }

        /// <summary>
        /// Код авторизации процессинговой системы
        /// </summary>
        [Display(Name = "Код авторизации процессинговой системы")]
        [Obsolete]
        public string AuthCode { get; set; }

        /// <summary>
        /// IP адрес пользователя, который оплачивал заказ
        /// </summary>
        [Display(Name = "IP адрес пользователя, который оплачивал заказ")]
        [JsonConverter(typeof(IpAddressConverter))]
        public IPAddress Ip { get; set; }

        /// <summary>
        /// Значения привязки
        /// </summary>
        [Display(Name = "Значения привязки")]
        public BindingInfo BindingInfo { get; set; }
    }
}