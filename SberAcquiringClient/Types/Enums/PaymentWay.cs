#region

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentWay : byte
    {
        /// <summary>
        /// Оплата с вводом карточных данных
        /// </summary>
        [Display(Name = "Оплата с вводом карточных данных")]
        CARD,

        /// <summary>
        /// Оплата связкой
        /// </summary>
        [Display(Name = "Оплата связкой")] CARD_BINDING,

        /// <summary>
        /// Оплата через колл-центр
        /// </summary>
        [Display(Name = "Оплата через колл-центр")]
        CARD_MOTO,

        /// <summary>
        /// Оплата как cardPresent
        /// </summary>
        [Display(Name = "Оплата как cardPresent")]
        CARD_PRESENT,

        /// <summary>
        /// Оплата через Сбербанк Онлайн
        /// </summary>
        [Display(Name = "Оплата через Сбербанк Онлайн")]
        SBRF_SBOL,

        /// <summary>
        /// Оплата через China Union Pay
        /// </summary>
        [Display(Name = "Оплата через China Union Pay")]
        UPOP,

        /// <summary>
        /// Оплата через файл
        /// </summary>
        [Display(Name = "Оплата через файл")] FILE_BINDING,

        /// <summary>
        /// Оплата через смс
        /// </summary>
        [Display(Name = "Оплата через смс")] SMS_BINDING,

        /// <summary>
        /// Перевод с карты на карту
        /// </summary>
        [Display(Name = "Перевод с карты на карту")]
        P2P,

        /// <summary>
        /// Перевод связкой
        /// </summary>
        [Display(Name = "Перевод связкой")] P2P_BINDING,

        /// <summary>
        /// Оплата со счёта PayPal
        /// </summary>
        [Display(Name = "Оплата со счёта PayPal")]
        PAYPAL,

        /// <summary>
        /// Оплата со счёта МТС
        /// </summary>
        [Display(Name = "Оплата со счёта МТС")]
        MTS,

        /// <summary>
        /// Apple Pay
        /// </summary>
        [Display(Name = "Apple Pay")] APPLE_PAY,

        /// <summary>
        /// Оплата связкой Apple Pay
        /// </summary>
        [Display(Name = "Оплата связкой Apple Pay")]
        APPLE_PAY_BINDING,

        /// <summary>
        /// Android Pay
        /// </summary>
        [Display(Name = "Android Pay")] ANDROID_PAY,

        /// <summary>
        /// Оплата связкой Android Pay
        /// </summary>
        [Display(Name = "Оплата связкой Android Pay")]
        ANDROID_PAY_BINDING,

        /// <summary>
        /// Google Pay нетокенизированная
        /// </summary>
        [Display(Name = "Google Pay нетокенизированная")]
        GOOGLE_PAY_CARD,

        /// <summary>
        /// Оплата связкой с не токенизированной картой GooglePay
        /// </summary>
        [Display(Name = "Оплата связкой с не токенизированной картой GooglePay")]
        GOOGLE_PAY_CARD_BINDING,

        /// <summary>
        /// Google Pay токенизированная
        /// </summary>
        [Display(Name = "Google Pay токенизированная")]
        GOOGLE_PAY_TOKENIZED,

        /// <summary>
        /// Оплата связкой с токенизированной картой GooglePay
        /// </summary>
        [Display(Name = "Оплата связкой с токенизированной картой GooglePay")]
        GOOGLE_PAY_TOKENIZED_BINDING,

        /// <summary>
        /// Samsung Pay
        /// </summary>
        [Display(Name = "Samsung Pay")] SAMSUNG_PAY,

        /// <summary>
        /// Оплата связкой Samsung Pay
        /// </summary>
        [Display(Name = "Оплата связкой Samsung Pay")]
        SAMSUNG_PAY_BINDING,

        /// <summary>
        /// Оплата iPOS
        /// </summary>
        [Display(Name = "Оплата iPOS")] IPOS,

        /// <summary>
        /// Оплата SberPay
        /// </summary>
        [Display(Name = "Оплата SberPay")] SBERPAY,

        /// <summary>
        /// Оплата SberID
        /// </summary>
        [Display(Name = "Оплата SberID")] SBERID
    }
}