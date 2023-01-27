#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

#endregion

namespace SberAcquiringClient.Types.Operations.Orders.RegisterOrder
{
    /// <summary>
    /// Регистрация заказа
    /// </summary>
    public class RegisterOrderOperation : Operation<RegisterOrderResult>
    {
        /// <summary>
        /// Регистрация заказа
        /// </summary>
        /// <param name="preAuth">Истина - двухстадийная оплата. Ложь - одностадийная</param>
        /// <param name="orderNumber">Идентификатор заказа в системе продавца</param>
        /// <param name="amount">Сумма платежа</param>
        /// <param name="returnUrl">Адрес, на который требуется перенаправить пользователя в случае успешной оплаты</param>
        public RegisterOrderOperation(bool preAuth, string orderNumber, decimal amount, string returnUrl) : base(
            preAuth ? "/payment/rest/registerPreAuth.do" : "/payment/rest/register.do")
        {
            if (orderNumber.IsNullOrEmptyOrWhiteSpace() || orderNumber.Length > 32)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(OrderNumber)).GetPropertyDisplayName()),
                    nameof(orderNumber));
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

            OrderNumber = orderNumber;
            Amount = amount;
            ReturnUrl = returnUrl;
        }

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
        public string Currency { get; set; }

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

        /// <summary>
        /// Динамический адрес для отправки callback-уведомлений
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></item>
        /// <item>Максимальная длина: 512</item>
        /// </list>
        [Display(Name = "Динамический адрес для отправки callback-уведомлений")]
        [MaxLength(512, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string DynamicCallbackUrl { get; set; }

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
        /// Версия платежных страниц для клиента
        /// </summary>
        /// <list type="bullets">
        /// <item>Максимальная длина: 20</item>
        /// </list>
        [Display(Name = "Версия платежных страниц для клиента")]
        [MaxLength(20, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string PageView { get; set; }

        /// <summary>
        /// Идентификатор клиента в системе продавца
        /// </summary>
        /// <list type="bullets">
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Идентификатор клиента в системе продавца")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string ClientId { get; set; }

        /// <summary>
        /// Логин дочернего продавца
        /// </summary>
        /// <list type="bullets">
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Логин дочернего продавца")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string MerchantLogin { get; set; }

        /// <summary>
        /// Дополнительные параметры
        /// </summary>
        [Display(Name = "Дополнительные параметры")]
        public Dictionary<string, string> JsonParams { get; set; }

        /// <summary>
        /// Продолжительность жизни заказа в секундах
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-999999999</item>
        /// </list>
        [Display(Name = "Продолжительность жизни заказа в секундах")]
        [Range(1, 999999999, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? SessionTimeoutSecs { get; set; }

        /// <summary>
        /// Дата и время окончания жизни заказа
        /// </summary>
        [Display(Name = "Дата и время окончания жизни заказа")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-ddTHH:mm:ss")]
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Идентификатор созданной ранее связки
        /// </summary>
        /// <list type="bullets">
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Идентификатор созданной ранее связки")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string BindingId { get; set; }

        /// <summary>
        /// Способ проверки подлинности проведения платежа
        /// </summary>
        [Display(Name = "Способ проверки подлинности проведения платежа")]
        public RegisterOrderFeatures? Features { get; set; }

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
    }
}