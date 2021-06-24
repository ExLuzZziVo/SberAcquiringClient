using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.Verify3DSEnrollment
{
    /// <summary>
    /// Проверка вовлечённости карты в 3-D Secure
    /// </summary>
    public class Verify3DSEnrollmentOperation : Operation<Verify3DSEnrollmentResult>
    {
        /// <summary>
        /// Проверка вовлечённости карты в 3-D Secure
        /// </summary>
        /// <param name="cardNumber">Номер карты</param>
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

        /// <summary>
        /// Номер карты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 100000000000-9999999999999999999</item>
        /// </list>
        [Display(Name = "Номер карты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(100000000000, 9999999999999999999, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public ulong Pan { get; }
    }
}