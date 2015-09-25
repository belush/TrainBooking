using System.Collections.Generic;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories.Interfaces
{
    public interface IWagonRepository
    {
        List<Wagon> GetWagons();
    }
}
