using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
