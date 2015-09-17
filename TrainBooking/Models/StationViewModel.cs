using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainBooking.Models
{
    public class StationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime DepatureDateTime { get; set; }

        //public TimeSpan DepatureTime { get; set; }

        //public DateTime ArrivalDate { get; set; }

        //public TimeSpan ArrivalTime { get; set; }

        //public int TravelDays
        //{
        //    get
        //    {
        //        //ЕЩЕ НУЖНО УЧЕСТЬ ЕСЛИ ДНИ ИЗ РАЗНЫХ МЕСЯЦЕВ, ЛЕТ ...
        //        return ArrivalDate.Day - DepatureDateTime.Day;
        //    }
        //    set
        //    {
        //        TravelDays = value;
        //    }
        //}

        //public TimeSpan TravelTime
        //{
        //    get
        //    {
        //        //ЕЩЕ НУЖНО УЧЕСТЬ ЕСЛИ ДНИ ИЗ РАЗНЫХ МЕСЯЦЕВ, ЛЕТ ...
        //        return ArrivalTime - DepatureTime;
        //    }
        //    set
        //    {
        //        TravelTime = value;
        //    }
        //}
    }
}