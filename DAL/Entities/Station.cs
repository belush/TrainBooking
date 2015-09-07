using System;
using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(StationMetaData))]
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DepatureDate { get; set; }
        public TimeSpan DepatureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}
