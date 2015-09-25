using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.DAL.Repositories.Implementations
{
    public class RouteRepository : Repository, IRouteRepository
    {
        public List<Route> GetRoutes()
        {
            return db.Routes.Where(r=>r.IsDeleted==false).ToList();
        }

        public void AddRoute(Route route)
        {
            db.Routes.Add(route);
            db.SaveChanges();
        }

        public void DeleteRoute(Route route)
        {
            route.IsDeleted = true;
            EditRoute(route);
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
