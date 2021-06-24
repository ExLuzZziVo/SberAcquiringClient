using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.Orders.DeclineOrder
{
    /// <summary>
    /// Отмена неоплаченного заказа
    /// </summary>
    public class DeclineOrderOperation : Operation<DeclineOrderResult>
    {
        /// <summary>
        /// Отмена неоплаченного заказа по идентификатору заказа в платежной системе
        /// </summary>
        /// <param name="orderId">Идентификатор заказа в платежной системе</param>
        /// <param name="merchantLogin">Логин продавца, для которого отклонить заказ</param>
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

        /// <summary>
        /// Отмена неоплаченного заказа по идентификатору заказа в системе продавца
        /// </summary>
        /// <param name="orderNumber">Идентификатор заказа в системе продавца</param>
        /// <param name="merchantLogin">Логин продавца, для которого отклонить заказ</param>
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

        /// <summary>
        /// Логин продавца, для которого отклонить заказ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Логин продавца, для которого отклонить заказ")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string MerchantLogin { get; }

        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="OrderNumber"/> не указан</item>
        /// </list>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        [RequiredIfValidation(nameof(OrderNumber), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        public Guid? OrderId { get; }

        /// <summary>
        /// Идентификатор заказа в системе продавца
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="OrderId"/> не указан</item>
        /// <item>Максимальная длина: 32</item>
        /// </list>
        [Display(Name = "Идентификатор заказа в системе продавца")]
        [RequiredIfValidation(nameof(OrderId), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }
    }
}