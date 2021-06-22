using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class PayerData
    {
        [Display(Name = "Адрес электронной почты покупателя")]
        public string Email { get; set; }

        [Display(Name = "Информация о транзакции")]
        public TransactionAttributes TransactionAttributes { get; set; }
    }
}