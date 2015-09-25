using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.BL.Logic
{
    public class StationLogic : IStationLogic
    {
        private readonly IStationRepository _repository;

        public StationLogic(IStationRepository repository)
        {
            this._repository = repository;
        }

        public List<SelectListItem> GetStationsListItems()
        {
            List<SelectListItem> stationsListItems = GetStationsList().
                Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList();

            return stationsListItems;
        }

        public List<SelectListItem> GetStationsListItemsByRouteId(int routeId)
        {

            List<SelectListItem> stationsListItems = GetStationsList().
                Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList();

            return stationsListItems;
        }

        public List<Station> GetStationsList()
        {
            List<Station> stations = _repository.GetStations();
            return stations;
        }

        public Station GetStationById(int id)
        {
            Station station = _repository.GetStations().First(s => s.Id == id);
            return station;
        }

        public void DeleteStationById(int id)
        {
            Station station = GetStationById(id);
            _repository.DeleteStation(station);
        }

        public void AddStation(Station station)
        {
            _repository.AddStation(station);
        }

        public void DeleteStation(Station station)
        {
            _repository.DeleteStation(station);
        }

        public void EditStation(Station station)
        {
            _repository.EditStation(station);
        }
    }
}
