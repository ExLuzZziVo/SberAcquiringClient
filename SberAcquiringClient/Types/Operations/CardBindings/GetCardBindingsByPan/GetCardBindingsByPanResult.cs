using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

namespace SberAcquiringClient.Types.Operations.CardBindings.GetCardBindingsByPan
{
    public class GetCardBindingsByPanResult : OperationResult
    {
        [Display(Name = "Связки")] public BindingParams[] Bindings { get; set; }
    }
}