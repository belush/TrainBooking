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

        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Дата отправления")]
        [DataType(DataType.Date)]
        public DateTime DepatureDate { get; set; }

        [Display(Name = "Время отправления")]
        [DataType(DataType.Time)]
        public TimeSpan DepatureTime { get; set; }

        [Display(Name = "Дата прибытия")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Время прибытия")]
        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        [Display(Name = "Начальная станция")]
        public virtual Station StartingStation { get; set; }

        [Display(Name = "Конечная станция")]
        public virtual Station LastStation { get; set; }

        [Display(Name = "Промежуточные станции")]
        public virtual List<Station> WayStations { get; set; }
    }
}
