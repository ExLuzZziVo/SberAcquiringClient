#region

using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

#endregion

namespace SberAcquiringClient.Types.Operations.CardBindings.GetCardBindings
{
    /// <summary>
    /// Результат получения списка всех связок клиента
    /// </summary>
    public class GetCardBindingsResult : OperationResult
    {
        /// <summary>
        /// Связки
        /// </summary>
        [Display(Name = "Связки")]
        public BindingParams[] Bindings { get; set; }
    }
}