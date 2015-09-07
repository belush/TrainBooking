using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainBooking.Models
{
    public class RouteViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime DepatureDate { get; set; }
        public TimeSpan DepatureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        public int StartingStationId { get; set; }
        public int LastStationId { get; set; }
        public List<int> WayStationIds { get; set; }


        public int TravelDays
        {
            get
            {
                //ЕЩЕ НУЖНО УЧЕСТЬ ЕСЛИ ДНИ ИЗ РАЗНЫХ МЕСЯЦЕВ, ЛЕТ ...
                return ArrivalDate.Day - DepatureDate.Day;
            }
            set
            {
                TravelDays = value;
            }
        }

        public TimeSpan TravelTime
        {
            get
            {
                //ЕЩЕ НУЖНО УЧЕСТЬ ЕСЛИ ДНИ ИЗ РАЗНЫХ МЕСЯЦЕВ, ЛЕТ ...
                return ArrivalTime - DepatureTime;
            }
            set
            {
                TravelTime = value;
            }
        }
    }
}