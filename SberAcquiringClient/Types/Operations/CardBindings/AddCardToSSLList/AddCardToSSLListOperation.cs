#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;

#endregion

namespace SberAcquiringClient.Types.Operations.CardBindings.AddCardToSSLList
{
    /// <summary>
    /// Добавление карты в список SSL-карт
    /// </summary>
    public class AddCardToSSLListOperation : Operation<AddCardToSSLListResult>
    {
        /// <summary>
        /// Добавление карты в список SSL-карт
        /// </summary>
        /// <param name="orderId">Идентификатор заказа в платежной системе</param>
        public AddCardToSSLListOperation(Guid orderId) : base("/payment/rest/updateSSLCardList.do")
        {
            Mdorder = orderId;
        }

        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public Guid Mdorder { get; }
    }
}