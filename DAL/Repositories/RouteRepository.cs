using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.DAL.Repositories
{
    public class RouteRepository : Repository, IRouteRepository
    {
        public List<Route> GetRoutes()
        {
            return db.Routes.ToList();
        }

        public void AddRoute(Route route)
        {
            db.Routes.Add(route);
            db.SaveChanges();
        }

        public void DeleteRoute(Route route)
        {
            db.Routes.Remove(route);
            db.SaveChanges();
        }

        public void EditRoute(Route route)
        {
            db.Entry(route).State = EntityState.Modified;
            db.SaveChanges();
        }

        public RouteRepository(TrainBookingContext context)
            : base(context)
        {
        }
    }
}
