using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum _3DSEnrollmentType : byte
    {
        [Display(Name = "Да")] Y,
        [Display(Name = "Нет")] N,
        [Display(Name = "Неизвестно")] U
    }
}