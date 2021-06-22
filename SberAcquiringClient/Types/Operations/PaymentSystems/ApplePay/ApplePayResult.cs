using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;
using SberAcquiringClient.Types.Operations.Orders.OrderStatusExtended;

namespace SberAcquiringClient.Types.Operations.PaymentSystems.ApplePay
{
    public class ApplePayResult : PaymentSystemOperationResult
    {
        [Display(Name = "Статус заказа")] public OrderStatusExtendedResult OrderStatus { get; set; }
    }
}