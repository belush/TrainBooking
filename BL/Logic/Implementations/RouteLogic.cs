using System.Collections.Generic;
using System.Linq;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.BL.Logic
{
    public class RouteLogic : IRouteLogic
    {
        private readonly IRouteRepository _repository;

        public RouteLogic(IRouteRepository repository)
        {
            _repository = repository;
        }

        public List<Route> GetRoutesList()
        {
            List<Route> routes = _repository.GetRoutes();
            return routes;
        }

        public Route GetRouteById(int id)
        {
            Route route = _repository.GetRoutes().First(r => r.Id == id);
            return route;
        }

        public void DeleteRouteById(int id)
        {
            Route route = GetRouteById(id);
            _repository.DeleteRoute(route);
        }

        public void AddRoute(Route route)
        {
            _repository.AddRoute(route);
        }

        public void DeleteRoute(Route route)
        {
            _repository.DeleteRoute(route);
        }

        public void EditRoute(Route route)
        {
            _repository.EditRoute(route);
        }

        public List<Route> FindRoute(Station startingStaion, Station lastStaion)
        {
            //Edit FindRoute code
            //List<Route> routes = (_repository.GetRoutes().Where(r => r.StartingStation == startingStaion &&
            //    r.LastStation == lastStaion)).ToList(); //.Select(r => r))
            return null;
        }
    }
}
