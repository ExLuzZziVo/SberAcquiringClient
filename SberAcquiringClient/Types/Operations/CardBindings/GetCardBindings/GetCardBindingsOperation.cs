#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using SberAcquiringClient.Types.Enums;

#endregion

namespace SberAcquiringClient.Types.Operations.CardBindings.GetCardBindings
{
    /// <summary>
    /// Получение списка всех связок клиента
    /// </summary>
    public class GetCardBindingsOperation : Operation<GetCardBindingsResult>
    {
        /// <summary>
        /// Получение списка всех связок клиента
        /// </summary>
        /// <param name="clientId">Идентификатор клиента в системе продавца</param>
        /// <param name="bindingType">Тип связки</param>
        public GetCardBindingsOperation(string clientId, BindingType bindingType) : base("/payment/rest/getBindings.do")
        {
            if (clientId.IsNullOrEmptyOrWhiteSpace() || clientId.Length > 255)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(ClientId)).GetPropertyDisplayName()),
                    nameof(clientId));
            }

            ClientId = clientId;
            BindingType = bindingType;
        }

        /// <summary>
        /// Идентификатор клиента в системе продавца
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Идентификатор клиента в системе продавца")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string ClientId { get; }

        /// <summary>
        /// Тип связки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Тип связки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public BindingType BindingType { get; }

        /// <summary>
        /// Идентификатор созданной ранее связки
        /// </summary>
        /// <list type="bullets">
        /// <item>Максимальная длина: 255</item>
        /// </list>
        [Display(Name = "Идентификатор созданной ранее связки")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string BindingId { get; set; }

        /// <summary>
        /// Отображать связки с истёкшим сроком действия карты
        /// </summary>
        [Display(Name = "Отображать связки с истёкшим сроком действия карты")]
        public bool? ShowExpired { get; set; }
    }
}