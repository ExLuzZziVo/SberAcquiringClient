#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace SberAcquiringClient.Types.Operations.PaymentSystems.ApplePay
{
    /// <summary>
    /// Оплата с помощью Apple Pay
    /// </summary>
    public class ApplePayOperation : PaymentSystemOperation<ApplePayResult>
    {
        /// <summary>
        /// Оплата с помощью Apple Pay
        /// </summary>
        /// <param name="orderNumber">Идентификатор заказа в системе продавца</param>
        /// <param name="merchant">Логин продавца в платёжном шлюзе</param>
        /// <param name="applePayToken">Закодированный в base64 токен ApplePay</param>
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
        /// Закодированный в base64 токен ApplePay
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Закодированный в base64 токен ApplePay")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string PaymentToken { get; }
    }
}