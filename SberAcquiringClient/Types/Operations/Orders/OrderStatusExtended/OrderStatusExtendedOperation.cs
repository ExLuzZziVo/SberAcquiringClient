#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;

#endregion

namespace SberAcquiringClient.Types.Operations.Orders.OrderStatusExtended
{
    /// <summary>
    /// Получение расширенного статуса заказа
    /// </summary>
    public class OrderStatusExtendedOperation : Operation<OrderStatusExtendedResult>
    {
        /// <summary>
        /// Получение расширенного статуса заказа по его идентификатору в платежной системе
        /// </summary>
        /// <param name="orderId">Идентификатор заказа в платежной системе</param>
        public OrderStatusExtendedOperation(Guid orderId) : base("/payment/rest/getOrderStatusExtended.do")
        {
            OrderId = orderId;
        }

        /// <summary>
        /// Получение расширенного статуса заказа по его идентификатору в системе продавца
        /// </summary>
        /// <param name="orderNumber">Идентификатор заказа в системе продавца</param>
        public OrderStatusExtendedOperation(string orderNumber) : base("/payment/rest/getOrderStatusExtended.do")
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

        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="OrderNumber"/> не указан</item>
        /// </list>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        [RequiredIf(nameof(OrderNumber), null, ErrorMessageResourceType = typeof(ValidationStrings),
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
        [RequiredIf(nameof(OrderId), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }
    }
}