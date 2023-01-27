#region

using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Operations.Orders.OrderStatusExtended;

#endregion

namespace SberAcquiringClient.Types.Operations.Orders.GetOrderStats
{
    /// <summary>
    /// Результат получения статистики по платежам за период
    /// </summary>
    public class GetOrderStatsResult : OperationResult
    {
        /// <summary>
        /// Общее количество элементов
        /// </summary>
        [Display(Name = "Общее количество элементов")]
        public int? TotalCount { get; set; }

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        [Display(Name = "Номер текущей страницы")]
        public int? Page { get; set; }

        /// <summary>
        /// Максимальное количество записей на странице
        /// </summary>
        [Display(Name = "Максимальное количество записей на странице")]
        public int? PageSize { get; set; }

        /// <summary>
        /// Содержимое страницы
        /// </summary>
        [Display(Name = "Содержимое страницы")]
        public OrderStatusExtendedResult[] OrderStatuses { get; set; }
    }
}