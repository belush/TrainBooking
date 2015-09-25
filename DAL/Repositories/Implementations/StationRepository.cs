using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.DAL.Repositories.Implementations
{
    public class StationRepository : Repository, IStationRepository
    {
        public List<Station> GetStations()
        {
            return db.Stations.ToList();
        }

        public void AddStation(Station station)
        {
            db.Stations.Add(station);
            db.SaveChanges();
        }

        public void DeleteStation(Station station)
        {
            db.Stations.Remove(station);
            db.SaveChanges();
        }

        public void EditStation(Station station)
        {
            db.Entry(station).State = EntityState.Modified;
            db.SaveChanges();
        }

        public StationRepository(TrainBookingContext context)
            : base(context)
        {
        }
    }
}
