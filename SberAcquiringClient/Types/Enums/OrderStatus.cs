using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Enums
{
    public enum OrderStatus : byte
    {
        [Display(Name = "Заказ зарегистрирован, но не оплачен")]
        Registered = 0,

        [Display(Name = "Предавторизованная сумма захолдирована")]
        AmountWithheld = 1,

        [Display(Name = "Проведена полная авторизация суммы заказа")]
        Completed = 2,

        [Display(Name = "Авторизация отменена")]
        Canceled = 3,

        [Display(Name = "По транзакции была проведена операция возврата")]
        Refunded = 4,

        [Display(Name = "Инициирована авторизация через ACS банка-эмитента")]
        IssuingBankAuthorization = 5,

        [Display(Name = "Авторизация отклонена")]
        AuthorizationDenied = 6
    }
}