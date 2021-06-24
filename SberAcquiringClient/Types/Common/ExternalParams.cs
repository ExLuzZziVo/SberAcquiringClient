using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class ExternalParams
    {
        /// <summary>
        /// Ссылка на приложение банка для завершения оплаты
        /// </summary>
        [Display(Name = "Ссылка на приложение банка для завершения оплаты")]
        public string SbolDeepLink { get; set; }

        /// <summary>
        /// Уникальный идентификатор заказа, сгенерированный банком
        /// </summary>
        [Display(Name = "Уникальный идентификатор заказа, сгенерированный банком")]
        public string SbolBankInvoiceId { get; set; }

        /// <summary>
        /// Атрибут, информирующий о проходящих регламентных работах
        /// </summary>
        [Display(Name = "Атрибут, информирующий о проходящих регламентных работах")]
        public bool? SbolInactive { get; set; }
    }
}