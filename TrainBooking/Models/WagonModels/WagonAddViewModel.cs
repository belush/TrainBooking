using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Models.WagonModels
{
    public class WagonAddViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Количество вагонов")]
        [Range(1,20,ErrorMessage="{0} должно быть от {1} до {2}")]
        public int NumberOfWagons { get; set; }

        [Display(Name = "Тип вагонов")]
        public int WagonType { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int RouteId { get; set; }

        public List<SelectListItem> WagonTypeListItems { set; get; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}