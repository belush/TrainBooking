using System.Collections.Generic;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories.Interfaces
{
    public interface IWagonTypeRepository
    {
        List<WagonType> GetWagonTypes();
        WagonType GetWagonTypeById(int id);
        void AddWagonType(WagonType wagonType);
        void DeleteWagonType(WagonType wagonType);
        void EditWagonType(WagonType wagonType);
    }
}
