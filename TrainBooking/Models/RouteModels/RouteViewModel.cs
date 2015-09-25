using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Ajax.Utilities;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Models.RouteModels
{
    public class RouteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Отправление")]
        [DataType(DataType.DateTime)]
        public DateTime DepatureDateTime { get; set; }

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

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Display(Name = "Время в пути")]
        public string TravelTime
        {
            get
            {
                TimeSpan travelTime = ArrivalDateTime - DepatureDateTime;

                if ((int)travelTime.TotalDays > 0)
                {
                    return string.Format("{0} д. {1:hh} ч.", (int)travelTime.TotalDays, travelTime);
                }
                else
                {
                    return string.Format("{0:hh\\:mm}", travelTime);
                }

            }
            set
            {
                TravelTime = value;
            }
        }

        [Display(Name = "Билеты")]
        public int EmptyPlaces { get; set; }

        //[Display(Name = "Начальная станция")]
        //public string StartingStationName { get; set; }

        //[Display(Name = "Конечная станция")]
        //public string LastStationName { get; set; }
    }
}