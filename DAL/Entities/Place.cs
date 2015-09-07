using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.EntityMetaData;

namespace TrainBooking.DAL.Entities
{
    [MetadataType(typeof(PlaceMetaData))]
    public class Place
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsEmpty { get; set; }
    }
}
