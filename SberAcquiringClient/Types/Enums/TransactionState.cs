#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionState : byte
    {
        /// <summary>
        /// Создан
        /// </summary>
        [Display(Name = "Создан")] CREATED,

        /// <summary>
        /// Утвержден
        /// </summary>
        [Display(Name = "Утвержден")] APPROVED,

        /// <summary>
        /// Оплачен
        /// </summary>
        [Display(Name = "Оплачен")] DEPOSITED,

        /// <summary>
        /// Отклонен
        /// </summary>
        [Display(Name = "Отклонен")] DECLINED,

        /// <summary>
        /// Отменен
        /// </summary>
        [Display(Name = "Отменен")] REVERSED,

        /// <summary>
        /// Возвращен
        /// </summary>
        [Display(Name = "Возвращен")] REFUNDED
    }
}