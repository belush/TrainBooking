using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Models
{
    public class RouteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        //[Display(Name = "Дата отправления")]
        //[DataType(DataType.Date)]
        //public DateTime DepatureDateTime { get; set; }

        //[Display(Name = "Время отправления")]
        //[DataType(DataType.Time)]

        [Display(Name = "Отправление")]
        [DataType(DataType.DateTime)]

        public DateTime DepatureDateTime { get; set; }

        //[Display(Name = "Дата прибытия")]
        //[DataType(DataType.Date)]
        //public DateTime ArrivalDate { get; set; }

        //[Display(Name = "Время прибытия")]
        //[DataType(DataType.Time)]
        //public TimeSpan ArrivalTime { get; set; }

        [Display(Name = "Прибытие")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDateTime { get; set; }

        [Display(Name = "Начальная станция")]
        public string StartingStation { get; set; }

        [Display(Name = "Конечная станция")]
        public string LastStation { get; set; }

        [Display(Name = "Промежуточные станции")]
        public List<int> WayStationIds { get; set; }

        [Display(Name = "Промежуточные станции")]
        public List<StationRoute> WayStations { get; set; }

        //[Display(Name = "Название")]
        //public int TravelDays
        //{
        //    get
        //    {
        //        //ЕЩЕ НУЖНО УЧЕСТЬ ЕСЛИ ДНИ ИЗ РАЗНЫХ МЕСЯЦЕВ, ЛЕТ ...
        //        return ArrivalDate.Day - DepatureDateTime.Day;
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
                int travelDays = ArrivalDateTime.Day - DepatureDateTime.Day;
                TimeSpan time = new TimeSpan(0, DepatureDateTime.Hour, DepatureDateTime.Minute,
                    DepatureDateTime.Second);
                //TimeSpan travelTime = ArrivalTime - time;

                TimeSpan travelTime = ArrivalDateTime - DepatureDateTime;

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

        //[Display(Name = "Начальная станция")]
        //public string StartingStationName { get; set; }

        //[Display(Name = "Конечная станция")]
        //public string LastStationName { get; set; }
    }
}