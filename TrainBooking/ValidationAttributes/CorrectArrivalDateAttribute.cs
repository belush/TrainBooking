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
    public class CorrectArrivalDateAttribute : ValidationAttribute
    {
        private string RouteId { get; set; }
        private string ArrivalDateTime { get; set; }

        private readonly IRouteLogic _routeLogic;

        public CorrectArrivalDateAttribute(string routeId, string arrivalDateTime)
        {
            RouteId = routeId;
            ArrivalDateTime = arrivalDateTime;
  

            var context = new TrainBookingContext();

            _routeLogic = new RouteLogic(new RouteRepository(context));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int routeId = (int)validationContext.ObjectType.GetProperty(RouteId).GetValue(validationContext.ObjectInstance, null);
            DateTime arrivalDateTime = (DateTime)validationContext.ObjectType.GetProperty(ArrivalDateTime).GetValue(validationContext.ObjectInstance, null);
            Route route = _routeLogic.GetRouteById(routeId);

            if (arrivalDateTime < route.LastStation.ArrivalDateTime)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Прибытие должно быть раньше окончания маршрута");
        }
    }
}