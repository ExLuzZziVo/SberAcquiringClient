using System;
using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

namespace SberAcquiringClient.Types.Operations.GetFiscalReceiptStatus
{
    /// <summary>
    /// Результат получения сведений о кассовом чеке
    /// </summary>
    public class GetFiscalReceiptStatusResult : OperationResult
    {
        /// <summary>
        /// Идентификатор заказа в системе продавца
        /// </summary>
        [Display(Name = "Идентификатор заказа в системе продавца")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        public Guid? OrderId { get; set; }

        /// <summary>
        /// Наименование сервера
        /// </summary>
        [Display(Name = "Наименование сервера")]
        public string DaemonCode { get; set; }

        /// <summary>
        /// Регистрационный номер ККТ
        /// </summary>
        [Display(Name = "Регистрационный номер ККТ")]
        public string Ecr_registration_number { get; set; }

        /// <summary>
        /// Данные фискального чека
        /// </summary>
        [Display(Name = "Данные фискального чека")]
        public FiscalReceipt Receipt { get; set; }
    }
}