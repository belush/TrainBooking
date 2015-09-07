using System.Collections.Generic;
using System.Linq;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;

namespace TrainBooking.BL.Logic
{
    public class StationLogic
    {
        private StationRepository rep = new StationRepository();

        public List<Station> GetStationsList()
        {
            List<Station> stations = rep.GetStations();
            return stations;
        }

        public Station GetStationById(int id)
        {
            Station station = rep.GetStations().First(s => s.Id == id);
            return station;
        }

        public void DeleteStationById(int id)
        {
            Station station = GetStationById(id);
            rep.DeleteStation(station);
        }

        public void AddStation(Station station)
        {
            rep.AddStation(station);
        }

        public void DeleteStation(Station station)
        {
            rep.DeleteStation(station);
        }

        public void EditStation(Station station)
        {
            rep.EditStation(station);
        }


    }
}
