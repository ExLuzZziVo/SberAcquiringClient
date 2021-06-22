using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Operations.PaymentSystems.SamsungPayWeb
{
    public class SamsungPayWebResult : OperationResult
    {
        [Display(Name = "Флаг, указывающий на успешность запроса")]
        public bool Successful { get; set; }

        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string TransactionId { get; set; }

        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string Href { get; set; }

        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string Mod { get; set; }

        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string Exp { get; set; }

        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string KeyId { get; set; }

        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string ServiceId { get; set; }

        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string CallbackUrl { get; set; }

        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string CancelUrl { get; set; }

        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string CountryCode { get; set; }

        [Display(Name = "Результат операции")] public SamsungPayWebResultType ResultType { get; set; }
    }
}