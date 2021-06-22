using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Common
{
    public class Ofd
    {
        [Display(Name = "Наименование оператора фискальных данных")]
        public string Name { get; set; }

        [Display(Name = "Сайт оператора фискальных данных")]
        public string Website { get; set; }

        [Display(Name = "ИНН оператора фискальных данных")]
        public string Inn { get; set; }
    }
}