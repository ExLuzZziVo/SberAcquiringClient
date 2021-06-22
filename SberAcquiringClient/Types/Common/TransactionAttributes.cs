using System.ComponentModel.DataAnnotations;
using System.Net;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;

namespace SberAcquiringClient.Types.Common
{
    public class TransactionAttributes
    {
        [Display(Name = "IP-адрес продавца")]
        [JsonConverter(typeof(IpAddressConverter))]
        public IPAddress MerchantIp { get; set; }

        [Display(Name = "Идентификатор транзакции СБОЛ")]
        public string SbolBankInvoiceId { get; set; }
    }
}