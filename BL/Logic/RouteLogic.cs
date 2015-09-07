using System.Collections.Generic;
using System.Linq;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;

namespace TrainBooking.BL.Logic
{
    public class RouteLogic
    {
        private readonly RouteRepository _rep = new RouteRepository();

        public List<Route> GetRoutesList()
        {
            List<Route> routes = _rep.GetRoutes();
            return routes;
        }

        public Route GetRouteById(int id)
        {
            Route route = _rep.GetRoutes().First(r => r.Id == id);
            return route;
        }

        public void DeleteRouteById(int id)
        {
            Route route = GetRouteById(id);
            _rep.DeleteRoute(route);
        }

        public void AddRoute(Route route)
        {
            _rep.AddRoute(route);
        }

        public void DeleteRoute(Route route)
        {
            _rep.DeleteRoute(route);
        }

        public void EditRoute(Route route)
        {
            _rep.EditRoute(route);
        }

        public List<Route> FindRoute(Station startingStaion, Station lastStaion)
        {
            //Edit FindRoute code
            List<Route> routes = (_rep.GetRoutes().Where(r => r.StartingStation == startingStaion &&
                r.LastStation == lastStaion)).ToList(); //.Select(r => r))
            return routes;
        }
    }
}
