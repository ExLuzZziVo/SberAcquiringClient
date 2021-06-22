using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Enums
{
    public enum CallbackOperationStatus : byte
    {
        [Display(Name = "Операция завершилась с ошибкой")]
        Failed = 0,

        [Display(Name = "Операция прошла успешно")]
        Success = 1
    }
}