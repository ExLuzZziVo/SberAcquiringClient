#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    public enum FiscalReceiptStatus : byte
    {
        /// <summary>
        /// Чек прихода отправлен
        /// </summary>
        [Display(Name = "Чек прихода отправлен")]
        SellSent = 0,

        /// <summary>
        /// Чек прихода доставлен
        /// </summary>
        [Display(Name = "Чек прихода доставлен")]
        SellDelivered = 1,

        /// <summary>
        /// Ошибка чека прихода
        /// </summary>
        [Display(Name = "Ошибка чека прихода")]
        SellError = 2,

        /// <summary>
        /// Чек возврата прихода отправлен
        /// </summary>
        [Display(Name = "Чек возврата прихода отправлен")]
        SellReturnSent = 3,

        /// <summary>
        /// Чек возврата прихода доставлен
        /// </summary>
        [Display(Name = "Чек возврата прихода доставлен")]
        SellReturnDelivered = 4,

        /// <summary>
        /// Ошибка чека возврата прихода
        /// </summary>
        [Display(Name = "Ошибка чека возврата прихода")]
        SellReturnError = 5
    }
}