using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBooking.DAL.EntityMetaData
{
    public class WagonTypeMetaData
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Количество мест")]
        public int NumberOfPlaces { get; set; }

        [Display(Name = "Коэффициент цены")]
        public double Coefficient { get; set; }
    }
}
