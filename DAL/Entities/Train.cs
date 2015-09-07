using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(TrainMetaData))]
    public class Train
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public Route Route { get; set; }
        public Wagon Wagon { get; set; }
    }
}
