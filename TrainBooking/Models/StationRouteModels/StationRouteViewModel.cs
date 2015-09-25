using System;
using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Models.StationRouteModels
{
    public class StationRouteViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DepatureDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ArrivalDateTime { get; set; }

        public virtual Station Station { get; set; }

        public string StationName { get; set; }

        public virtual Route Route { get; set; }

        public string RouteName { get; set; }
    }
}