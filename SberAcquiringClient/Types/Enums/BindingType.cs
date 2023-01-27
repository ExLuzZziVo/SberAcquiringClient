#region

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BindingType : byte
    {
        /// <summary>
        /// Обычная связка для платежей вне определенного платежного графика или расписания
        /// </summary>
        [Display(Name = "Обычная связка для платежей вне определенного платежного графика или расписания")]
        C,

        /// <summary>
        /// Связка для платежей в рассрочку
        /// </summary>
        [Display(Name = "Связка для платежей в рассрочку")]
        I,

        /// <summary>
        /// Связка для рекуррентных платежей
        /// </summary>
        [Display(Name = "Связка для рекуррентных платежей")]
        R,

        /// <summary>
        /// Связка используется для хранения PAN получателя в P2P операциях
        /// </summary>
        [Display(Name = "Связка используется для хранения PAN получателя в P2P операциях")]
        CR
    }
}