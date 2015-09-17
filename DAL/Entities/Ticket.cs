using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(TicketMetaData))]
    public class Ticket
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }

        public virtual Wagon Wagon { get; set; }
        public virtual string StartingStation { get; set; }
        public virtual string LastStation { get; set; }
        //public User User { get; set; }
    }
}
