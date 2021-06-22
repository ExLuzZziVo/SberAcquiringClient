using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Operations
{
    public abstract class OperationResult
    {
        [Display(Name = "Код ошибки")] public int ErrorCode { get; set; }

        [Display(Name = "Описание ошибки")] public string ErrorMessage { get; set; }
    }
}