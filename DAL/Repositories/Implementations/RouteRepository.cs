using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.DAL.Repositories.Implementations
{
    public class RouteRepository : Repository, IRouteRepository
    {
        public IEnumerable<Route> GetRoutes()
        {
            return db.Routes.Where(r=>r.IsDeleted==false);
        }

        public IEnumerable<Route> GetRoutesByDepatureDate(DateTime? date)
        {
            return db.Routes.Where(r => r.DepatureDateTime.Date == date);
        }

        public IEnumerable<Route> GetRoutesByDateAndStationName(DateTime? date, string stationName)
        {
            IEnumerable<Route> routes =
                db.Routes.Where(r => r.WayStations.Any(w => (w.ArrivalDateTime.Date == date) &&
                              (w.Station.Name.ToLower().StartsWith(stationName))));

            return routes;
        }

        public IEnumerable<Route> GetRoutesWithStartStationName(string stationName)
        {
            IEnumerable<Route> routes =
                db.Routes.Where(r => r.StartingStation.Station.Name.ToLower().StartsWith(stationName) ||
                                  r.WayStations.Any(w => w.Station.Name.ToLower().StartsWith(stationName)));

            return routes;
        }

        public IEnumerable<Route> GetRoutesWithLastStationName(string stationName)
        {
            IEnumerable<Route> routes =
                db.Routes.Where(r => r.LastStation.Station.Name.ToLower().StartsWith(stationName) ||
                                     r.WayStations.Any(w => w.Station.Name.ToLower().StartsWith(stationName)));

            return routes;
        }


        public void AddRoute(Route route)
        {
            db.Routes.Add(route);
            db.SaveChanges();
        }

        public void DeleteRoute(Route route)
        {
            route.IsDeleted = true;
            EditRoute(route);
        }

        public void EditRoute(Route route)
        {
            db.Entry(route).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Route GetRouteById(int id)
        {
            return db.Routes.FirstOrDefault(r => r.Id == id);
        }

        public RouteRepository(TrainBookingContext context)
            : base(context)
        {
        }
    }
}
