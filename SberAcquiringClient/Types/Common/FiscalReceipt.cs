using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class FiscalReceipt
    {
        [Display(Name = "Состояние фискального чека")]
        public FiscalReceiptStatus? ReceiptStatus { get; set; }

        [Display(Name = "Идентификатор чека в фискализаторе")]
        public Guid? Uuid { get; set; }

        [Display(Name = "Номер смены")] public int? Shift_Number { get; set; }

        [Display(Name = "Номер чека в смене")] public int? Receipt_Number { get; set; }

        [Display(Name = "Дата и время чека в фискальном накопителе")]
        [JsonConverter(typeof(UnixTimestampConverter), true)]
        public DateTime? Receipt_DateTime { get; set; }

        [Display(Name = "Номер фискального накопителя")]
        public string Fn_Number { get; set; }

        [Display(Name = "Регистрационный номер контрольно-кассовой техники")]
        public string Ecr_registration_number { get; set; }

        [Display(Name = "Фискальный номер документа")]
        public int? Fiscal_Document_Number { get; set; }

        [Display(Name = "Фискальный признак документа")]
        public string Fiscal_Document_Attribute { get; set; }

        [Display(Name = "Итоговая сумма чека в рублях")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount_Total { get; set; }

        [Display(Name = "Заводской номер ККТ")]
        public string Serial_Number { get; set; }

        [Display(Name = "Адрес сайта ФНС")] public string FnsSite { get; set; }

        [Display(Name = "Данные ОФД")] public Ofd Ofd { get; set; }
    }
}