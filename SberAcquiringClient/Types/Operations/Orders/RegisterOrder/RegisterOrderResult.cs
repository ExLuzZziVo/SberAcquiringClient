using System;
using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

namespace SberAcquiringClient.Types.Operations.Orders.RegisterOrder
{
    public class RegisterOrderResult : OperationResult
    {
        [Display(Name = "Номер заказа в платежной системе")]
        public Guid? OrderId { get; set; }

        [Display(Name = "URL платежной формы")]
        public string FormUrl { get; set; }

        [Display(Name = "Дополнительные параметры, при оплате по схемам app2app и back2app")]
        public ExternalParams ExternalParams { get; set; }
    }
}