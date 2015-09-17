using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainBooking.Models
{
    public class RouteAddViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Дата отправления")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
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
        public int StartingStation { get; set; }

        [Display(Name = "Конечная станция")]
        public int LastStation { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int StartingStationRoute { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int LastStationRoute { get; set; }

        [Display(Name = "Промежуточные станции")]
        public List<int> WayStationIds { get; set; }
    }
}