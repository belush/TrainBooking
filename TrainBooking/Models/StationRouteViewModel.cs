using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Models
{
    public class StationRouteViewModel
    {
        public int Id { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime DepatureDate { get; set; }

        //[DataType(DataType.Time)]
        //public TimeSpan DepatureTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DepatureDateTime { get; set; }


        //[DataType(DataType.Date)]
        //public DateTime ArrivalDate { get; set; }

        //[DataType(DataType.Time)]
        //public TimeSpan ArrivalTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ArrivalDateTime { get; set; }

        public virtual Station Station { get; set; }
        public string StationName { get; set; }


        public virtual Route Route { get; set; }

        public string RouteName { get; set; }



    }
}