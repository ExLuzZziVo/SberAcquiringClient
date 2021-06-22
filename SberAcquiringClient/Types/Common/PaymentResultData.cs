using System;
using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class PaymentResultData
    {
        [Display(Name = "Номер заказа в платежной системе")]
        public Guid? OrderId { get; set; }

        [Display(Name = "Идентификатор связки")]
        public string BindingId { get; set; }

        [Display(Name = "URL-адрес для перехода на сервер контроля доступа")]
        public string AcsUrl { get; set; }

        [Display(Name = "Запрос на аутентификацию платежа")]
        public string PaReq { get; set; }

        [Display(Name = "URL-адрес для возврата с сервера контроля доступа")]
        public string TermUrl { get; set; }
    }
}