#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;

#endregion

namespace SberAcquiringClient.Types.Operations.CardBindings.GetCardBindingsByPan
{
    /// <summary>
    /// Получение списка связок определённой банковской карты
    /// </summary>
    public class GetCardBindingsByPanOperation : Operation<GetCardBindingsByPanResult>
    {
        /// <summary>
        /// Получение списка связок определённой банковской карты по ее номеру
        /// </summary>
        /// <param name="cardNumber">Номер карты</param>
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

        /// <summary>
        /// Получение списка связок определённой банковской карты по идентификатору созданной ранее связки
        /// </summary>
        /// <param name="bindingId">Идентификатор созданной ранее связки</param>
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

        /// <summary>
        /// Номер карты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="BindingId"/> не указан</item>
        /// <item>Должно лежать в диапазоне: 100000000000-9999999999999999999</item>
        /// </list>
        [Display(Name = "Номер карты")]
        [RequiredIf(nameof(BindingId), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [Range(100000000000, 9999999999999999999, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public ulong? Pan { get; }

        /// <summary>
        /// Идентификатор созданной ранее связки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="Pan"/> не указан</item>
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Идентификатор созданной ранее связки")]
        [RequiredIf(nameof(Pan), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string BindingId { get; }

        /// <summary>
        /// Отображать связки с истёкшим сроком действия карты
        /// </summary>
        [Display(Name = "Отображать связки с истёкшим сроком действия карты")]
        public bool? ShowExpired { get; set; }
    }
}