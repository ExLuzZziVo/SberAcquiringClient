using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.PaymentSystems.SamsungPayWeb
{
    public class SamsungPayWebOperation : Operation<SamsungPayWebResult>
    {
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

        [Display(Name = "Номер заказа в платежной системе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public Guid Mdorder { get; }

        [Display(Name = "Адрес, на который требуется перенаправить пользователя в случае неуспешной оплаты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(512, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string OnFailedPaymentBackUrl { get; }
    }
}