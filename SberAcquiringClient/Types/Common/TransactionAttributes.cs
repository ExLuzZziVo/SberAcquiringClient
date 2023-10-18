#region

using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace SberAcquiringClient.Types.Common
{
    public class TransactionAttributes
    {
        /// <summary>
        /// IP-адрес продавца
        /// </summary>
        [Display(Name = "IP-адрес продавца")]
        [JsonConverter(typeof(IpAddressConverter))]
        public IPAddress MerchantIp { get; set; }

        /// <summary>
        /// Идентификатор транзакции СБОЛ
        /// </summary>
        [Display(Name = "Идентификатор транзакции СБОЛ")]
        public string SbolBankInvoiceId { get; set; }
    }
}