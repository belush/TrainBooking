using System.Collections.Generic;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories.Interfaces
{
    public interface IStationRepository
    {
        List<Station> GetStations();
        void AddStation(Station route);
        void DeleteStation(Station route);
        void EditStation(Station route);
    }
}
