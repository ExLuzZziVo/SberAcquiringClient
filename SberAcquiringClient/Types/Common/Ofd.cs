#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace SberAcquiringClient.Types.Common
{
    public class Ofd
    {
        /// <summary>
        /// Наименование оператора фискальных данных
        /// </summary>
        [Display(Name = "Наименование оператора фискальных данных")]
        public string Name { get; set; }

        /// <summary>
        /// Сайт оператора фискальных данных
        /// </summary>
        [Display(Name = "Сайт оператора фискальных данных")]
        public string Website { get; set; }

        /// <summary>
        /// ИНН оператора фискальных данных
        /// </summary>
        [Display(Name = "ИНН оператора фискальных данных")]
        public string Inn { get; set; }
    }
}