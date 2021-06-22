using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.PaymentSystems.ApplePay
{
    public class ApplePayOperation : PaymentSystemOperation<ApplePayResult>
    {
        public ApplePayOperation(string orderNumber, string merchant, string applePayToken) : base(
            "/payment/applepay/payment.do")
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

            if (applePayToken.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(PaymentToken)).GetPropertyDisplayName()),
                    nameof(applePayToken));
            }

            OrderNumber = orderNumber;
            Merchant = merchant;
            PaymentToken = applePayToken;
        }

        [Display(Name = "Логин продавца в платёжном шлюзе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Merchant { get; }

        [Display(Name = "Идентификатор заказа в системе магазина")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }

        [Display(Name = "Описание заказа в свободной форме")]
        [MaxLength(1024, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(@"[^%+\r\n]+", ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Description { get; set; }

        [Display(Name = "Дополнительные параметры")]
        public Dictionary<string, string> AdditionalParameters { get; set; }

        [Display(Name = "Флаг, определяющий необходимость предварительной авторизации")]
        public bool? PreAuth { get; set; }

        [Display(Name = "Закодированный в base64 токен ApplePay")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string PaymentToken { get; }
    }
}