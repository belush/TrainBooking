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
using TrainBooking.DAL.Repositories.Implementations;
using TrainBooking.Models;

namespace TrainBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StationController : BaseController
    {
        private readonly IStationLogic _stationLogic;

        public StationController()
        {
            var context = new TrainBookingContext();

            _stationLogic = new StationLogic(new StationRepository(context));
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var stations = _stationLogic.GetStationsList();
            var stationViews = stations.Select(x => new StationViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return View(stationViews);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StationViewModel stationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(stationViewModel);
            }

            var station = new Station
            {
                Id = stationViewModel.Id,
                Name = stationViewModel.Name
            };

            _stationLogic.AddStation(station);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var station = _stationLogic.GetStationById(id);
            var stationViewModel = new StationViewModel
            {
                Id = station.Id,
                Name = station.Name
            };
            return View(stationViewModel);
        }

        [HttpPost]
        public ActionResult Edit(StationViewModel stationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(stationViewModel);
            }

            var station = new Station
            {
                Id = stationViewModel.Id,
                Name = stationViewModel.Name
            };
            _stationLogic.EditStation(station);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var station = _stationLogic.GetStationById(id);
            return View(station);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _stationLogic.DeleteStationById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
