using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrainBooking.BL.Logic;
using TrainBooking.BL.Logic.Implementations;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Repositories;
using TrainBooking.DAL.Repositories.Implementations;

namespace TrainBooking.ValidationAttributes
{
    public class UniqueRouteNumberAttribute : ValidationAttribute
    {
        private readonly IRouteLogic _routeLogic;
        public string RouteId { get; set; }

        public UniqueRouteNumberAttribute(string routeId)
        {
            var context = new TrainBookingContext();
            _routeLogic = new RouteLogic(new RouteRepository(context));

            RouteId = routeId;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int thisRouteNumber = (int)value;

            int routeId = (int)validationContext.ObjectType.GetProperty(RouteId).GetValue(validationContext.ObjectInstance, null);

            bool isNumberRepeat = _routeLogic.GetRoutesList().Where(r=>r.Id!=routeId).Any(r => r.Number == thisRouteNumber);

            if (isNumberRepeat)
            {
                return new ValidationResult("Такой номер уже существует");
            }

            return ValidationResult.Success;
        }
    }
}