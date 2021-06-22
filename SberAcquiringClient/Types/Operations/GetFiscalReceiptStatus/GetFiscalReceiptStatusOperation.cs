using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using SberAcquiringClient.Resources;

namespace SberAcquiringClient.Types.Operations.GetFiscalReceiptStatus
{
    public class GetFiscalReceiptStatusOperation : Operation<GetFiscalReceiptStatusResult>
    {
        public GetFiscalReceiptStatusOperation(Guid id, bool isOrderId = true) : base(
            "/payment/rest/getReceiptStatus.do")
        {
            if (isOrderId)
            {
                OrderId = id;
            }
            else
            {
                Uuid = id;
            }
        }

        public GetFiscalReceiptStatusOperation(string orderNumber) : base("/payment/rest/getReceiptStatus.do")
        {
            if (orderNumber.IsNullOrEmptyOrWhiteSpace() || orderNumber.Length > 32)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(OrderNumber)).GetPropertyDisplayName()),
                    nameof(orderNumber));
            }

            OrderNumber = orderNumber;
        }

        [Display(Name = "Идентификатор заказа в платежной системе")]
        public Guid? OrderId { get; }

        [Display(Name = "Идентификатор заказа в системе магазина")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }

        [Display(Name = "Идентификатор чека в фискализаторе")]
        public Guid? Uuid { get; }

        protected override IEnumerable<ValidationResult> Validate()
        {
            var validationResults = base.Validate();

            if (OrderId == null && OrderNumber.IsNullOrEmptyOrWhiteSpace() && Uuid == null)
            {
                validationResults = new List<ValidationResult>(validationResults)
                {
                    new ValidationResult(ErrorStrings.ResourceManager.GetString("GetFiscalReceiptStatusRequiredError"))
                };
            }

            return validationResults;
        }
    }
}