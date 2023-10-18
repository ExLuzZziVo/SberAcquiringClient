#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using SberAcquiringClient.Types.Common;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

#endregion

namespace SberAcquiringClient.Types.Operations.Orders.OrderStatusExtended
{
    /// <summary>
    /// Результат получения расширенного статуса заказа
    /// </summary>
    public class OrderStatusExtendedResult : OperationResult
    {
        /// <summary>
        /// Идентификатор заказа в системе продавца
        /// </summary>
        [Display(Name = "Идентификатор заказа в системе продавца")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Состояние заказа
        /// </summary>
        [Display(Name = "Состояние заказа")]
        public Enums.OrderStatus? OrderStatus { get; set; }

        /// <summary>
        /// Код ответа
        /// </summary>
        [Display(Name = "Код ответа")]
        public ProcessingActionCode? ActionCode { get; set; }

        /// <summary>
        /// Расшифровка кода ответа
        /// </summary>
        [Display(Name = "Расшифровка кода ответа")]
        public string ActionCodeDescription { get; set; }

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
        /// Дата регистрации заказа
        /// </summary>
        [Display(Name = "Дата регистрации заказа")]
        [UnixTimestampConverter(true)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Описание заказа, переданное при его регистрации
        /// </summary>
        [Display(Name = "Описание заказа, переданное при его регистрации")]
        public string OrderDescription { get; set; }

        /// <summary>
        /// IP адрес пользователя, который оплачивал заказ
        /// </summary>
        [Display(Name = "IP адрес пользователя, который оплачивал заказ")]
        [JsonConverter(typeof(IpAddressConverter))]
        public IPAddress Ip { get; set; }

        /// <summary>
        /// Дата и время возврата средств
        /// </summary>
        [Display(Name = "Дата и время возврата средств")]
        [UnixTimestampConverter(true)]
        public DateTime? RefundedDate { get; set; }

        /// <summary>
        /// Способ совершения платежа
        /// </summary>
        [Display(Name = "Способ совершения платежа")]
        public PaymentWay? PaymentWay { get; set; }

        /// <summary>
        /// Дополнительные параметры заказа
        /// </summary>
        [Display(Name = "Дополнительные параметры заказа")]
        [JsonConverter(typeof(NameValueDictionaryConverter))]
        public Dictionary<string, string> MerchantOrderParams { get; set; }

        /// <summary>
        /// Атрибуты заказа в платёжной системе
        /// </summary>
        [Display(Name = "Атрибуты заказа в платёжной системе")]
        [JsonConverter(typeof(NameValueDictionaryConverter))]
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// Данные авторизации платежной карты
        /// </summary>
        [Display(Name = "Данные авторизации платежной карты")]
        public CardAuthInfo CardAuthInfo { get; set; }

        /// <summary>
        /// Данные 3DS
        /// </summary>
        [Display(Name = "Данные 3DS")]
        public SecureAuthInfo SecureAuthInfo { get; set; }

        /// <summary>
        /// Значения привязки
        /// </summary>
        [Display(Name = "Значения привязки")]
        public BindingInfo BindingInfo { get; set; }

        /// <summary>
        /// Дата и время авторизации
        /// </summary>
        [Display(Name = "Дата и время авторизации")]
        [UnixTimestampConverter(true)]
        public DateTime? AuthDateTime { get; set; }

        /// <summary>
        /// Номер ссылки
        /// </summary>
        [Display(Name = "Номер ссылки")]
        public string AuthRefNum { get; set; }

        /// <summary>
        /// Идентификатор терминала
        /// </summary>
        [Display(Name = "Идентификатор терминала")]
        public string TerminalId { get; set; }

        /// <summary>
        /// Информация о банке-эмитенте
        /// </summary>
        [Display(Name = "Информация о банке-эмитенте")]
        public BankInfo BankInfo { get; set; }

        /// <summary>
        /// Информация о суммах заказа
        /// </summary>
        [Display(Name = "Информация о суммах заказа")]
        public PaymentAmountInfo PaymentAmountInfo { get; set; }

        /// <summary>
        /// Информация по возврату
        /// </summary>
        [Display(Name = "Информация по возврату")]
        public RefundParams Refunds { get; set; }
    }
}