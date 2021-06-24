using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SamsungPayWebResultType : byte
    {
        /// <summary>
        /// Операция успешна
        /// </summary>
        [Display(Name = "Операция успешна")] SUCCESSFUL,

        /// <summary>
        /// Неверное состояние транзакции
        /// </summary>
        [Display(Name = "Неверное состояние транзакции")]
        WRONG_TRANSACTION_STATE,

        /// <summary>
        /// Ошибка соединения
        /// </summary>
        [Display(Name = "Ошибка соединения")] CONNECTION_ERROR
    }
}