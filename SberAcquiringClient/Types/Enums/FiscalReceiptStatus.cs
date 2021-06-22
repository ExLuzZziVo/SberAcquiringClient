using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Enums
{
    public enum FiscalReceiptStatus : byte
    {
        [Display(Name = "Чек прихода отправлен")]
        SellSent = 0,

        [Display(Name = "Чек прихода доставлен")]
        SellDelivered = 1,

        [Display(Name = "Ошибка чека прихода")]
        SellError = 2,

        [Display(Name = "Чек возврата прихода отправлен")]
        SellReturnSent = 3,

        [Display(Name = "Чек возврата прихода доставлен")]
        SellReturnDelivered = 4,

        [Display(Name = "Ошибка чека возврата прихода")]
        SellReturnError = 5
    }
}