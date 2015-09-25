using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainBooking.DAL.Entities
{
    public class Wagon
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public virtual Route Route { get; set; }

        public virtual WagonType WagonType { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
