using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrainBooking.ValidationAttributes;

namespace TrainBooking.Models
{
    public class StationViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}