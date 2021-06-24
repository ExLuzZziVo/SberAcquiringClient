using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class SecureAuthInfo
    {
        /// <summary>
        /// Электронный коммерческий индикатор
        /// </summary>
        [Display(Name = "Электронный коммерческий индикатор")]
        public string Eci { get; set; }

        /// <summary>
        /// Значение проверки аутенфикации владельца карты
        /// </summary>
        [Display(Name = "Значение проверки аутенфикации владельца карты")]
        public string Cavv { get; set; }

        /// <summary>
        /// Электронный коммерческий идентификатор транзакции
        /// </summary>
        [Display(Name = "Электронный коммерческий идентификатор транзакции")]
        public string Xid { get; set; }
    }
}