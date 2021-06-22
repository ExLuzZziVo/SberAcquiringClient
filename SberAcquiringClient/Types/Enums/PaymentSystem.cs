using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentSystem : byte
    {
        [Display(Name = "VISA")] VISA,
        [Display(Name = "MASTERCARD")] MASTERCARD,
        [Display(Name = "AMEX")] AMEX,
        [Display(Name = "JCB")] JCB,
        [Display(Name = "CUP")] CUP,
        [Display(Name = "MIR")] MIR
    }
}