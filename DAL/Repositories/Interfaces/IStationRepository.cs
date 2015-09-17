using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
