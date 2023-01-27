#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

#endregion

namespace SberAcquiringClient.Types.Common
{
    public class FiscalReceipt
    {
        /// <summary>
        /// Состояние фискального чека
        /// </summary>
        [Display(Name = "Состояние фискального чека")]
        public FiscalReceiptStatus? ReceiptStatus { get; set; }

        /// <summary>
        /// Идентификатор чека в фискализаторе
        /// </summary>
        [Display(Name = "Идентификатор чека в фискализаторе")]
        public Guid? Uuid { get; set; }

        /// <summary>
        /// Номер смены
        /// </summary>
        [Display(Name = "Номер смены")]
        public int? Shift_Number { get; set; }

        /// <summary>
        /// Номер чека в смене
        /// </summary>
        [Display(Name = "Номер чека в смене")]
        public int? Receipt_Number { get; set; }

        /// <summary>
        /// Дата и время чека в фискальном накопителе
        /// </summary>
        [Display(Name = "Дата и время чека в фискальном накопителе")]
        [JsonConverter(typeof(UnixTimestampConverter), true)]
        public DateTime? Receipt_DateTime { get; set; }

        /// <summary>
        /// Номер фискального накопителя
        /// </summary>
        [Display(Name = "Номер фискального накопителя")]
        public string Fn_Number { get; set; }

        /// <summary>
        /// Регистрационный номер контрольно-кассовой техники
        /// </summary>
        [Display(Name = "Регистрационный номер контрольно-кассовой техники")]
        public string Ecr_registration_number { get; set; }

        /// <summary>
        /// Фискальный номер документа
        /// </summary>
        [Display(Name = "Фискальный номер документа")]
        public int? Fiscal_Document_Number { get; set; }

        /// <summary>
        /// Фискальный признак документа
        /// </summary>
        [Display(Name = "Фискальный признак документа")]
        public string Fiscal_Document_Attribute { get; set; }

        /// <summary>
        /// Итоговая сумма чека в рублях
        /// </summary>
        [Display(Name = "Итоговая сумма чека в рублях")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount_Total { get; set; }

        /// <summary>
        /// Заводской номер ККТ
        /// </summary>
        [Display(Name = "Заводской номер ККТ")]
        public string Serial_Number { get; set; }

        /// <summary>
        /// Адрес сайта ФНС
        /// </summary>
        [Display(Name = "Адрес сайта ФНС")]
        public string FnsSite { get; set; }

        /// <summary>
        /// Данные ОФД
        /// </summary>
        [Display(Name = "Данные ОФД")]
        public Ofd Ofd { get; set; }
    }
}