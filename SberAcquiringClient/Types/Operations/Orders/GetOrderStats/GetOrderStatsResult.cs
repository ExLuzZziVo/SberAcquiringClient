using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Operations.Orders.OrderStatusExtended;

namespace SberAcquiringClient.Types.Operations.Orders.GetOrderStats
{
    public class GetOrderStatsResult : OperationResult
    {
        [Display(Name = "Общее количество элементов")]
        public int? TotalCount { get; set; }

        [Display(Name = "Номер текущей страницы")]
        public int? Page { get; set; }

        [Display(Name = "Максимальное количество записей на странице")]
        public int? PageSize { get; set; }

        [Display(Name = "Содержимое страницы")]
        public OrderStatusExtendedResult[] OrderStatuses { get; set; }
    }
}