using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainBooking.BL.Logic;
using TrainBooking.BL.Logic.Implementations;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;
using TrainBooking.Models;

namespace TrainBooking.Controllers
{
    public class StationRouteController : Controller
    {
        private readonly IStationRouteLogic _stationRouteLogic;
        private readonly IRouteLogic _routeLogic;
        private readonly IStationLogic _stationLogic;

        public StationRouteController()
        {
            var context = new TrainBookingContext();

            _stationRouteLogic = new StationRouteLogic(new StationRouteRepository(context));
            _routeLogic = new RouteLogic(new RouteRepository(context));
            _stationLogic = new StationLogic(new StationRepository(context));
        }

        public ActionResult Index()
        {
            List<StationRoute> stationRoutes = _stationRouteLogic.GetStationRoutesList();

            List<StationRouteViewModel> stationRouteViewModels = _stationRouteLogic.GetStationRoutesList()
                .Select(sr => new StationRouteViewModel()
                {
                    Id = sr.Id,
                    StationName = sr.Station.Name,
                    ArrivalDateTime = sr.ArrivalDateTime,
                    DepatureDateTime = sr.DepatureDateTime
                }).ToList();

            return View(stationRouteViewModels);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create(int routeId)
        {
            StationRouteAddViewModel stationRouteAddViewModel = new StationRouteAddViewModel();
            stationRouteAddViewModel.RouteId = routeId;

            ViewData["stations"] = _stationLogic.GetStationsListItems();
            return View(stationRouteAddViewModel);
        }

        [HttpPost]
        public ActionResult Create(StationRouteAddViewModel stationRouteAddViewModel)
        {
            //try
            //{
            StationRoute stationRoute = new StationRoute();
            Station station = _stationLogic.GetStationById(stationRouteAddViewModel.StationId);
            Route route = _routeLogic.GetRouteById(stationRouteAddViewModel.RouteId);

            stationRoute.Id = stationRouteAddViewModel.Id;
            stationRoute.Station = station;
            //stationRoute.Route = route;
            stationRoute.DepatureDateTime = stationRouteAddViewModel.DepatureDate
                .Add(stationRouteAddViewModel.DepatureTime);
            stationRoute.ArrivalDateTime = stationRouteAddViewModel.ArrivalDate
                .Add(stationRouteAddViewModel.ArrivalTime);
            route.WayStations.Add(stationRoute);
            _routeLogic.EditRoute(route);
            //_stationRouteLogic.AddStationRoute(stationRoute);
            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
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
    }
}
