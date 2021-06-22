using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RegisterOrderFeatures : byte
    {
        [Display(Name = "Платёж проводится без проверки подлинности владельца карты")]
        AUTO_PAYMENT,

        [Display(Name = "Принудительное проведение платежа с использованием проверки на вовлеченность в 3DS")]
        FORCE_TDS,

        [Display(Name = "Принудительное проведение платежа через SSL")]
        FORCE_SSL,

        [Display(Name = "После проведения аутентификации с помощью 3-D Secure статус PaRes должен быть только Y")]
        FORCE_FULL_TDS
    }
}