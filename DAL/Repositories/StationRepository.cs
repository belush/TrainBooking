using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories
{
    public class StationRepository : Repository
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
    }
}
