using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.Orders.OrderStatus
{
    public class OrderStatusOperation : Operation<OrderStatusResult>
    {
        public OrderStatusOperation(Guid orderId) : base("/payment/rest/getOrderStatus.do")
        {
            OrderId = orderId;
        }

        [Display(Name = "Номер заказа в платежной системе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public Guid OrderId { get; }
    }
}