using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;

namespace SberAcquiringClient.Types.Operations.CardBindings.AddCardToSSLList
{
    public class AddCardToSSLListOperation : Operation<AddCardToSSLListResult>
    {
        public AddCardToSSLListOperation(Guid orderId) : base("/payment/rest/updateSSLCardList.do")
        {
            Mdorder = orderId;
        }

        [Display(Name = "Номер заказа в платежной системе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public Guid Mdorder { get; }
    }
}