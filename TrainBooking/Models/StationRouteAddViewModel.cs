using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Models
{
    public class StationRouteAddViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название станции")]
        public int StationId { get; set; }

        [Display(Name = "Дата отправление")]
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

        [HiddenInput(DisplayValue = false)]
        public int RouteId { get; set; }
    }
}