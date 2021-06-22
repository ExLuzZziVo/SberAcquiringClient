using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.Orders.OrderStatusExtended
{
    public class OrderStatusExtendedOperation : Operation<OrderStatusExtendedResult>
    {
        public OrderStatusExtendedOperation(Guid orderId) : base("/payment/rest/getOrderStatusExtended.do")
        {
            OrderId = orderId;
        }

        public OrderStatusExtendedOperation(string orderNumber) : base("getOrderStatusExtended.do")
        {
            if (orderNumber.IsNullOrEmptyOrWhiteSpace() || orderNumber.Length > 32)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(OrderNumber)).GetPropertyDisplayName()),
                    nameof(orderNumber));
            }

            OrderNumber = orderNumber;
        }

        [RequiredIfValidation(nameof(OrderNumber), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Номер заказа в платежной системе")]
        public Guid? OrderId { get; }

        [RequiredIfValidation(nameof(OrderId), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Идентификатор заказа в системе магазина")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }
    }
}