using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.EntityMetaData
{
    public class TrainMetaData
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }

        public Route Route { get; set; }
        public Wagon Wagon { get; set; }
    }
}
