using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainBooking.Models
{
    public class RouteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Дата отправления")]
        [DataType(DataType.Date)]
        public DateTime DepatureDate { get; set; }

        [Display(Name = "Время отправления")]
        [DataType(DataType.Time)]
        public TimeSpan DepatureTime { get; set; }

        [Display(Name = "Дата прибытия")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Время прибытия")]
        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        [Display(Name = "Начальная станция")]
        public int StartingStation { get; set; }

        [Display(Name = "Конечная станция")]
        public int LastStation { get; set; }

        [Display(Name = "Промежуточные станции")]
        public List<int> WayStationIds { get; set; }

        //[Display(Name = "Название")]
        //public int TravelDays
        //{
        //    get
        //    {
        //        //ЕЩЕ НУЖНО УЧЕСТЬ ЕСЛИ ДНИ ИЗ РАЗНЫХ МЕСЯЦЕВ, ЛЕТ ...
        //        return ArrivalDate.Day - DepatureDate.Day;
        //    }
        //    set
        //    {
        //        TravelDays = value;
        //    }
        //}


        [Display(Name = "Время в пути")]
        public string TravelTime
        {
            get
            {
                int travelDays = ArrivalDate.Day - DepatureDate.Day;
                TimeSpan travelTime = ArrivalTime - DepatureTime;

                if (travelDays > 0)
                {
                    //ЕЩЕ НУЖНО УЧЕСТЬ ЕСЛИ ДНИ ИЗ РАЗНЫХ МЕСЯЦЕВ, ЛЕТ ...
                    return string.Format("{0} д. {1} ч. {2} мин.", travelDays, travelTime.Hours, travelTime.Minutes);
                }
                else
                {
                    return string.Format("{0} ч. {1} мин.", travelTime.Hours, travelTime.Minutes);
                }

            }
            set
            {
                TravelTime = value;
            }
        }

        [Display(Name = "Начальная станция")]
        public string StartingStationName { get; set; }

        [Display(Name = "Конечная станция")]
        public string LastStationName { get; set; }
    }
}