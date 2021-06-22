using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

namespace SberAcquiringClient.Types.Operations.PaymentSystems
{
    public abstract class PaymentSystemOperationResult : OperationResult
    {
        [Display(Name = "Флаг, указывающий на успешность запроса")]
        public bool Success { get; set; }

        [Display(Name = "Данные успешной оплаты")]
        public PaymentResultData Data { get; set; }

        [Display(Name = "Ошибки, возникшие при оплате")]
        public PaymentResultError Error { get; set; }
    }
}