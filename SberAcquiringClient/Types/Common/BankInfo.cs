using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class BankInfo
    {
        [Display(Name = "Наименование банка-эмитента")]
        public string BankName { get; set; }

        [Display(Name = "Код страны банка-эмитента")]
        public string BankCountryCode { get; set; }

        [Display(Name = "Наименование страны банка-эмитента")]
        public string BankCountryName { get; set; }
    }
}