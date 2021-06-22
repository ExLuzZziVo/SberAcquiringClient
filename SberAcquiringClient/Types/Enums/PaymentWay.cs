using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SberAcquiringClient.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentWay : byte
    {
        [Display(Name = "Оплата с вводом карточных данных")]
        CARD,
        [Display(Name = "Оплата связкой")] CARD_BINDING,

        [Display(Name = "Оплата через колл-центр")]
        CARD_MOTO,

        [Display(Name = "Оплата как cardPresent")]
        CARD_PRESENT,

        [Display(Name = "Оплата через Сбербанк Онлайн")]
        SBRF_SBOL,

        [Display(Name = "Оплата через China Union Pay")]
        UPOP,
        [Display(Name = "Оплата через файл")] FILE_BINDING,
        [Display(Name = "Оплата через смс")] SMS_BINDING,

        [Display(Name = "Перевод с карты на карту")]
        P2P,
        [Display(Name = "Перевод связкой")] P2P_BINDING,

        [Display(Name = "Оплата со счёта PayPal")]
        PAYPAL,

        [Display(Name = "Оплата со счёта МТС")]
        MTS,
        [Display(Name = "Apple Pay")] APPLE_PAY,

        [Display(Name = "Оплата связкой Apple Pay")]
        APPLE_PAY_BINDING,
        [Display(Name = "Android Pay")] ANDROID_PAY,

        [Display(Name = "Оплата связкой Android Pay")]
        ANDROID_PAY_BINDING,

        [Display(Name = "Google Pay нетокенизированная")]
        GOOGLE_PAY_CARD,

        [Display(Name = "Оплата связкой с не токенизированной картой GooglePay")]
        GOOGLE_PAY_CARD_BINDING,

        [Display(Name = "Google Pay токенизированная")]
        GOOGLE_PAY_TOKENIZED,

        [Display(Name = "Оплата связкой с токенизированной картой GooglePay")]
        GOOGLE_PAY_TOKENIZED_BINDING,
        [Display(Name = "Samsung Pay")] SAMSUNG_PAY,

        [Display(Name = "Оплата связкой Samsung Pay")]
        SAMSUNG_PAY_BINDING,
        [Display(Name = "Оплата iPOS")] IPOS,
        [Display(Name = "Оплата SberPay")] SBERPAY,
        [Display(Name = "Оплата SberID")] SBERID
    }
}