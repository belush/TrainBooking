using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
