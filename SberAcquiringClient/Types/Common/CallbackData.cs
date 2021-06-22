using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using CoreLib.CORE.Helpers.StringHelpers;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class CallbackData
    {
        [Display(Name = "Уникальный номер заказа в системе платёжного шлюза")]
        public Guid? MdOrder { get; set; }

        [Display(Name = "Уникальный идентификатор заказа в системе продавца")]
        public string OrderNumber { get; set; }

        [Display(Name = "Тип операции, о которой пришло уведомление")]
        public TransactionState? Operation { get; set; }

        [Display(Name = "Флаг, указывающий на успешность операции")]
        public CallbackOperationStatus? Status { get; set; }

        [Display(Name = "Аутентификационный код, или контрольная сумма, полученная из набора параметров")]
        public string CheckSum { get; set; }

        [Display(Name = "Сумма")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount { get; set; }

        public bool CheckSymmetricKeyChecksum(string key)
        {
            if (MdOrder == null || Operation == null || Status == null || Amount == null ||
                CheckSum.IsNullOrEmptyOrWhiteSpace() || OrderNumber.IsNullOrEmptyOrWhiteSpace())
            {
                return false;
            }

            var checkSumString =
                $"amount;{(int) Math.Round(Amount.Value, 2, MidpointRounding.AwayFromZero) * 100};mdOrder;{MdOrder.Value.ToString("D")};operation;{Operation.Value.ToString().ToLower()};orderNumber;{OrderNumber};status;{Status.Value.ToString("d")};";

            var checkSum =
                Encoding.UTF8.GetString(
                    new HMACSHA256(Encoding.UTF8.GetBytes(key)).ComputeHash(Encoding.UTF8.GetBytes(checkSumString)));

            return checkSum == CheckSum;
        }
    }
}