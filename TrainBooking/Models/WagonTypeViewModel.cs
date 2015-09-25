using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Models
{
    public class WagonTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Количество мест")]
        [Range(typeof(int), "1", "100", ErrorMessage = "{0} должно быть между {1} и {2}.")]
        public int NumberOfPlaces { get; set; }

        [Display(Name = "Коэффициент цены")]
        [RegularExpression(@"[0-9]*\,?[0-9]+", ErrorMessage = "{0} must be a Number.")]
        public double Coefficient { get; set; }

        public virtual ICollection<Wagon> Wagons { get; set; }
    }
}