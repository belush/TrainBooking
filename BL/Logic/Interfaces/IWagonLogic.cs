using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.BL.Logic.Interfaces
{
    public interface IWagonLogic
    {
        List<Wagon> GetWagonList();
        Wagon GetWagonById(int id);
        double GetPrice(Wagon wagon, int? startingStationId, int? lastStationId);
        List<Wagon> GetFilteredWagons(int startingStationId, int lastStationId);
    }
}
