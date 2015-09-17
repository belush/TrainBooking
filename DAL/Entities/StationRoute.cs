using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(StationRouteMetaData))]
    public class StationRoute
    {
        public int Id { get; set; }

        //public DateTime DepatureDate { get; set; }

        //public TimeSpan DepatureTime { get; set; }

        public DateTime DepatureDateTime { get; set; }

        //public DateTime ArrivalDate { get; set; }

        //public TimeSpan ArrivalTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public virtual Station Station { get; set; }

        public virtual Route Route { get; set; }
    }
}
