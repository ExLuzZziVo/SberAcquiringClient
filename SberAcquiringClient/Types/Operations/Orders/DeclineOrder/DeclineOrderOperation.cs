using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.Orders.DeclineOrder
{
    public class DeclineOrderOperation : Operation<DeclineOrderResult>
    {
        public DeclineOrderOperation(Guid orderId, string merchantLogin) : base("/payment/rest/decline.do")
        {
            if (merchantLogin.IsNullOrEmptyOrWhiteSpace() || merchantLogin.Length > 255)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(MerchantLogin)).GetPropertyDisplayName()),
                    nameof(merchantLogin));
            }

            OrderId = orderId;
            MerchantLogin = merchantLogin;
        }

        public DeclineOrderOperation(string orderNumber, string merchantLogin) : base("/payment/rest/decline.do")
        {
            if (orderNumber.IsNullOrEmptyOrWhiteSpace() || orderNumber.Length > 32)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(OrderNumber)).GetPropertyDisplayName()),
                    nameof(orderNumber));
            }

            if (merchantLogin.IsNullOrEmptyOrWhiteSpace() || merchantLogin.Length > 255)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(MerchantLogin)).GetPropertyDisplayName()),
                    nameof(merchantLogin));
            }

            OrderNumber = orderNumber;
            MerchantLogin = merchantLogin;
        }

        [Display(Name = "Логин продавца, для которого отклонить заказ")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string MerchantLogin { get; }

        [RequiredIfValidation(nameof(OrderNumber), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Идентификатор заказа в платежной системе")]
        public Guid? OrderId { get; }

        [RequiredIfValidation(nameof(OrderId), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Идентификатор заказа в системе магазина")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }
    }
}