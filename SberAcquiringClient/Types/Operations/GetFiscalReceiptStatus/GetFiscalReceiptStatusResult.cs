using System;
using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

namespace SberAcquiringClient.Types.Operations.GetFiscalReceiptStatus
{
    public class GetFiscalReceiptStatusResult : OperationResult
    {
        [Display(Name = "Идентификатор заказа в системе магазина")]
        public string OrderNumber { get; set; }

        [Display(Name = "Номер заказа в платежной системе")]
        public Guid? OrderId { get; set; }

        [Display(Name = "Наименование сервера")]
        public string DaemonCode { get; set; }

        [Display(Name = "Регистрационный номер ККТ")]
        public string Ecr_registration_number { get; set; }

        [Display(Name = "Данные фискального чека")]
        public FiscalReceipt Receipt { get; set; }
    }
}