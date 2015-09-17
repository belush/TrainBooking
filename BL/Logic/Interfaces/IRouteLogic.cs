using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.BL.Logic.Interfaces
{
    public interface IRouteLogic
    {
        List<Route> GetRoutesList();
        Route GetRouteById(int id);
        void DeleteRouteById(int id);
        void AddRoute(Route route);
        void DeleteRoute(Route route);
        void EditRoute(Route route);
        List<Route> FindRoute(Station startingStaion, Station lastStaion);
    }
}
