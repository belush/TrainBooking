using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TrainBooking.ValidationAttributes;

namespace TrainBooking.Models.RouteModels
{
    public class RouteAddViewModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Введите целое число")]
        [UniqueRouteNumber("Id")]
        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 6)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Дата отправления")]
        [DataType(DataType.Date)]
        [DateGreaterThan("DepatureDateTime", "ArrivalDateTime")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepatureDate { get; set; }

        [Required]
        [Display(Name = "Время отправления")]
        [DataType(DataType.Time)]
        public TimeSpan DepatureTime { get; set; }

        [Display(Name = "Дата прибытия")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [Required]
        [Display(Name = "Время прибытия")]
        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        //валидация на повтор
        [Required]
        [Display(Name = "Начальная станция")]
        [UniqueStation("LastStationRoute", ErrorMessage = "Только не Харьков")]
        public int StartingStation { get; set; }

        //валидация на повтор
        [Required]
        [Display(Name = "Конечная станция")]
        public int LastStation { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int StartingStationRoute { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int LastStationRoute { get; set; }

        [Display(Name = "Промежуточные станции")]
        public List<int> WayStationIds { get; set; }

        public List<SelectListItem> StationsListItems { set; get; }

        [Display(Name = "Цена")]
        [Range(1, 10000)]
        public double Price { get; set; }

        public DateTime DepatureDateTime
        {
            get
            {
                return DepatureDate.Add(DepatureTime);
            }
            set { DepatureDateTime = value; }
        }

        public DateTime ArrivalDateTime
        {
            get
            {
                return ArrivalDate.Add(ArrivalTime);
            }
            set { ArrivalDateTime = value; }
        }
    }
}