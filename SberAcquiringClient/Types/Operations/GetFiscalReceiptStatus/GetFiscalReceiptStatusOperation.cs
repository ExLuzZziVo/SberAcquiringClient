#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using SberAcquiringClient.Resources;

#endregion

namespace SberAcquiringClient.Types.Operations.GetFiscalReceiptStatus
{
    /// <summary>
    /// Получение сведений о кассовом чеке
    /// </summary>
    public class GetFiscalReceiptStatusOperation : Operation<GetFiscalReceiptStatusResult>
    {
        /// <summary>
        /// Получение сведений о кассовом чеке по идентификатору заказа в платежной системе или чека в фискализаторе
        /// </summary>
        /// <param name="id">Идентификатор заказа в платежной системе или чека в фискализаторе</param>
        /// <param name="isOrderId">Если истина, то переданный <paramref name="id"/> считается идентификатором заказа в платежной системе, если ложь - идентификатором чека в фискализаторе</param>
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

        /// <summary>
        /// Получение сведений о кассовом чеке по идентификатору заказа в системе продавца
        /// </summary>
        /// <param name="orderNumber">Идентификатор заказа в системе продавца</param>
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

        /// <summary>
        /// Идентификатор заказа в платежной системе
        /// </summary>
        [Display(Name = "Идентификатор заказа в платежной системе")]
        public Guid? OrderId { get; }

        /// <summary>
        /// Идентификатор заказа в системе продавца
        /// </summary>
        /// <list type="bullets">
        /// <item>Максимальная длина: 32</item>
        /// </list>
        [Display(Name = "Идентификатор заказа в системе продавца")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }

        /// <summary>
        /// Идентификатор чека в фискализаторе
        /// </summary>
        [Display(Name = "Идентификатор чека в фискализаторе")]
        public Guid? Uuid { get; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderId == null && OrderNumber.IsNullOrEmptyOrWhiteSpace() && Uuid == null)
            {
                yield return new ValidationResult(
                    ErrorStrings.ResourceManager.GetString("GetFiscalReceiptStatusRequiredError"), new[]
                    {
                        nameof(OrderId), nameof(OrderNumber), nameof(Uuid)
                    });
            }
        }
    }
}