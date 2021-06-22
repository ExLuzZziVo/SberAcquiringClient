using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;

namespace SberAcquiringClient.Types.Common
{
    public class BindingInfo
    {
        [Display(Name = "Идентификатор клиента в системе магазина")]
        public string ClientId { get; set; }

        [Display(Name = "Идентификатор связки")]
        public string BindingId { get; set; }

        [Display(Name = "Дата и время авторизации")]
        [JsonConverter(typeof(UnixTimestampConverter), true)]
        public DateTime? AuthDateTime { get; set; }

        [Display(Name = "Идентификатор терминала в процессинге, через который осуществлялась оплата")]
        public string TerminalId { get; set; }
    }
}