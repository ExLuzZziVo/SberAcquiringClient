using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class BankInfo
    {
        /// <summary>
        /// Наименование банка-эмитента
        /// </summary>
        [Display(Name = "Наименование банка-эмитента")]
        public string BankName { get; set; }

        /// <summary>
        /// Код страны банка-эмитента
        /// </summary>
        [Display(Name = "Код страны банка-эмитента")]
        public string BankCountryCode { get; set; }

        /// <summary>
        /// Наименование страны банка-эмитента
        /// </summary>
        [Display(Name = "Наименование страны банка-эмитента")]
        public string BankCountryName { get; set; }
    }
}