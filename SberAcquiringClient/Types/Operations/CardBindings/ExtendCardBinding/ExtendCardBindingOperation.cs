using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;

namespace SberAcquiringClient.Types.Operations.CardBindings.ExtendCardBinding
{
    /// <summary>
    /// Изменение срока действия связки
    /// </summary>
    public class ExtendCardBindingOperation : Operation<ExtendCardBindingResult>
    {
        /// <summary>
        /// Изменение срока действия связки
        /// </summary>
        /// <param name="bindingId">Идентификатор созданной ранее связки</param>
        /// <param name="newExpirationDate">Новая дата окончания срока действия карты</param>
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

        /// <summary>
        /// Новая дата окончания срока действия карты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Новая дата окончания срока действия карты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyyMM")]
        public DateTime NewExpiry { get; }
    }
}