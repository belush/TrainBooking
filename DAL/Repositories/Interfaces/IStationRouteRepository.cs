using System.Collections.Generic;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories.Interfaces
{
    public interface IStationRouteRepository
    {
        List<StationRoute> GetStationRoutes();
        void AddStationRoute(StationRoute stationRoute);
        void DeleteStationRoute(StationRoute stationRoute);
        void EditStationRoute(StationRoute stationRoute);
    }
}
