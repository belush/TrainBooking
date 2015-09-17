using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainBooking.DAL.Entities;

namespace TrainBooking.BL.Logic.Interfaces
{
    public interface IStationLogic
    {
        List<Station> GetStationsList();
        List<SelectListItem> GetStationsListItems();
        Station GetStationById(int id);
        void DeleteStationById(int id);
        void AddStation(Station station);
        void DeleteStation(Station station);
        void EditStation(Station station);
    }
}
