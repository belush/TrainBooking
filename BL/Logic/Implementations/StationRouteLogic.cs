using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.BL.Logic.Implementations
{
    public class StationRouteLogic : IStationRouteLogic
    {
        private IStationRouteRepository rep;

        public StationRouteLogic(IStationRouteRepository repository)
        {
            rep = repository;
        }

        public List<StationRoute> GetStationRoutesList()
        {
            List<StationRoute> stationRoutes = rep.GetStationRoutes();
            return stationRoutes;
        }

        public StationRoute GetStationRouteById(int id)
        {
            StationRoute stationRoute = rep.GetStationRoutes().First(s => s.Id == id);
            return stationRoute;
        }

        public void DeleteStationRouteById(int id)
        {
            StationRoute stationRoute = GetStationRouteById(id);
            rep.DeleteStationRoute(stationRoute);
        }

        public void AddStationRoute(StationRoute stationRoute)
        {
            rep.AddStationRoute(stationRoute);
        }

        public void DeleteStationRoute(StationRoute stationRoute)
        {
            rep.DeleteStationRoute(stationRoute);
        }

        public void EditStationRoute(StationRoute stationRoute)
        {
            rep.EditStationRoute(stationRoute);
        }
    }
}
