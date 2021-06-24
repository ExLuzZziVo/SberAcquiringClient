using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

namespace SberAcquiringClient.Types.Operations.PaymentSystems
{
    public abstract class PaymentSystemOperationResult : OperationResult
    {
        /// <summary>
        /// Флаг, указывающий на успешность запроса
        /// </summary>
        [Display(Name = "Флаг, указывающий на успешность запроса")]
        public bool Success { get; set; }

        /// <summary>
        /// Данные успешной оплаты
        /// </summary>
        [Display(Name = "Данные успешной оплаты")]
        public PaymentResultData Data { get; set; }

        /// <summary>
        /// Ошибки, возникшие при оплате
        /// </summary>
        [Display(Name = "Ошибки, возникшие при оплате")]
        public PaymentResultError Error { get; set; }
    }
}