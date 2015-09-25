using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainBooking.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер маршрута")]
        public int RouteNumber { get; set; }

        [Display(Name = "Начальная станция")]
        public string StartingStationName { get; set; }

        [Display(Name = "Конечная станция")]
        public string LastStationName { get; set; }

        [Display(Name = "Номер вагона")]
        public int WagonNumber { get; set; }

        [Display(Name = "Номер места")]
        public int PlaceNumber { get; set; }

        [Display(Name = "Ваше имя")]
        public string UserName { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int StartingStationRouteId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int LastStationRouteId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int StartingStationId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int LastStationId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int WagonId { get; set; }

        public List<SelectListItem> StationsListItems { set; get; }
    }
}