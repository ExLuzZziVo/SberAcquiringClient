#region

using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

#endregion

namespace SberAcquiringClient.Types.Operations.CardBindings.GetCardBindingsByPan
{
    /// <summary>
    /// Результат получения списка связок определённой банковской карты
    /// </summary>
    public class GetCardBindingsByPanResult : OperationResult
    {
        /// <summary>
        /// Связки
        /// </summary>
        [Display(Name = "Связки")]
        public BindingParams[] Bindings { get; set; }
    }
}