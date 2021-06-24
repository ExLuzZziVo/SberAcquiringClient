using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Operations
{
    public abstract class OperationResult
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        [Display(Name = "Код ошибки")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// Описание ошибки
        /// </summary>
        [Display(Name = "Описание ошибки")]
        public string ErrorMessage { get; set; }
    }
}