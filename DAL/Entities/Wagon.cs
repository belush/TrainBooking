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
        public double Price { get; set; }

        public WagonType WagonType { get; set; }
        public List<Place> Places { get; set; }
    }
}
