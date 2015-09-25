using System;
using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Models.StationRouteModels
{
    public class StationRouteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Отправление")]
        [DataType(DataType.DateTime)]
        public DateTime DepatureDateTime { get; set; }

        [Display(Name = "Прибытие")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDateTime { get; set; }

        public virtual Station Station { get; set; }

        [Display(Name = "Станция")]
        public string StationName { get; set; }

        public virtual Route Route { get; set; }

        [Display(Name = "Маршрут")]
        public string RouteName { get; set; }
    }
}