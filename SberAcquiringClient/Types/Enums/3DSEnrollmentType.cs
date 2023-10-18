#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
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