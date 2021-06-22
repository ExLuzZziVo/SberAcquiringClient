using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SamsungPayWebResultType : byte
    {
        [Display(Name = "Операция успешна")] SUCCESSFUL,

        [Display(Name = "Неверное состояние транзакции")]
        WRONG_TRANSACTION_STATE,
        [Display(Name = "Ошибка соединения")] CONNECTION_ERROR
    }
}