using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionState : byte
    {
        [Display(Name = "Создан")] CREATED,
        [Display(Name = "Утвержден")] APPROVED,
        [Display(Name = "Оплачен")] DEPOSITED,
        [Display(Name = "Отклонен")] DECLINED,
        [Display(Name = "Отменен")] REVERSED,
        [Display(Name = "Возвращен")] REFUNDED
    }
}