using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.Verify3DSEnrollment
{
    public class Verify3DSEnrollmentOperation : Operation<Verify3DSEnrollmentResult>
    {
        public Verify3DSEnrollmentOperation(ulong cardNumber) : base("/payment/rest/verifyEnrollment.do")
        {
            if (!cardNumber.IsInRange(100000000000ul, 9999999999999999999ul))
            {
                throw new ArgumentOutOfRangeException(nameof(cardNumber),
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Pan)).GetPropertyDisplayName(), 100000000000,
                        9999999999999999999));
            }

            Pan = cardNumber;
        }

        [Display(Name = "Номер карты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(100000000000, 9999999999999999999, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public ulong Pan { get; }
    }
}