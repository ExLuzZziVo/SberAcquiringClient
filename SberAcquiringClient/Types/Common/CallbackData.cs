using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CoreLib.CORE.Helpers.CryptoHelpers;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using Newtonsoft.Json;
using SberAcquiringClient.Types.Converters;
using SberAcquiringClient.Types.Enums;

namespace SberAcquiringClient.Types.Common
{
    public class CallbackData
    {
        /// <summary>
        /// Уникальный Идентификатор заказа в системе платёжного шлюза
        /// </summary>
        [Display(Name = "Уникальный Идентификатор заказа в системе платёжного шлюза")]
        public Guid? MdOrder { get; set; }

        /// <summary>
        /// Уникальный идентификатор заказа в системе продавца
        /// </summary>
        [Display(Name = "Уникальный идентификатор заказа в системе продавца")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Тип операции, о которой пришло уведомление
        /// </summary>
        [Display(Name = "Тип операции, о которой пришло уведомление")]
        public TransactionState? Operation { get; set; }

        /// <summary>
        /// Флаг, указывающий на успешность операции
        /// </summary>
        [Display(Name = "Флаг, указывающий на успешность операции")]
        public CallbackOperationStatus? Status { get; set; }

        /// <summary>
        /// Аутентификационный код, или контрольная сумма, полученная из набора параметров
        /// </summary>
        [Display(Name = "Аутентификационный код, или контрольная сумма, полученная из набора параметров")]
        public string CheckSum { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        [Display(Name = "Сумма")]
        [JsonConverter(typeof(AmountConverter))]
        public decimal? Amount { get; set; }
        
        /// <summary>
        /// Проверяет контрольную сумму уведомления при помощи закрытого ключа (Симметричная криптография)
        /// </summary>
        /// <param name="key">Закрытый ключ для проверки контрольной суммы</param>
        /// <returns>Возвращает истину, если проверка контрольной суммы прошла успешно</returns>
        public bool CheckSymmetricKeyChecksum(string key)
        {
            if (key.IsNullOrEmptyOrWhiteSpace() || MdOrder == null || Operation == null || Status == null || 
                CheckSum.IsNullOrEmptyOrWhiteSpace() || OrderNumber.IsNullOrEmptyOrWhiteSpace())
            {
                return false;
            }

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                var checkSum = hmac.ComputeHash(GenerateCallbackData()).ToHexString();

                return checkSum == CheckSum;
            }
        }

        /// <summary>
        /// Проверяет контрольную сумму уведомления при помощи открытого ключа (Асимметричная криптография)
        /// </summary>
        /// <param name="cert">Сертификат для проверки контрольной суммы</param>
        /// <returns>Возвращает истину, если проверка контрольной суммы прошла успешно</returns>
        public bool CheckAsymmetricKeyChecksum(X509Certificate2 cert)
        {
            if (cert == null || MdOrder == null || Operation == null || Status == null || 
                CheckSum.IsNullOrEmptyOrWhiteSpace() || OrderNumber.IsNullOrEmptyOrWhiteSpace())
            {
                return false;
            }
            
            using (var rsa = cert.GetRSAPublicKey())
            {
                return rsa.VerifyData(GenerateCallbackData(), ObjectManipulator.GetDataFromHexString(CheckSum), HashAlgorithmName.SHA512, RSASignaturePadding.Pkcs1);
            }
        }

        /// <summary>
        /// Проверяет контрольную сумму уведомления при помощи открытого ключа (Асимметричная криптография)
        /// </summary>
        /// <param name="pubKey">Открытый ключ для проверки контрольной суммы</param>
        /// <returns>Возвращает истину, если проверка контрольной суммы прошла успешно</returns>
        public bool CheckAsymmetricKeyChecksum(string pubKey)
        {
            if (pubKey.IsNullOrEmptyOrWhiteSpace())
            {
                return false;
            }
            
            return CheckAsymmetricKeyChecksum(new X509Certificate2(Encoding.UTF8.GetBytes(pubKey)));
        }
        
        /// <summary>
        /// Генерирует строку для проверки контрольной суммы из параметров Callback'а
        /// </summary>
        /// <returns>Строка для проверки контрольной суммы</returns>
        private byte[] GenerateCallbackData()
        {
            return Encoding.UTF8.GetBytes($"{(Amount == null ? string.Empty : $"amount;{(int) (Math.Round(Amount.Value, 2, MidpointRounding.AwayFromZero) * 100)};")}mdOrder;{MdOrder.Value.ToString("D")};operation;{Operation.Value.ToString().ToLower()};orderNumber;{OrderNumber};status;{Status.Value.ToString("d")};");
        }
    }
}