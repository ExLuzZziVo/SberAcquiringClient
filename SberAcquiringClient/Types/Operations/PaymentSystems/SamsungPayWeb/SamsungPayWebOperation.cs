#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace SberAcquiringClient.Types.Operations.PaymentSystems.SamsungPayWeb
{
    /// <summary>
    /// Оплата через Samsung Pay, при которой используется платёжная страница на стороне продавца
    /// </summary>
    public class SamsungPayWebOperation : Operation<SamsungPayWebResult>
    {
        /// <summary>
        /// Оплата через Samsung Pay, при которой используется платёжная страница на стороне продавца
        /// </summary>
        /// <param name="orderId">Идентификатор заказа в платежной системе</param>
        /// <param name="failUrl">Адрес, на который требуется перенаправить пользователя в случае неуспешной оплаты</param>
        public SamsungPayWebOperation(Guid orderId, string failUrl) : base("/payment/samsungWeb/payment.do")
        {
            if (failUrl.IsNullOrEmptyOrWhiteSpace() || failUrl.Length > 512 ||
                !Regex.IsMatch(failUrl, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(OnFailedPaymentBackUrl)).GetPropertyDisplayName()),
                    nameof(failUrl));
            }

            Mdorder = orderId;
            OnFailedPaymentBackUrl = failUrl;
        }

        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public Guid Mdorder { get; }

        /// <summary>
        /// Адрес, на который требуется перенаправить пользователя в случае неуспешной оплаты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></item>
        /// <item>Максимальная длина: 512</item>
        /// </list>
        [Display(Name = "Адрес, на который требуется перенаправить пользователя в случае неуспешной оплаты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(512, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string OnFailedPaymentBackUrl { get; }
    }
}