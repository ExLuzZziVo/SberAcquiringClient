#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentSystem : byte
    {
        /// <summary>
        /// VISA
        /// </summary>
        [Display(Name = "VISA")] VISA,

        /// <summary>
        /// MASTERCARD
        /// </summary>
        [Display(Name = "MASTERCARD")] MASTERCARD,

        /// <summary>
        /// AMEX
        /// </summary>
        [Display(Name = "AMEX")] AMEX,

        /// <summary>
        /// JCB
        /// </summary>
        [Display(Name = "JCB")] JCB,

        /// <summary>
        /// CUP
        /// </summary>
        [Display(Name = "CUP")] CUP,

        /// <summary>
        /// MIR
        /// </summary>
        [Display(Name = "MIR")] MIR
    }
}