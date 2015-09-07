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

        public virtual Station StartingStation { get; set; }
        public virtual Station LastStation { get; set; }
        public virtual List<Station> WayStations { get; set; }
    }
}
