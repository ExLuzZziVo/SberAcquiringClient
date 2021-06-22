using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;
using SberAcquiringClient.Resources;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Operations.Orders.GetOrderStats
{
    public class GetOrderStatsOperation : Operation<GetOrderStatsResult>
    {
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

        [Display(Name = "Индекс страницы")]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? Page { get; set; }

        [Display(Name = "Количество элементов на странице")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(1, 200, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int Size { get; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyyMMddHHmmss")]
        [Display(Name = "Дата и время начала периода для выборки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public DateTime From { get; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyyMMddHHmmss")]
        [Display(Name = "Дата и время окончания периода для выборки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public DateTime To { get; }

        [Display(Name = "Состояния заказов для выборки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [JsonConverter(typeof(CollectionToStringWithSeparatorConverter<TransactionState>), ',', "")]
        public ISet<TransactionState> TransactionStates { get; }

        [Display(Name = "Список логинов продавцов для выборки")]
        [JsonConverter(typeof(CollectionToStringWithSeparatorConverter<string>), ',')]
        public ISet<string> Merchants { get; } = new HashSet<string>();

        [Display(Name = "Поиск заказов, дата создания которых попадает в заданный период")]
        public bool? SearchByCreatedDate { get; set; }

        protected override IEnumerable<ValidationResult> Validate()
        {
            var validationResults = base.Validate();

            if (From > To)
            {
                validationResults = new List<ValidationResult>(validationResults)
                {
                    new ValidationResult(string.Format(
                        ValidationStrings.ResourceManager.GetString("CompareToGreaterThanError"),
                        GetType().GetProperty(nameof(To)).GetPropertyDisplayName(),
                        GetType().GetProperty(nameof(From)).GetPropertyDisplayName()))
                };
            }

            return validationResults;
        }
    }
}