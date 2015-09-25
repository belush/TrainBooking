using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TrainBooking.BL.Logic;
using TrainBooking.BL.Logic.Implementations;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;
using TrainBooking.DAL.Repositories.Implementations;

namespace TrainBooking.ValidationAttributes
{
    public class NotRepeatWayStationAttribute : ValidationAttribute
    {
        private string RouteId { get; set; }
        private readonly IRouteLogic _routeLogic;

        public NotRepeatWayStationAttribute(string routeId)
        {
            RouteId = routeId;
            var context = new TrainBookingContext();

            _routeLogic = new RouteLogic(new RouteRepository(context));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //
            int routeId = (int)validationContext.ObjectType.GetProperty(RouteId).GetValue(validationContext.ObjectInstance, null);


            int stationId = (int)value;

            Route route = _routeLogic.GetRouteById(routeId);

            bool isRepeatStation = route.WayStations.Any(w => w.Station.Id == stationId);

            if (route.StartingStation.Station.Id == stationId ||
                route.LastStation.Station.Id == stationId ||
                isRepeatStation)
            {
                return new ValidationResult("Промежуточная станция должна отличаться от других станций этого маршрута");
            }
            else
            {
                return ValidationResult.Success;

            }
        }
    }
}
