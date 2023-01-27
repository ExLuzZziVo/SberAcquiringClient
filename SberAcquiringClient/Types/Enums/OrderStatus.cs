#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    public enum OrderStatus : byte
    {
        /// <summary>
        /// Заказ зарегистрирован, но не оплачен
        /// </summary>
        [Display(Name = "Заказ зарегистрирован, но не оплачен")]
        Registered = 0,

        /// <summary>
        /// Предавторизованная сумма захолдирована
        /// </summary>
        [Display(Name = "Предавторизованная сумма захолдирована")]
        AmountWithheld = 1,

        /// <summary>
        /// Проведена полная авторизация суммы заказа
        /// </summary>
        [Display(Name = "Проведена полная авторизация суммы заказа")]
        Completed = 2,

        /// <summary>
        /// Авторизация отменена
        /// </summary>
        [Display(Name = "Авторизация отменена")]
        Canceled = 3,

        /// <summary>
        /// По транзакции была проведена операция возврата
        /// </summary>
        [Display(Name = "По транзакции была проведена операция возврата")]
        Refunded = 4,

        /// <summary>
        /// Инициирована авторизация через ACS банка-эмитента
        /// </summary>
        [Display(Name = "Инициирована авторизация через ACS банка-эмитента")]
        IssuingBankAuthorization = 5,

        /// <summary>
        /// Авторизация отклонена
        /// </summary>
        [Display(Name = "Авторизация отклонена")]
        AuthorizationDenied = 6
    }
}