using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Operations.Orders.DeclineOrder
{
    public class DeclineOrderResult : OperationResult
    {
        [Display(Name = "Сообщение для пользователя с описанием кода результата")]
        public string UserMessage { get; set; }
    }
}