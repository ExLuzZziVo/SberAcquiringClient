using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class ExternalParams
    {
        [Display(Name = "Ссылка на приложение банка для завершения оплаты")]
        public string SbolDeepLink { get; set; }

        [Display(Name = "Уникальный идентификатор заказа, сгенерированный банком")]
        public string SbolBankInvoiceId { get; set; }

        [Display(Name = "Атрибут, информирующий о проходящих регламентных работах")]
        public bool? SbolInactive { get; set; }
    }
}