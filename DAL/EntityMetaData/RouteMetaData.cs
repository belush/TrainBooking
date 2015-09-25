using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.EntityMetaData
{
    public class RouteMetaData
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepatureDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ArrivalDateTime { get; set; }

        public double FullPrice { get; set; }

        public virtual StationRoute StartingStation { get; set; }

        public virtual StationRoute LastStation { get; set; }

        public virtual ICollection<StationRoute> WayStations { get; set; }

        public virtual ICollection<Wagon> Wagons { get; set; }

        public bool IsDeleted { get; set; }
    }
}
