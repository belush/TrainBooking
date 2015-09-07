using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBooking.DAL.EntityMetaData
{
    public class PlaceMetaData
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsEmpty { get; set; }
    }
}
