#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Resources;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

#endregion

namespace SberAcquiringClient.Types.Operations.Orders.GetOrderStats
{
    /// <summary>
    /// Получение статистики по платежам за период
    /// </summary>
    public class GetOrderStatsOperation : Operation<GetOrderStatsResult>
    {
        /// <summary>
        /// Получение статистики по платежам за период
        /// </summary>
        /// <param name="startDateTime">Дата и время начала периода для выборки</param>
        /// <param name="endDateTime">Дата и время окончания периода для выборки</param>
        /// <param name="pageSize">Количество элементов на странице</param>
        /// <param name="transactionStates">Состояния заказов для выборки</param>
        public GetOrderStatsOperation(DateTime startDateTime, DateTime endDateTime, int pageSize,
            ISet<TransactionState> transactionStates) : base("/payment/rest/getLastOrdersForMerchants.do")
        {
            if (startDateTime > endDateTime)
            {
                throw new ArgumentOutOfRangeException(nameof(endDateTime), string.Format(
                    ValidationStrings.ResourceManager.GetString("CompareToGreaterThanError"),
                    GetType().GetProperty(nameof(To)).GetPropertyDisplayName(),
                    GetType().GetProperty(nameof(From)).GetPropertyDisplayName()));
            }

            if (!pageSize.IsInRange(1, 200))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize),
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Size)).GetPropertyDisplayName(), 1, 200));
            }

            if (transactionStates?.Any() != true)
            {
                throw new ArgumentException(string.Format(
                        ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(TransactionStates)).GetPropertyDisplayName(), 1),
                    nameof(transactionStates));
            }

            From = startDateTime;
            To = endDateTime;
            Size = pageSize;
            TransactionStates = transactionStates;
        }

        /// <summary>
        /// Индекс страницы
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0-<see cref="int.MaxValue"/></item>
        /// </list>
        [Display(Name = "Индекс страницы")]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? Page { get; set; }

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 1-200</item>
        /// </list>
        [Display(Name = "Количество элементов на странице")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(1, 200, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int Size { get; }

        /// <summary>
        /// Дата и время начала периода для выборки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Дата и время начала периода для выборки")]
        [CustomDateTimeConverter("yyyyMMddHHmmss")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public DateTime From { get; }

        /// <summary>
        /// Дата и время окончания периода для выборки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Дата и время окончания периода для выборки")]
        [CustomDateTimeConverter("yyyyMMddHHmmss")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public DateTime To { get; }

        /// <summary>
        /// Состояния заказов для выборки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное количество: 1</item>
        /// </list>
        [Display(Name = "Состояния заказов для выборки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [JsonParameterizedConverter(typeof(CollectionToStringWithSeparatorConverter<TransactionState>), ',', "")]
        public ISet<TransactionState> TransactionStates { get; }

        /// <summary>
        /// Список логинов продавцов для выборки
        /// </summary>
        [Display(Name = "Список логинов продавцов для выборки")]
        [JsonParameterizedConverter(typeof(CollectionToStringWithSeparatorConverter<string>), ',')]
        public ISet<string> Merchants { get; } = new HashSet<string>();

        /// <summary>
        /// Поиск заказов, дата создания которых попадает в заданный период
        /// </summary>
        [Display(Name = "Поиск заказов, дата создания которых попадает в заданный период")]
        public bool? SearchByCreatedDate { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (From > To)
            {
                yield return new ValidationResult(string.Format(
                    ValidationStrings.ResourceManager.GetString("CompareToGreaterThanError"),
                    GetType().GetProperty(nameof(To)).GetPropertyDisplayName(),
                    GetType().GetProperty(nameof(From)).GetPropertyDisplayName()), new[] { nameof(To) });
            }
        }
    }
}