using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.BL.Logic.Interfaces
{
    public interface IStationRouteLogic
    {
        List<StationRoute> GetStationRoutesList();
        StationRoute GetStationRouteById(int id);
        void DeleteStationRouteById(int id);
        void AddStationRoute(StationRoute stationRoute);
        void DeleteStationRoute(StationRoute stationRoute);
        void EditStationRoute(StationRoute stationRoute);
    }
}
