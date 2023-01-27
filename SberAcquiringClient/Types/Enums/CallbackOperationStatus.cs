#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    public enum CallbackOperationStatus : byte
    {
        /// <summary>
        /// Операция завершилась с ошибкой
        /// </summary>
        [Display(Name = "Операция завершилась с ошибкой")]
        Failed = 0,

        /// <summary>
        /// Операция прошла успешно
        /// </summary>
        [Display(Name = "Операция прошла успешно")]
        Success = 1
    }
}