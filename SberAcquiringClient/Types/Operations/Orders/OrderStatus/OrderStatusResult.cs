using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Common;
using SberAcquiringClient.Types.Converters;

namespace SberAcquiringClient.Types.Operations.Orders.OrderStatus
{
    public class OrderStatusResult : OperationResult
    {
        [Display(Name = "Состояние заказа")] public Enums.OrderStatus? OrderStatus { get; set; }

        [Display(Name = "Идентификатор заказа в системе магазина")]
        public string OrderNumber { get; set; }

        [Display(Name = "Маскированный номер карты")]
        public string Pan { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyyMM")]
        [Display(Name = "Срок истечения действия карты")]
        public DateTime? Expiration { get; set; }

        [Display(Name = "Имя держателя карты")]
        public string CardholderName { get; set; }

        [Display(Name = "Сумма платежа")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount { get; set; }

        [Display(Name = "Код валюты платежа ISO 4217")]
        public string Currency { get; set; }

        [Display(Name = "Код авторизации платежа")]
        public string ApprovalCode { get; set; }

        [Obsolete]
        [Display(Name = "Код авторизации процессинговой системы")]
        public string AuthCode { get; set; }

        [Display(Name = "IP адрес пользователя, который оплачивал заказ")]
        [JsonConverter(typeof(IpAddressConverter))]
        public IPAddress Ip { get; set; }

        [Display(Name = "Значения привязки")] public BindingInfo BindingInfo { get; set; }
    }
}