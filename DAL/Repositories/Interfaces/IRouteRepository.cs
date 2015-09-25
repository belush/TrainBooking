using System.Collections.Generic;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories.Interfaces
{
    public interface IRouteRepository
    {
        List<Route> GetRoutes();
        void AddRoute(Route route);
        void DeleteRoute(Route route);
        void EditRoute(Route route);
    }
}
