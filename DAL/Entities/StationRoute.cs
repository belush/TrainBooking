using System;
using System.ComponentModel.DataAnnotations;

namespace TrainBooking.DAL.Entities
{
    public class StationRoute
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DepatureDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ArrivalDateTime { get; set; }

        public virtual Station Station { get; set; }

        public virtual Route Route { get; set; }
    }
}
