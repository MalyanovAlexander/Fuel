using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Fuel
{
    /// <summary>
    /// Класс, описывающий километраж и расход топлива за день
    /// </summary>
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        /// <summary>
        /// Спидометр утро
        /// </summary>
        public int MileageMorning { get; set; }

        [Required]
        /// <summary>
        /// Остаток топлива утром
        /// </summary>
        public double FuelMorning { get; set; }        //double

        [Required]
        /// <summary>
        /// Заправка
        /// </summary>
        public int Refueling { get; set; }

        [Required]
        /// <summary>
        /// Пробег суточный
        /// </summary>
        public int MileagePerDay { get; set; }

        /// <summary>
        /// Спидометр вечер
        /// </summary>
        public int MileageEvening { get; set; }

        /// <summary>
        /// Остаток топлива вечером
        /// </summary>
        public double FuelEvening { get; set; }            //double

        /// <summary>
        /// Расход суточный
        /// </summary>
        public double DailyConsumption { get; set; }

        [Required]
        /// <summary>
        /// Часы простоя
        /// </summary>
        public int IdleHours { get; set; }

        /// <summary>
        /// Расход простоя
        /// </summary>
        public double IdleConsumption { get; set; }        //double

        /// <summary>
        /// Общий расход
        /// </summary>
        public double TotalConsumption { get; set; }       //double
    }
}
