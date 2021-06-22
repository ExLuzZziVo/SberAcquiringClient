using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class PaymentResultError
    {
        [Display(Name = "Код ошибки")] public int Code { get; set; }

        [Display(Name = "Описание ошибки")] public string Description { get; set; }

        [Display(Name = "Сообщение для пользователя с описанием ошибки")]
        public string Message { get; set; }
    }
}