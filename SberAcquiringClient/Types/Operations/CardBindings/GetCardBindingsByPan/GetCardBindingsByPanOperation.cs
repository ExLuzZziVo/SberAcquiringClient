using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.IntHelpers;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.CardBindings.GetCardBindingsByPan
{
    public class GetCardBindingsByPanOperation : Operation<GetCardBindingsByPanResult>
    {
        public GetCardBindingsByPanOperation(ulong cardNumber) : base("/payment/rest/getBindingsByCardOrId.do")
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

        public GetCardBindingsByPanOperation(string bindingId) : base("/payment/rest/getBindingsByCardOrId.do")
        {
            if (bindingId.IsNullOrEmptyOrWhiteSpace() || bindingId.Length > 255)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(BindingId)).GetPropertyDisplayName()),
                    nameof(bindingId));
            }

            BindingId = bindingId;
        }

        [RequiredIfValidation(nameof(BindingId), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Номер карты")]
        [Range(100000000000, 9999999999999999999, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public ulong? Pan { get; }

        [RequiredIfValidation(nameof(Pan), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Идентификатор созданной ранее связки")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string BindingId { get; }

        [Display(Name = "Отображать связки с истёкшим сроком действия карты")]
        public bool? ShowExpired { get; set; }
    }
}