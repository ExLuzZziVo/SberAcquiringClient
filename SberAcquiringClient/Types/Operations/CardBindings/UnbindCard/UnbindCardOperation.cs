using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.CardBindings.UnbindCard
{
    /// <summary>
    /// Деактивация связки
    /// </summary>
    public class UnbindCardOperation : Operation<UnbindCardResult>
    {
        /// <summary>
        /// Деактивация связки
        /// </summary>
        /// <param name="bindingId">Идентификатор созданной ранее связки</param>
        public UnbindCardOperation(string bindingId) : base("/payment/rest/unBindCard.do")
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

        /// <summary>
        /// Идентификатор созданной ранее связки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Идентификатор созданной ранее связки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string BindingId { get; }
    }
}