using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainBooking.BL;
using TrainBooking.BL.Logic;
using TrainBooking.BL.Logic.Implementations;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;
using TrainBooking.Models;

namespace TrainBooking.Controllers
{
    public class RouteController : Controller
    {
        private IRouteLogic logic;

        private readonly IStationLogic stationLogic;
        private readonly IStationRouteLogic stationRoteLogic;

        public RouteController()
        {
            var context = new TrainBookingContext();

            logic = new RouteLogic(new RouteRepository(context));
            stationLogic = new StationLogic(new StationRepository(context));
            stationRoteLogic = new StationRouteLogic(new StationRouteRepository(context));
        }

        public List<SelectListItem> GetStationsListItems()
        {
            List<SelectListItem> stationsListItems = stationLogic.GetStationsList().
                Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList();

            return stationsListItems;
        }

        public ActionResult Index()
        {
            List<Route> routes = logic.GetRoutesList();

            List<RouteViewModel> routeViewModels = routes.Select(r => new RouteViewModel()
            {
                Id = r.Id,
                Name = r.Name,
                Number = r.Number,
                DepatureDate = r.DepatureDate,
                DepatureTime = r.DepatureTime,
                ArrivalDate = r.ArrivalDate,
                ArrivalTime = r.ArrivalTime,
                StartingStation=r.StartingStation.Station.Id,
                LastStation = r.LastStation.Station.Id
            }).ToList();

            return View(routeViewModels);
        }

        public ActionResult Create()
        {
            ViewData["stations"] = GetStationsListItems();
            return View();
        }

        [HttpPost]
        public ActionResult Create(RouteViewModel routeViewModel)
        {
            #region
            //
            // как настроить БД чтобы она сама обновлялась при изменении
            //

            //
            // как лучше оформить добавление промежуточных станций?
            //
            #endregion
            //            try
            //            {
            var start = stationLogic.GetStationById(routeViewModel.StartingStation);
            var last = stationLogic.GetStationById(routeViewModel.LastStation);

            StationRoute startingStation = new StationRoute
            {
                ArrivalDate = routeViewModel.ArrivalDate,
                ArrivalTime = routeViewModel.ArrivalTime,
                DepatureDate = routeViewModel.DepatureDate,
                DepatureTime = routeViewModel.DepatureTime,
                Station = start
            };
            StationRoute lastStation = new StationRoute
            {
                ArrivalDate = routeViewModel.ArrivalDate,
                ArrivalTime = routeViewModel.ArrivalTime,
                DepatureDate = routeViewModel.DepatureDate,
                DepatureTime = routeViewModel.DepatureTime,
                Station = last
            };



            Route route = new Route();
            route.Id = routeViewModel.Id;
            route.Name = routeViewModel.Name;
            route.Number = routeViewModel.Number;
            route.StartingStation = startingStation;
            route.LastStation = lastStation;

            route.DepatureDate = routeViewModel.DepatureDate;
            route.DepatureTime = routeViewModel.DepatureTime;
            route.ArrivalTime = routeViewModel.ArrivalTime;
            route.ArrivalDate = routeViewModel.ArrivalDate;


            logic.AddRoute(route);

            return RedirectToAction("Index");

            //            }
            //            catch
            //            {
            //                return View();
            //            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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