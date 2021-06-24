using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.Orders.OrderStatus
{
    /// <summary>
    /// Получение статуса заказа
    /// </summary>
    public class OrderStatusOperation : Operation<OrderStatusResult>
    {
        /// <summary>
        /// Получение статуса заказа
        /// </summary>
        /// <param name="orderId">Идентификатор заказа в платежной системе</param>
        public OrderStatusOperation(Guid orderId) : base("/payment/rest/getOrderStatus.do")
        {
            OrderId = orderId;
        }

        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public Guid OrderId { get; }
    }
}