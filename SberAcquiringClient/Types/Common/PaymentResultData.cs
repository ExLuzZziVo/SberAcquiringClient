using System;
using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class PaymentResultData
    {
        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        public Guid? OrderId { get; set; }

        /// <summary>
        /// Идентификатор связки
        /// </summary>
        [Display(Name = "Идентификатор связки")]
        public string BindingId { get; set; }

        /// <summary>
        /// URL-адрес для перехода на сервер контроля доступа
        /// </summary>
        [Display(Name = "URL-адрес для перехода на сервер контроля доступа")]
        public string AcsUrl { get; set; }

        /// <summary>
        /// Запрос на аутентификацию платежа
        /// </summary>
        [Display(Name = "Запрос на аутентификацию платежа")]
        public string PaReq { get; set; }

        /// <summary>
        /// URL-адрес для возврата с сервера контроля доступа
        /// </summary>
        [Display(Name = "URL-адрес для возврата с сервера контроля доступа")]
        public string TermUrl { get; set; }
    }
}