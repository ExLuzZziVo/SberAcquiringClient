#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RegisterOrderFeatures : byte
    {
        /// <summary>
        /// Платёж проводится без проверки подлинности владельца карты
        /// </summary>
        [Display(Name = "Платёж проводится без проверки подлинности владельца карты")]
        AUTO_PAYMENT,

        /// <summary>
        /// Принудительное проведение платежа с использованием проверки на вовлеченность в 3DS
        /// </summary>
        [Display(Name = "Принудительное проведение платежа с использованием проверки на вовлеченность в 3DS")]
        FORCE_TDS,

        /// <summary>
        /// Принудительное проведение платежа через SSL
        /// </summary>
        [Display(Name = "Принудительное проведение платежа через SSL")]
        FORCE_SSL,

        /// <summary>
        /// После проведения аутентификации с помощью 3-D Secure статус PaRes должен быть только Y
        /// </summary>
        [Display(Name = "После проведения аутентификации с помощью 3-D Secure статус PaRes должен быть только Y")]
        FORCE_FULL_TDS
    }
}