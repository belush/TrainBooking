using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.EntityMetaData
{
    public class RouteMetaData
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepatureDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan DepatureTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        public double FullPrice { get; set; }

        public virtual StationRoute StartingStation { get; set; }

        public virtual StationRoute LastStation { get; set; }

        public virtual ICollection<StationRoute> WayStations { get; set; }

        public virtual ICollection<Wagon> Wagons { get; set; }
    }
}
