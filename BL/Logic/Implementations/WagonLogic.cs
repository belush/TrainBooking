using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Implementations;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.BL.Logic.Implementations
{
    public class WagonLogic : IWagonLogic
    {
        private readonly IWagonRepository _wagonRepository;



        public WagonLogic(IWagonRepository wagonRepository)
        {
            _wagonRepository = wagonRepository;
        }

        public double GetPrice(Wagon wagon, int? startingStationId, int? lastStationId)
        {
            double price = (wagon.Route.FullPrice);
            double q1 = 1;
            double q2 = 1;

            double answer = 1;

            if (startingStationId != 0 && lastStationId != 0)
            {
                if (wagon.Route.WayStations.Any(s => s.Station.Id == lastStationId) &&
                wagon.Route.WayStations.Any(s => s.Station.Id == startingStationId))
                {
                    q1 = (wagon.Route.WayStations.First(s => s.Station.Id == lastStationId).ArrivalDateTime.Ticks) -
                        (wagon.Route.WayStations.First(s => s.Station.Id == lastStationId).ArrivalDateTime.Ticks);
                    q2 = (wagon.Route.ArrivalDateTime - wagon.Route.DepatureDateTime).Ticks;
                }
            }

            answer = price * q1 / q2 * wagon.WagonType.Coefficient;

            return answer;
        }

        public List<Wagon> GetFilteredWagons(int startingStationId, int lastStationId)
        {
            List<Wagon> wagons = new List<Wagon>();

            if (startingStationId != lastStationId)
            {
                wagons = GetWagonList();

                if (startingStationId != 0)
                {
                    wagons = wagons.Where(w => w.Route.StartingStation.Station.Id == startingStationId).ToList();
                }

                if (lastStationId != 0)
                {
                    wagons = wagons.Where(w => w.Route.LastStation.Station.Id == lastStationId).ToList();
                }
            }

            return wagons;
        }

        public List<Wagon> GetWagonList()
        {
            return _wagonRepository.GetWagons();
        }

        public Wagon GetWagonById(int id)
        {
            return _wagonRepository.GetWagonById(id);
        }
    }
}
