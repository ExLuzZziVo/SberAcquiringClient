using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class SecureAuthInfo
    {
        [Display(Name = "Электронный коммерческий индикатор")]
        public string Eci { get; set; }

        [Display(Name = "Значение проверки аутенфикации владельца карты")]
        public string Cavv { get; set; }

        [Display(Name = "Электронный коммерческий идентификатор транзакции")]
        public string Xid { get; set; }
    }
}