using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;

namespace SberAcquiringClient.Types.Operations.PaymentSystems.GooglePay
{
    /// <summary>
    /// Оплата с помощью Google Pay
    /// </summary>
    public class GooglePayOperation : PaymentSystemOperation<GooglePayResult>
    {
        /// <summary>
        /// Оплата с помощью Google Pay
        /// </summary>
        /// <param name="orderNumber">Идентификатор заказа в системе продавца</param>
        /// <param name="merchant">Логин продавца в платёжном шлюзе</param>
        /// <param name="amount">Сумма платежа</param>
        /// <param name="returnUrl">Адрес, на который требуется перенаправить пользователя в случае успешной оплаты</param>
        /// <param name="googlePayToken">Закодированный в base64 токен GooglePay</param>
        public GooglePayOperation(string orderNumber, string merchant, decimal amount, string returnUrl,
            string googlePayToken) : base("/payment/google/payment.do")
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

            if (!amount.IsInRange(0.01m, 999999999999999999.99m))
            {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Amount)).GetPropertyDisplayName(), 0.01, 999999999999999999.99));
            }

            if (returnUrl.IsNullOrEmptyOrWhiteSpace() || returnUrl.Length > 512 ||
                !Regex.IsMatch(returnUrl, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(ReturnUrl)).GetPropertyDisplayName()),
                    nameof(returnUrl));
            }

            if (googlePayToken.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(PaymentToken)).GetPropertyDisplayName()),
                    nameof(googlePayToken));
            }

            OrderNumber = orderNumber;
            Merchant = merchant;
            Amount = amount;
            ReturnUrl = returnUrl;
            PaymentToken = googlePayToken;
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
        /// Закодированный в base64 токен GooglePay
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Закодированный в base64 токен GooglePay")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string PaymentToken { get; }

        /// <summary>
        /// IP-адрес покупателя
        /// </summary>
        [Display(Name = "IP-адрес покупателя")]
        [JsonConverter(typeof(IpAddressConverter))]
        public IPAddress Ip { get; set; }

        /// <summary>
        /// Сумма платежа
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.01-999999999999999999.99</item>
        /// </list>
        [Display(Name = "Сумма платежа")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0.01, 999999999999999999.99, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal Amount { get; }

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

        /// <summary>
        /// Адрес электронной почты покупателя
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.EmailAddressPattern"/></item>
        /// </list>
        [Display(Name = "Адрес электронной почты покупателя")]
        [RegularExpression(RegexExtensions.EmailAddressPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Email { get; set; }

        /// <summary>
        /// Номер телефона покупателя
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению ^((\+7|7|8)?([0-9]){10})$</item>
        /// </list>
        [Display(Name = "Номер телефона покупателя")]
        [RegularExpression(@"^((\+7|7|8)?([0-9]){10})$", ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Phone { get; set; }

        /// <summary>
        /// Адрес, на который требуется перенаправить пользователя в случае успешной оплаты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></item>
        /// <item>Максимальная длина: 512</item>
        /// </list>
        [Display(Name = "Адрес, на который требуется перенаправить пользователя в случае успешной оплаты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(512, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string ReturnUrl { get; }

        /// <summary>
        /// Адрес, на который требуется перенаправить пользователя в случае неуспешной оплаты
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></item>
        /// <item>Максимальная длина: 512</item>
        /// </list>
        [Display(Name = "Адрес, на который требуется перенаправить пользователя в случае неуспешной оплаты")]
        [MaxLength(512, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string FailUrl { get; set; }
    }
}