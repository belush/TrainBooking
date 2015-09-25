using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TrainBooking.ValidationAttributes;

namespace TrainBooking.Models.StationRouteModels
{
    public class StationRouteAddViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название станции")]
        [NotRepeatWayStation("RouteId")] //промежуточная станция должна отличаться от существующих в маршруте
        public int StationId { get; set; }

        [Display(Name = "Дата отправление")]
        [DataType(DataType.Date)]
        [DateGreaterThan("DepatureDateTime", "ArrivalDateTime")]
        //добавить проверку промежуточной станции . чтобы она была между станциями
        [CorrectDepatureDate("RouteId", "DepatureDateTime")] //Отправление должно быть после начала маршрута
        public DateTime DepatureDate { get; set; }

        [Display(Name = "Время отправления")]
        [DataType(DataType.Time)]
        public TimeSpan DepatureTime { get; set; }

        [Display(Name = "Дата прибытия")]
        [DataType(DataType.Date)]
        [CorrectArrivalDate("RouteId", "ArrivalDateTime")] //Прибытие должно быть раньше окончания маршрута
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Время прибытия")]
        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int RouteId { get; set; }

        public List<SelectListItem> StationsListItems { set; get; }

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