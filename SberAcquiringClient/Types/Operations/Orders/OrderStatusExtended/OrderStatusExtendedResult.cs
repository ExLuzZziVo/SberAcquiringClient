using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SberAcquiringClient.Types.Common;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Operations.Orders.OrderStatusExtended
{
    public class OrderStatusExtendedResult : OperationResult
    {
        [Display(Name = "Идентификатор заказа в системе магазина")]
        public string OrderNumber { get; set; }

        [Display(Name = "Состояние заказа")] public Enums.OrderStatus? OrderStatus { get; set; }

        [Display(Name = "Код ответа")] public ProcessingActionCode? ActionCode { get; set; }

        [Display(Name = "Расшифровка кода ответа")]
        public string ActionCodeDescription { get; set; }

        [Display(Name = "Сумма платежа")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount { get; set; }

        [Display(Name = "Код валюты платежа ISO 4217")]
        public string Currency { get; set; }

        [Display(Name = "Дата регистрации заказа")]
        [JsonConverter(typeof(UnixTimestampConverter), true)]
        public DateTime? Date { get; set; }

        [Display(Name = "Описание заказа, переданное при его регистрации")]
        public string OrderDescription { get; set; }

        [Display(Name = "IP адрес пользователя, который оплачивал заказ")]
        [JsonConverter(typeof(IpAddressConverter))]
        public IPAddress Ip { get; set; }

        [Display(Name = "Дата и время возврата средств")]
        [JsonConverter(typeof(UnixTimestampConverter), true)]
        public DateTime? RefundedDate { get; set; }

        [Display(Name = "Способ совершения платежа")]
        public PaymentWay? PaymentWay { get; set; }

        [Display(Name = "Дополнительные параметры заказа")]
        [JsonConverter(typeof(NameValueDictionaryConverter))]
        public Dictionary<string, string> MerchantOrderParams { get; set; }

        [Display(Name = "Атрибуты заказа в платёжной системе")]
        [JsonConverter(typeof(NameValueDictionaryConverter))]
        public Dictionary<string, string> Attributes { get; set; }

        [Display(Name = "Данные авторизации платежной карты")]
        public CardAuthInfo CardAuthInfo { get; set; }

        [Display(Name = "Данные 3DS")] public SecureAuthInfo SecureAuthInfo { get; set; }

        [Display(Name = "Значения привязки")] public BindingInfo BindingInfo { get; set; }

        [Display(Name = "Дата и время авторизации")]
        [JsonConverter(typeof(UnixTimestampConverter), true)]
        public DateTime? AuthDateTime { get; set; }

        [Display(Name = "Номер ссылки")] public string AuthRefNum { get; set; }

        [Display(Name = "Идентификатор терминала")]
        public string TerminalId { get; set; }

        [Display(Name = "Информация о банке-эмитенте")]
        public BankInfo BankInfo { get; set; }

        [Display(Name = "Информация о суммах заказа")]
        public PaymentAmountInfo PaymentAmountInfo { get; set; }

        [Display(Name = "Информация по возврату")]
        public RefundParams Refunds { get; set; }
    }
}