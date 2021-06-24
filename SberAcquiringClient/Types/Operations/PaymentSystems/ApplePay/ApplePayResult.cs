using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Operations.Orders.OrderStatusExtended;

namespace SberAcquiringClient.Types.Operations.PaymentSystems.ApplePay
{
    /// <summary>
    /// Результат оплаты с помощью Apple Pay
    /// </summary>
    public class ApplePayResult : PaymentSystemOperationResult
    {
        /// <summary>
        /// Статус заказа
        /// </summary>
        [Display(Name = "Статус заказа")]
        public OrderStatusExtendedResult OrderStatus { get; set; }
    }
}