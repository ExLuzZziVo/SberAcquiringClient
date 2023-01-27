#region

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum _3DSEnrollmentType : byte
    {
        /// <summary>
        /// Да
        /// </summary>
        [Display(Name = "Да")] Y,

        /// <summary>
        /// Нет
        /// </summary>
        [Display(Name = "Нет")] N,

        /// <summary>
        /// Неизвестно
        /// </summary>
        [Display(Name = "Неизвестно")] U
    }
}