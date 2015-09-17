using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.DAL.Repositories
{
    public class StationRouteRepository : Repository, IStationRouteRepository
    {
        public List<StationRoute> GetStationRoutes()
        {
            return db.StationRoutes.ToList();
        }

        public void AddStationRoute(StationRoute stationRoute)
        {
            db.StationRoutes.Add(stationRoute);
            db.SaveChanges();
        }

        public void DeleteStationRoute(StationRoute stationRoute)
        {
            db.StationRoutes.Remove(stationRoute);
            db.SaveChanges();
        }

        public void EditStationRoute(StationRoute stationRoute)
        {
            //db.Entry(stationRoute).State = EntityState.Modified;
            //db.SaveChanges();

            db.Entry(stationRoute).State = EntityState.Modified;

            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    // Update the values of the entity that failed to save from the store 
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed); 
        }

        public StationRouteRepository(TrainBookingContext context)
            : base(context)
        {
        }
    }
}
