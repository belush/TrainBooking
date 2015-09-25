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

        public int StartingStationRoute { get; set; }

        public int LastStationRoute { get; set; }

        public virtual User User { get; set; }

        public double Price { get; set; }
    }
}
