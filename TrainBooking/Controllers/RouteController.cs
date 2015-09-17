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
        private readonly IRouteLogic _routeLogic;
        private readonly IStationLogic _stationLogic;
        private readonly IStationRouteLogic _stationRouteLogic;

        public RouteController()
        {
            var context = new TrainBookingContext();

            _routeLogic = new RouteLogic(new RouteRepository(context));
            _stationLogic = new StationLogic(new StationRepository(context));
            _stationRouteLogic = new StationRouteLogic(new StationRouteRepository(context));
        }



        public ActionResult Index()
        {
            List<Route> routes = _routeLogic.GetRoutesList();
            StationRoute first = _stationRouteLogic.GetStationRouteById(8);
            StationRoute second = _stationRouteLogic.GetStationRouteById(9);

            List<RouteViewModel> routeViewModels = routes.Select(r => new RouteViewModel()
            {
                Id = r.Id,
                Name = r.Name,
                Number = r.Number,
                DepatureDateTime = r.DepatureDateTime,
                ArrivalDateTime = r.ArrivalDateTime,
                StartingStation = r.StartingStation.Station.Name,
                LastStation = r.LastStation.Station.Name,
                WayStations = r.WayStations.ToList()
            }).ToList();

            return View(routeViewModels);
        }

        public ActionResult Create()
        {
            ViewData["stations"] = _stationLogic.GetStationsList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(RouteAddViewModel routeAddViewModel)
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
            var start = _stationLogic.GetStationById(routeAddViewModel.StartingStation);
            var last = _stationLogic.GetStationById(routeAddViewModel.LastStation);

            StationRoute startingStation = new StationRoute
            {
                ArrivalDateTime = routeAddViewModel.ArrivalDate.AddHours(routeAddViewModel.ArrivalTime.Hours)
                .AddMinutes(routeAddViewModel.ArrivalTime.Minutes),
                DepatureDateTime = routeAddViewModel.DepatureDate.AddHours(routeAddViewModel.DepatureTime.Hours)
                .AddMinutes(routeAddViewModel.DepatureTime.Minutes),
                Station = start
            };
            StationRoute lastStation = new StationRoute
            {
                ArrivalDateTime = routeAddViewModel.ArrivalDate.AddHours(routeAddViewModel.ArrivalTime.Hours)
               .AddMinutes(routeAddViewModel.ArrivalTime.Minutes),
                DepatureDateTime = routeAddViewModel.DepatureDate.AddHours(routeAddViewModel.DepatureTime.Hours)
                .AddMinutes(routeAddViewModel.DepatureTime.Minutes),
                Station = last
            };

            Route route = new Route();
            route.Id = routeAddViewModel.Id;
            route.Name = routeAddViewModel.Name;
            route.Number = routeAddViewModel.Number;
            route.StartingStation = startingStation;
            route.LastStation = lastStation;
            route.DepatureDateTime =
                routeAddViewModel.DepatureDate.AddHours(routeAddViewModel.DepatureTime.Hours)
                    .AddMinutes(routeAddViewModel.DepatureTime.Minutes);
            route.ArrivalDateTime =
                routeAddViewModel.ArrivalDate.AddHours(routeAddViewModel.ArrivalTime.Hours)
                    .AddMinutes(routeAddViewModel.ArrivalTime.Minutes);

            _routeLogic.AddRoute(route);

            //ПРИСВАИВАНИЕ МАРШРУТОВ
            //int idStartingStation = startingStation.Id;
            //int idLastStation = lastStation.Id;

            //StationRoute stationRouteStart = _stationRouteLogic.GetStationRouteById(idStartingStation);
            //startingStation.Route = route;
            //_stationRouteLogic.EditStationRoute(stationRouteStart);

            //StationRoute stationRouteLast = _stationRouteLogic.GetStationRouteById(idLastStation);
            //lastStation.Route = route;
            //_stationRouteLogic.EditStationRoute(stationRouteLast);

            return RedirectToAction("Index");

            //            }
            //            catch
            //            {
            //                return View();
            //            }
        }

        public ActionResult Edit(int id)
        {
            ViewData["stations"] = _stationLogic.GetStationsListItems();

            Route route = _routeLogic.GetRouteById(id);
            RouteAddViewModel routeEditViewModel = new RouteAddViewModel();
            routeEditViewModel.Id = route.Id;
            routeEditViewModel.Name = route.Name;
            routeEditViewModel.Number = route.Number;
            routeEditViewModel.StartingStationRoute = route.StartingStation.Id;
            routeEditViewModel.LastStationRoute = route.LastStation.Id;
            routeEditViewModel.StartingStation = route.StartingStation.Station.Id;
            routeEditViewModel.LastStation = route.LastStation.Station.Id;
            routeEditViewModel.DepatureDate = route.DepatureDateTime.Date;
            routeEditViewModel.DepatureTime = new TimeSpan(0, route.DepatureDateTime.Hour, route.DepatureDateTime.Minute, 0);
            routeEditViewModel.ArrivalDate = route.ArrivalDateTime;
            routeEditViewModel.ArrivalTime = new TimeSpan(0, route.ArrivalDateTime.Hour, route.ArrivalDateTime.Minute, 0);
            return View(routeEditViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, RouteAddViewModel routeEditViewModel)
        {
            //try
            //{
            var start = _stationLogic.GetStationById(routeEditViewModel.StartingStation);
            var last = _stationLogic.GetStationById(routeEditViewModel.LastStation);

            StationRoute startingStation = _stationRouteLogic.GetStationRouteById(routeEditViewModel.StartingStationRoute);
            startingStation.Station = start;

            StationRoute lastStation = _stationRouteLogic.GetStationRouteById(routeEditViewModel.LastStationRoute);
            lastStation.Station = last;

            Route route = new Route();
            route.Id = routeEditViewModel.Id;
            route.Name = routeEditViewModel.Name;
            route.Number = routeEditViewModel.Number;
            route.StartingStation = startingStation;
            route.LastStation = lastStation;

            route.DepatureDateTime =
                routeEditViewModel.DepatureDate.AddHours(routeEditViewModel.DepatureTime.Hours)
                    .AddMinutes(routeEditViewModel.DepatureTime.Minutes);
            route.ArrivalDateTime =
                routeEditViewModel.ArrivalDate.AddHours(routeEditViewModel.ArrivalTime.Hours)
                    .AddMinutes(routeEditViewModel.ArrivalTime.Minutes);


            _routeLogic.EditRoute(route);

            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }


        public ActionResult AddWay(int id)
        {
            StationRouteAddViewModel stationRouteAddViewModel = new StationRouteAddViewModel();
            stationRouteAddViewModel.RouteId = id;

            ViewData["stations"] = _stationLogic.GetStationsListItems();
            return View(stationRouteAddViewModel);
        }

        [HttpPost]
        public ActionResult AddWay(StationRouteAddViewModel stationRouteAddViewModel)
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

            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        public ActionResult Delete(int id)
        {
            Route route = _routeLogic.GetRouteById(id);
            return View(route);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _routeLogic.DeleteRouteById(id);

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