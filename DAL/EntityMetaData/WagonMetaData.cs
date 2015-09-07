using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.EntityMetaData
{
    public class WagonMetaData
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }

        public WagonType WagonType { get; set; }
        public List<Place> Places { get; set; }
    }
}
