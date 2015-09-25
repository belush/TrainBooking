using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrainBooking.BL.Logic;
using TrainBooking.BL.Logic.Implementations;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;
using TrainBooking.DAL.Repositories.Implementations;

namespace TrainBooking.ValidationAttributes
{
    public class CorrectDepatureDateAttribute : ValidationAttribute
    {
        private string RouteId { get; set; }
        private string DepatureDateTime { get; set; }

        private readonly IRouteLogic _routeLogic;

        public CorrectDepatureDateAttribute(string routeId, string depatureDateTime)
        {
            RouteId = routeId;
            DepatureDateTime = depatureDateTime;

            var context = new TrainBookingContext();

            _routeLogic = new RouteLogic(new RouteRepository(context));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int routeId = (int)validationContext.ObjectType.GetProperty(RouteId).GetValue(validationContext.ObjectInstance, null);
            DateTime depatureDateTime = (DateTime)validationContext.ObjectType.GetProperty(DepatureDateTime).GetValue(validationContext.ObjectInstance, null);
            
            
            Route route = _routeLogic.GetRouteById(routeId);

            DateTime compareDateTime;
            if (route.WayStations.Count>0)
            {
                compareDateTime = route.WayStations.Last().ArrivalDateTime;
            }
            else
            {
                compareDateTime = route.StartingStation.DepatureDateTime;
            }
            


            //if (depatureDateTime > route.StartingStationRoute.DepatureDateTime)
            //{
            //    return ValidationResult.Success;
            //} 
            if (depatureDateTime > compareDateTime)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Отправление должно быть после начала маршрута и после предыдущих станций");
        }
    }
}