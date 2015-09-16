using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainBooking.BL;
using TrainBooking.BL.Logic;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;
using TrainBooking.Models;

namespace TrainBooking.Controllers
{
    public class StationController : Controller
    {
        //StationLogic logic = new StationLogic();

        private readonly IStationLogic logic;

        public StationController()
        {
            var context = new TrainBookingContext();

            logic = new StationLogic(new StationRepository(context));
        }

        public ActionResult Index()
        {
            List<Station> stations = logic.GetStationsList();

            List<StationViewModel> stationViews = stations.Select(x => new StationViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return View(stationViews);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Station station)
        {
            try
            {
                logic.AddStation(station);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            //
            // как сохрнить дату при редактировании сущности? поиграть с форматами выведения дат
            //
            Station station = logic.GetStationById(id);
            StationViewModel stationVM = new StationViewModel();
            stationVM.Id = station.Id;
            stationVM.Name = station.Name;
            return View(stationVM);
        }

        [HttpPost]
        public ActionResult Edit(StationViewModel stationVM)
        {
            try
            {
                Station station = new Station();
                station.Id = stationVM.Id;
                station.Name = stationVM.Name;
                logic.EditStation(station);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Station station = logic.GetStationById(id);
            return View(station);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                logic.DeleteStationById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
