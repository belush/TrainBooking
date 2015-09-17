using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.EntityMetaData
{
    public class TicketMetaData
    {
        [Key]
        public int Id { get; set; }

        public int PlaceNumber { get; set; }

        public virtual Wagon Wagon { get; set; }

        public virtual string StartingStation { get; set; }

        public virtual string LastStation { get; set; }
        //public User User { get; set; }
    }
}
