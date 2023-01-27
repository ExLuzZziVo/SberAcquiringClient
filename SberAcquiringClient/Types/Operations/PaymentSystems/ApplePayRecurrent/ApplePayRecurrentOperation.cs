#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;

#endregion

namespace SberAcquiringClient.Types.Operations.PaymentSystems.ApplePayRecurrent
{
    /// <summary>
    /// Проведение рекуррентного платежа Apple Pay
    /// </summary>
    public class ApplePayRecurrentOperation : PaymentSystemOperation<ApplePayRecurrentResult>
    {
        /// <summary>
        /// Проведение рекуррентного платежа Apple Pay
        /// </summary>
        /// <param name="orderNumber">Идентификатор заказа в системе продавца</param>
        /// <param name="bindingId">Идентификатор созданной ранее связки</param>
        /// <param name="amount">Сумма платежа</param>
        public ApplePayRecurrentOperation(string orderNumber, string bindingId, decimal amount) : base(
            "/payment/recurrentPayment.do")
        {
            if (orderNumber.IsNullOrEmptyOrWhiteSpace() || orderNumber.Length > 32)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(OrderNumber)).GetPropertyDisplayName()),
                    nameof(orderNumber));
            }

            if (bindingId.IsNullOrEmptyOrWhiteSpace() || bindingId.Length > 255)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(BindingId)).GetPropertyDisplayName()),
                    nameof(bindingId));
            }

            if (!amount.IsInRange(0.01m, 999999999999999999.99m))
            {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Amount)).GetPropertyDisplayName(), 0.01, 999999999999999999.99));
            }

            OrderNumber = orderNumber;
            BindingId = bindingId;
            Amount = amount;
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
        /// Идентификатор созданной ранее связки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Идентификатор созданной ранее связки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string BindingId { get; }

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
    }
}