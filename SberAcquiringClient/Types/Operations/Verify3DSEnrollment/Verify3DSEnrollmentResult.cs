using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Operations.Verify3DSEnrollment
{
    public class Verify3DSEnrollmentResult : OperationResult
    {
        [Display(Name = "Признак вовлечённости карты в 3DS")]
        public _3DSEnrollmentType? Enrolled { get; set; }

        [Display(Name = "Наименование банка-эмитента")]
        public string EmitterName { get; set; }

        [Display(Name = "Код страны банка-эмитента")]
        public string EmitterCountryCode { get; set; }
    }
}