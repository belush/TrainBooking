using System;
using System.Collections.Generic;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories.Interfaces
{
    public interface IRouteRepository
    {
        IEnumerable<Route> GetRoutes();
        IEnumerable<Route> GetRoutesByDepatureDate(DateTime? date);
        IEnumerable<Route> GetRoutesByDateAndStationName(DateTime? date, string stationName);
        IEnumerable<Route> GetRoutesWithStartStationName(string stationName);
        IEnumerable<Route> GetRoutesWithLastStationName(string stationName);
        void AddRoute(Route route);
        void DeleteRoute(Route route);
        void EditRoute(Route route);
        Route GetRouteById(int id);
    }
}
