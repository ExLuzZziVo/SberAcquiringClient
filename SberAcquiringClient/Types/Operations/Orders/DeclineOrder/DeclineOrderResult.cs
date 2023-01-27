#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace SberAcquiringClient.Types.Operations.Orders.DeclineOrder
{
    /// <summary>
    /// Результат отмены неоплаченного заказа
    /// </summary>
    public class DeclineOrderResult : OperationResult
    {
        /// <summary>
        /// Сообщение для пользователя с описанием кода результата
        /// </summary>
        [Display(Name = "Сообщение для пользователя с описанием кода результата")]
        public string UserMessage { get; set; }
    }
}