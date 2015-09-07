using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBooking.DAL.EntityMetaData
{
    public class WagonTypeMetaData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPlaces { get; set; }
    }
}
