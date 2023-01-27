#region

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
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