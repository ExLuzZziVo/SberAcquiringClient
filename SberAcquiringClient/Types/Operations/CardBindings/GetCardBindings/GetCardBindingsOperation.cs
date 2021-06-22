using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Operations.CardBindings.GetCardBindings
{
    public class GetCardBindingsOperation : Operation<GetCardBindingsResult>
    {
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

        [Display(Name = "Идентификатор клиента в системе магазина")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string ClientId { get; }

        [Display(Name = "Тип связки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public BindingType BindingType { get; }

        [Display(Name = "Идентификатор созданной ранее связки")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string BindingId { get; set; }

        [Display(Name = "Отображать связки с истёкшим сроком действия карты")]
        public bool? ShowExpired { get; set; }
    }
}