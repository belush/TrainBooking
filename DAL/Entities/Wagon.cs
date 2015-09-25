using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(WagonMetaData))]
    public class Wagon
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public virtual Route Route { get; set; }

        public virtual WagonType WagonType { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
