using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(WagonTypeMetaData))]
    public class WagonType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPlaces { get; set; }
        public double Coefficient { get; set; }

        public virtual ICollection<Wagon> Wagons { get; set; }
    }
}
