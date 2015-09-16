using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(RouteMetaData))]
    public class Route
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public DateTime DepatureDate { get; set; }

        public TimeSpan DepatureTime { get; set; }

        public DateTime ArrivalDate { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public double FullPrice { get; set; }

        public virtual StationRoute StartingStation { get; set; }

        public virtual StationRoute LastStation { get; set; }

        //public string StartingStation { get; set; }
        //public string LastStation { get; set; }

        public virtual ICollection<StationRoute> WayStations { get; set; }

        public virtual ICollection<Wagon> Wagons { get; set; }
    }
}
