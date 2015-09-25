using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(StationMetaData))]
    public class Station
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<StationRoute> StationRoutes { get; set; }
    }
}
