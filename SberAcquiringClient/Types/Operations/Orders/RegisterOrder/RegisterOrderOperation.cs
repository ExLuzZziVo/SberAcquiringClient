using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Operations.Orders.RegisterOrder
{
    public class RegisterOrderOperation : Operation<RegisterOrderResult>
    {
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

        [Display(Name = "Идентификатор заказа в системе магазина")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }

        [Display(Name = "Сумма платежа")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0.01, 999999999999999999.99, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal Amount { get; }

        [Display(Name = "Код валюты платежа ISO 4217")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.PositiveNumberPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Currency { get; set; }

        [Display(Name = "Адрес, на который требуется перенаправить пользователя в случае успешной оплаты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(512, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string ReturnUrl { get; }

        [Display(Name = "Адрес, на который требуется перенаправить пользователя в случае неуспешной оплаты")]
        [MaxLength(512, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string FailUrl { get; set; }

        [Display(Name = "Динамический адрес для отправки callback-уведомлений")]
        [MaxLength(512, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string DynamicCallbackUrl { get; set; }

        [Display(Name = "Описание заказа в свободной форме")]
        [MaxLength(1024, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(@"[^%+\r\n]+", ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Description { get; set; }

        [Display(Name = "Версия платежных страниц для клиента")]
        [MaxLength(20, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string PageView { get; set; }

        [Display(Name = "Идентификатор клиента в системе магазина")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string ClientId { get; set; }

        [Display(Name = "Логин дочернего продавца")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string MerchantLogin { get; set; }

        [Display(Name = "Дополнительные параметры")]
        public Dictionary<string, string> JsonParams { get; set; }

        [Display(Name = "Продолжительность жизни заказа в секундах")]
        [Range(1, 999999999, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? SessionTimeoutSecs { get; set; }

        [Display(Name = "Дата и время окончания жизни заказа")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-ddTHH:mm:ss")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Идентификатор созданной ранее связки")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string BindingId { get; set; }

        [Display(Name = "Способ проверки подлинности проведения платежа")]
        public RegisterOrderFeatures? Features { get; set; }

        [Display(Name = "Адрес электронной почты покупателя")]
        [RegularExpression(RegexExtensions.EmailAddressPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Email { get; set; }

        [Display(Name = "Номер телефона покупателя")]
        [RegularExpression(@"^((\+7|7|8)?([0-9]){10})$", ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Phone { get; set; }
    }
}