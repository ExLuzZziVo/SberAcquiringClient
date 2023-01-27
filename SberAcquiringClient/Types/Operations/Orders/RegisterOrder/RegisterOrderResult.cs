#region

using System;
using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

#endregion

namespace SberAcquiringClient.Types.Operations.Orders.RegisterOrder
{
    /// <summary>
    /// Результат регистрации заказа
    /// </summary>
    public class RegisterOrderResult : OperationResult
    {
        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        public Guid? OrderId { get; set; }

        /// <summary>
        /// URL платежной формы
        /// </summary>
        [Display(Name = "URL платежной формы")]
        public string FormUrl { get; set; }

        /// <summary>
        /// Дополнительные параметры, при оплате по схемам app2app и back2app
        /// </summary>
        [Display(Name = "Дополнительные параметры, при оплате по схемам app2app и back2app")]
        public ExternalParams ExternalParams { get; set; }
    }
}