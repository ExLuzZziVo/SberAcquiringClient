using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BindingType : byte
    {
        [Display(Name = "Обычная связка для платежей вне определенного платежного графика или расписания")]
        C,

        [Display(Name = "Связка для платежей в рассрочку")]
        I,

        [Display(Name = "Связка для рекуррентных платежей")]
        R,

        [Display(Name = "Связка используется для хранения PAN получателя в P2P операциях")]
        CR
    }
}