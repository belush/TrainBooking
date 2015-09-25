using System.ComponentModel.DataAnnotations;

namespace TrainBooking.DAL.Entities
{
    public class WagonType
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
