using System.ComponentModel.DataAnnotations;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Operations.PaymentSystems.SamsungPayWeb
{
    /// <summary>
    /// Результат оплаты через Samsung Pay, при которой используется платёжная страница на стороне продавца
    /// </summary>
    public class SamsungPayWebResult : OperationResult
    {
        /// <summary>
        /// Флаг, указывающий на успешность запроса
        /// </summary>
        [Display(Name = "Флаг, указывающий на успешность запроса")]
        public bool Successful { get; set; }

        /// <summary>
        /// Параметр, который необходимо передать в Samsung Pay
        /// </summary>
        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Параметр, который необходимо передать в Samsung Pay
        /// </summary>
        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string Href { get; set; }

        /// <summary>
        /// Параметр, который необходимо передать в Samsung Pay
        /// </summary>
        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string Mod { get; set; }

        /// <summary>
        /// Параметр, который необходимо передать в Samsung Pay
        /// </summary>
        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string Exp { get; set; }

        /// <summary>
        /// Параметр, который необходимо передать в Samsung Pay
        /// </summary>
        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string KeyId { get; set; }

        /// <summary>
        /// Параметр, который необходимо передать в Samsung Pay
        /// </summary>
        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string ServiceId { get; set; }

        /// <summary>
        /// Параметр, который необходимо передать в Samsung Pay
        /// </summary>
        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Параметр, который необходимо передать в Samsung Pay
        /// </summary>
        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string CancelUrl { get; set; }

        /// <summary>
        /// Параметр, который необходимо передать в Samsung Pay
        /// </summary>
        [Display(Name = "Параметр, который необходимо передать в Samsung Pay")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Результат операции
        /// </summary>
        [Display(Name = "Результат операции")]
        public SamsungPayWebResultType ResultType { get; set; }
    }
}