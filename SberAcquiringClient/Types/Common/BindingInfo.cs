using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using Newtonsoft.Json;

namespace SberAcquiringClient.Types.Common
{
    public class BindingInfo
    {
        /// <summary>
        /// Идентификатор клиента в системе продавца
        /// </summary>
        [Display(Name = "Идентификатор клиента в системе продавца")]
        public string ClientId { get; set; }

        /// <summary>
        /// Идентификатор связки
        /// </summary>
        [Display(Name = "Идентификатор связки")]
        public string BindingId { get; set; }

        /// <summary>
        /// Дата и время авторизации
        /// </summary>
        [Display(Name = "Дата и время авторизации")]
        [JsonConverter(typeof(UnixTimestampConverter), true)]
        public DateTime? AuthDateTime { get; set; }

        /// <summary>
        /// Идентификатор терминала в процессинге, через который осуществлялась оплата
        /// </summary>
        [Display(Name = "Идентификатор терминала в процессинге, через который осуществлялась оплата")]
        public string TerminalId { get; set; }
    }
}