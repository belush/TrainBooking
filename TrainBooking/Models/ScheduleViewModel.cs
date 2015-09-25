using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainBooking.Models
{
    public class ScheduleViewModel
    {
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Количество билетов")]
        public int Count { get; set; }

        [Display(Name = "Общая цена")]
        public double FullPrice { get; set; }
    }
}