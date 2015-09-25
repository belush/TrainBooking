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
using TrainBooking.DAL.Repositories.Implementations;
using TrainBooking.Models;
using TrainBooking.Models.StationRouteModels;

namespace TrainBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StationRouteController : BaseController
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
            var stationRouteViewModels = _stationRouteLogic.GetStationRoutesList()
                .Select(sr => new StationRouteViewModel()
                {
                    Id = sr.Id,
                    StationName = sr.Station.Name,
                    ArrivalDateTime = sr.ArrivalDateTime,
                    DepatureDateTime = sr.DepatureDateTime
                }).ToList();

            return View(stationRouteViewModels);
        }

        public ActionResult Create(int routeId)
        {
            var stationRouteAddViewModel = new StationRouteAddViewModel
            {
                RouteId = routeId,
                StationsListItems = _stationLogic.GetStationsListItems()
            };

            return View(stationRouteAddViewModel);
        }

        [HttpPost]
        public ActionResult Create(StationRouteAddViewModel stationRouteAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                stationRouteAddViewModel.StationsListItems = _stationLogic.GetStationsListItems();
                return View(stationRouteAddViewModel);
            }

            Station station = _stationLogic.GetStationById(stationRouteAddViewModel.StationId);
            Route route = _routeLogic.GetRouteById(stationRouteAddViewModel.RouteId);

            StationRoute stationRoute = new StationRoute
            {
                Id = stationRouteAddViewModel.Id,
                Station = station,
                DepatureDateTime = stationRouteAddViewModel.DepatureDate
                    .Add(stationRouteAddViewModel.DepatureTime),
                ArrivalDateTime = stationRouteAddViewModel.ArrivalDate
                    .Add(stationRouteAddViewModel.ArrivalTime)
            };

            route.WayStations.Add(stationRoute);
            _routeLogic.EditRoute(route);

            return RedirectToAction("Index");
        }
    }
}
