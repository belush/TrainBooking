using System.ComponentModel.DataAnnotations;

namespace TrainBooking.DAL.Entities
{
    public class Ticket
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
