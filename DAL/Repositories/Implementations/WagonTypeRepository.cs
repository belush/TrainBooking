using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.DAL.Repositories.Implementations
{
    public class WagonTypeRepository : Repository, IWagonTypeRepository
    {
        public List<WagonType> GetWagonTypes()
        {
            return db.WagonTypes.ToList();
        }

        public void AddWagonType(WagonType wagonType)
        {
            db.WagonTypes.Add(wagonType);
            db.SaveChanges();
        }

        public void DeleteWagonType(WagonType wagonType)
        {
            db.WagonTypes.Remove(wagonType);
            db.SaveChanges();
        }

        public void EditWagonType(WagonType wagonType)
        {
            db.Entry(wagonType).State = EntityState.Modified;
            db.SaveChanges();
        }

        public WagonTypeRepository(TrainBookingContext context)
            : base(context)
        {
        }
    }
}
