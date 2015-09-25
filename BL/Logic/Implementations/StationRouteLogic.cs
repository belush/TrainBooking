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
        private readonly IStationRouteRepository _repository;

        public StationRouteLogic(IStationRouteRepository repository)
        {
            this._repository = repository;
        }

        public List<StationRoute> GetStationRoutesList()
        {
            return _repository.GetStationRoutes();
        }

        public StationRoute GetStationRouteById(int id)
        {
            return _repository.GetStationRoutes().First(s => s.Id == id);
        }

        public void DeleteStationRouteById(int id)
        {
            StationRoute stationRoute = GetStationRouteById(id);
            _repository.DeleteStationRoute(stationRoute);
        }

        public void AddStationRoute(StationRoute stationRoute)
        {
            _repository.AddStationRoute(stationRoute);
        }

        public void DeleteStationRoute(StationRoute stationRoute)
        {
            _repository.DeleteStationRoute(stationRoute);
        }

        public void EditStationRoute(StationRoute stationRoute)
        {
            _repository.EditStationRoute(stationRoute);
        }
    }
}
