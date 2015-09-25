using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Models.WagonModels
{
    public class WagonViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Тип вагона")]
        public WagonType WagonType { get; set; }

        [Display(Name = "Билеты")]
        public List<Ticket> Tickets { get; set; }

        [Display(Name = "Свободные места")]
        public List<int> EmptyPlaces { get; set; }

        public Route Route { get; set; }


        [Display(Name = "Цена")]
        public double PricePerPlace { get; set; }
    }
}