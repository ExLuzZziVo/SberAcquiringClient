#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;

#endregion

namespace SberAcquiringClient.Types.Operations.PaymentSystems.SamsungPay
{
    /// <summary>
    /// Оплата с помощью Samsung Pay
    /// </summary>
    public class SamsungPayOperation : PaymentSystemOperation<SamsungPayResult>
    {
        /// <summary>
        /// Оплата с помощью Samsung Pay
        /// </summary>
        /// <param name="orderNumber">Идентификатор заказа в системе продавца</param>
        /// <param name="merchant">Логин продавца в платёжном шлюзе</param>
        /// <param name="clientIp">IP-адрес покупателя</param>
        /// <param name="samsungPayToken">Содержимое параметра 3ds.data из ответа, полученного от Samsung Pay</param>
        public SamsungPayOperation(string orderNumber, string merchant, IPAddress clientIp, string samsungPayToken) :
            base("/payment/samsung/payment.do")
        {
            if (orderNumber.IsNullOrEmptyOrWhiteSpace() || orderNumber.Length > 32)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(OrderNumber)).GetPropertyDisplayName()),
                    nameof(orderNumber));
            }

            if (merchant.IsNullOrEmptyOrWhiteSpace() || merchant.Length > 255)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Merchant)).GetPropertyDisplayName()),
                    nameof(merchant));
            }

            if (clientIp == null)
            {
                throw new ArgumentNullException(nameof(clientIp));
            }

            if (samsungPayToken.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(PaymentToken)).GetPropertyDisplayName()),
                    nameof(samsungPayToken));
            }

            OrderNumber = orderNumber;
            Merchant = merchant;
            Ip = clientIp;
            PaymentToken = samsungPayToken;
        }

        /// <summary>
        /// Логин продавца в платёжном шлюзе
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Логин продавца в платёжном шлюзе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Merchant { get; }

        /// <summary>
        /// Идентификатор заказа в системе продавца
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 32</item>
        /// </list>
        [Display(Name = "Идентификатор заказа в системе продавца")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }

        /// <summary>
        /// Описание заказа в свободной форме
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению [^%+\r\n]+</item>
        /// <item>Максимальная длина: 1024</item>
        /// </list>
        [Display(Name = "Описание заказа в свободной форме")]
        [MaxLength(1024, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(@"[^%+\r\n]+", ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Description { get; set; }

        /// <summary>
        /// Дополнительные параметры
        /// </summary>
        [Display(Name = "Дополнительные параметры")]
        public Dictionary<string, string> AdditionalParameters { get; set; }

        /// <summary>
        /// Флаг, определяющий необходимость предварительной авторизации
        /// </summary>
        [Display(Name = "Флаг, определяющий необходимость предварительной авторизации")]
        public bool? PreAuth { get; set; }

        /// <summary>
        /// Идентификатор клиента в системе продавца, для которого следует создать связку для проведения регулярных платежей
        /// </summary>
        /// <list type="bullets">
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name =
            "Идентификатор клиента в системе продавца, для которого следует создать связку для проведения регулярных платежей")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string ClientId { get; set; }

        /// <summary>
        /// Содержимое параметра 3ds.data из ответа, полученного от Samsung Pay
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Содержимое параметра 3ds.data из ответа, полученного от Samsung Pay")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string PaymentToken { get; }

        /// <summary>
        /// IP-адрес покупателя
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "IP-адрес покупателя")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [JsonConverter(typeof(IpAddressConverter))]
        public IPAddress Ip { get; }

        /// <summary>
        /// Код валюты платежа ISO 4217
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.PositiveNumberPattern"/></item>
        /// <item>Максимальная длина: 3</item>
        /// </list>
        [Display(Name = "Код валюты платежа ISO 4217")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.PositiveNumberPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string CurrencyCode { get; set; }
    }
}