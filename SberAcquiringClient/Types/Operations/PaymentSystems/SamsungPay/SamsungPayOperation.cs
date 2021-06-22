using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;

namespace SberAcquiringClient.Types.Operations.PaymentSystems.SamsungPay
{
    public class SamsungPayOperation : PaymentSystemOperation<SamsungPayResult>
    {
        public SamsungPayOperation(string orderNumber, string merchant, IPAddress clientIp, string samsungPayToken) :
            base("/payment/samsung/payment.do")
        {
            if (orderNumber.IsNullOrEmptyOrWhiteSpace() || orderNumber.Length > 32)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(OrderNumber)).GetPropertyDisplayName()),
                    nameof(orderNumber));
            }

            if (merchant.IsNullOrEmptyOrWhiteSpace() || merchant.Length > 255)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Merchant)).GetPropertyDisplayName()),
                    nameof(merchant));
            }

            if (clientIp == null)
            {
                throw new ArgumentNullException(nameof(clientIp));
            }

            if (samsungPayToken.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(PaymentToken)).GetPropertyDisplayName()),
                    nameof(samsungPayToken));
            }

            OrderNumber = orderNumber;
            Merchant = merchant;
            Ip = clientIp;
            PaymentToken = samsungPayToken;
        }

        [Display(Name = "Логин продавца в платёжном шлюзе")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Merchant { get; }

        [Display(Name = "Идентификатор заказа в системе магазина")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string OrderNumber { get; }

        [Display(Name = "Описание заказа в свободной форме")]
        [MaxLength(1024, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(@"[^%+\r\n]+", ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Description { get; set; }

        [Display(Name = "Дополнительные параметры")]
        public Dictionary<string, string> AdditionalParameters { get; set; }

        [Display(Name = "Флаг, определяющий необходимость предварительной авторизации")]
        public bool? PreAuth { get; set; }

        [Display(Name =
            "Идентификатор клиента в системе магазина, для которого следует создать связку для проведения регулярных платежей")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string ClientId { get; set; }

        [Display(Name = "Содержимое параметра 3ds.data из ответа, полученного от Samsung Pay")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string PaymentToken { get; }

        [Display(Name = "IP-адрес покупателя")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [JsonConverter(typeof(IpAddressConverter))]
        public IPAddress Ip { get; }

        [Display(Name = "Код валюты платежа ISO 4217")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.PositiveNumberPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string CurrencyCode { get; set; }
    }
}