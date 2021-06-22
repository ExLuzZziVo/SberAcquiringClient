using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Common;

namespace SberAcquiringClient.Types.Operations.CardBindings.GetCardBindings
{
    public class GetCardBindingsResult : OperationResult
    {
        [Display(Name = "Связки")] public BindingParams[] Bindings { get; set; }
    }
}