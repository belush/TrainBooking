using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories.Interfaces
{
    public interface IWagonTypeRepository
    {
        List<WagonType> GetWagonTypes();
        void AddWagonType(WagonType wagonType);
        void DeleteWagonType(WagonType wagonType);
        void EditWagonType(WagonType wagonType);
    }
}
