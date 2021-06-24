using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Operations.Verify3DSEnrollment
{
    /// <summary>
    /// Результат проверки вовлечённости карты в 3-D Secure
    /// </summary>
    public class Verify3DSEnrollmentResult : OperationResult
    {
        /// <summary>
        /// Признак вовлечённости карты в 3DS
        /// </summary>
        [Display(Name = "Признак вовлечённости карты в 3DS")]
        public _3DSEnrollmentType? Enrolled { get; set; }

        /// <summary>
        /// Наименование банка-эмитента
        /// </summary>
        [Display(Name = "Наименование банка-эмитента")]
        public string EmitterName { get; set; }

        /// <summary>
        /// Код страны банка-эмитента
        /// </summary>
        [Display(Name = "Код страны банка-эмитента")]
        public string EmitterCountryCode { get; set; }
    }
}