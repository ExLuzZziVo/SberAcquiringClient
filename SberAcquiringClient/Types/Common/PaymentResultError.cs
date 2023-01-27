#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace SberAcquiringClient.Types.Common
{
    public class PaymentResultError
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        [Display(Name = "Код ошибки")]
        public int Code { get; set; }

        /// <summary>
        /// Описание ошибки
        /// </summary>
        [Display(Name = "Описание ошибки")]
        public string Description { get; set; }

        /// <summary>
        /// Сообщение для пользователя с описанием ошибки
        /// </summary>
        [Display(Name = "Сообщение для пользователя с описанием ошибки")]
        public string Message { get; set; }
    }
}