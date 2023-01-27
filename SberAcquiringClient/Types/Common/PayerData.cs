#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace SberAcquiringClient.Types.Common
{
    public class PayerData
    {
        /// <summary>
        /// Адрес электронной почты покупателя
        /// </summary>
        [Display(Name = "Адрес электронной почты покупателя")]
        public string Email { get; set; }

        /// <summary>
        /// Информация о транзакции
        /// </summary>
        [Display(Name = "Информация о транзакции")]
        public TransactionAttributes TransactionAttributes { get; set; }
    }
}