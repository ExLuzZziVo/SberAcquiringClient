using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;

namespace SberAcquiringClient.Types.Operations.CardBindings.ExtendCardBinding
{
    public class ExtendCardBindingOperation : Operation<ExtendCardBindingResult>
    {
        public ExtendCardBindingOperation(string bindingId, DateTime newExpirationDate) : base(
            "/payment/rest/extendBinding.do")
        {
            if (bindingId.IsNullOrEmptyOrWhiteSpace() || bindingId.Length > 255)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(BindingId)).GetPropertyDisplayName()),
                    nameof(bindingId));
            }

            if (newExpirationDate <= DateTime.Now)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("CompareToGreaterThanError"),
                        GetType().GetProperty(nameof(BindingId)).GetPropertyDisplayName(),
                        DateTime.Now.Date.ToString("d")),
                    nameof(bindingId));
            }

            BindingId = bindingId;
            NewExpiry = newExpirationDate;
        }

        [Display(Name = "Идентификатор созданной ранее связки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string BindingId { get; }

        [Display(Name = "Новая дата окончания срока действия карты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyyMM")]
        public DateTime NewExpiry { get; }
    }
}