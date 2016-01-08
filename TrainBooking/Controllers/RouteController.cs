using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TrainBooking.BL;
using TrainBooking.BL.Logic;
using TrainBooking.BL.Logic.Implementations;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;
using TrainBooking.DAL.Repositories.Implementations;
using TrainBooking.Models;
using TrainBooking.Models.RouteModels;
using TrainBooking.Models.StationRouteModels;
using TrainBooking.Models.WagonModels;
using WebGrease.Css.Extensions;
using AutoMapper;

namespace TrainBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RouteController : BaseController
    {
        private readonly IRouteLogic _routeLogic;
        private readonly IStationLogic _stationLogic;
        private readonly IStationRouteLogic _stationRouteLogic;
        private readonly IWagonTypeLogic _wagonTypeLogic;
        private readonly ITicketLogic _ticketLogic;

        //git commit

        public RouteController()
        {
            var context = new TrainBookingContext();
            
            _routeLogic = new RouteLogic(new RouteRepository(context));
            _stationLogic = new StationLogic(new StationRepository(context));
            _stationRouteLogic = new StationRouteLogic(new StationRouteRepository(context));
            _wagonTypeLogic = new WagonTypeLogic(new WagonTypeRepository(context));
            _ticketLogic = new TicketLogic(new TicketRepository(context));
        }

        [AllowAnonymous]
        public ActionResult RouteSearch(string startingStationName = "", string lastStationName = "",
            DateTime? startingDateTime = null)
        {
            var routes = _routeLogic.RouteSearch(startingStationName, lastStationName, startingDateTime);

            if (routes.Count <= 0)
            {
                return PartialView();
            }

            List<Ticket> tickets = _ticketLogic.GetTicketsList();

            #region OLD MAPPING
            //List<RouteViewModel> routeViewModels = routes.Select(r => new RouteViewModel
            //{
            //    Id = r.Id,
            //    Name = r.Name,
            //    Number = r.Number,
            //    DepatureDateTime = r.DepatureDateTime,
            //    ArrivalDateTime = r.ArrivalDateTime,
            //    StartingStation = r.StartingStation.Station.Name,
            //    LastStation = r.LastStation.Station.Name,
            //    WayStations = r.WayStations.ToList(),
            //    //EmptyPlaces = r.Wagons.Select(w => w.WagonType.NumberOfPlaces).Sum()
            //    //EmptyPlaces = r.Wagons.Select(w => w.WagonType.NumberOfPlaces).Sum() - tickets.Where(t => t.Wagon.Route.Id == r.Id).Select(t => t.PlaceNumber).Count()

            //    //ПРОВЕРИТЬ НА НОРМАЛЬНОСТЬ!!!!
            //    EmptyPlaces = _routeLogic.GetEmptyPlacesCount(r, tickets)
            //}).ToList();
            #endregion

            //ToDo: finish GetEmptyPlacesCount 
            Mapper.CreateMap<Route, RouteViewModel>()
              .ForMember(x => x.StartingStation, opt => opt.MapFrom(src => src.StartingStation.Station.Name))
              .ForMember(x => x.LastStation, opt => opt.MapFrom(src => src.LastStation.Station.Name))
              .ForMember(x => x.WayStations, opt => opt.MapFrom(src => src.WayStations.ToList()))
              .ForMember(x => x.EmptyPlaces, opt => opt.MapFrom(src => _routeLogic.GetEmptyPlacesCount(src, tickets)));

            var routeViewModels = Mapper.Map<List<Route>, List<RouteViewModel>>(routes);



            return PartialView(routeViewModels);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Route> routes = _routeLogic.GetRoutesList();

            #region OLD MAPPING
            //List<RouteViewModel> routeViewModels = routes.Select(r => new RouteViewModel()
            //{
            //    Id = r.Id,
            //    Name = r.Name,
            //    Number = r.Number,
            //    DepatureDateTime = r.DepatureDateTime,
            //    ArrivalDateTime = r.ArrivalDateTime,
            //    StartingStation = r.StartingStation.Station.Name,
            //    LastStation = r.LastStation.Station.Name,
            //    WayStations = r.WayStations.ToList(),
            //    EmptyPlaces = r.Wagons.Select(w => w.WagonType.NumberOfPlaces).Sum(),
            //    Price = r.FullPrice
            //}).ToList();
            #endregion

            //Mapper.CreateMap<Route, RouteViewModel>()
            //    .ForMember(x => x.StartingStation, opt => opt.MapFrom(src => src.StartingStation.Station.Name))
            //    .ForMember(x => x.LastStation, opt => opt.MapFrom(src => src.LastStation.Station.Name))
            //    .ForMember(x => x.WayStations, opt => opt.MapFrom(src => src.WayStations.ToList()))
            //    .ForMember(x => x.EmptyPlaces, opt => opt.MapFrom(src => src.Wagons.Select(w => w.WagonType.NumberOfPlaces).Sum()))
            //    .ForMember(x => x.Price, opt => opt.MapFrom(src => src.FullPrice));

            var routeViewModels = Mapper.Map<List<Route>, List<RouteViewModel>>(routes);

            return View(routeViewModels);
        }


        public ActionResult Report()
        {
            List<Ticket> tickets = _ticketLogic.GetTicketsList();

            IEnumerable<string> routeNames = tickets.Select(t => t.Wagon.Route.Name).Distinct();

            List<ScheduleViewModel> scheduleViewModels = routeNames.Select(routeName => new ScheduleViewModel
            {
                Name = routeName,
                Count = tickets.Count(t => t.Wagon.Route.Name == routeName),
                FullPrice = tickets.Where(t => t.Wagon.Route.Name == routeName).Select(t => t.Price).Sum()
            }).ToList();


            #region OLD CODE
            //List<ScheduleViewModel> scheduleViewModels = new List<ScheduleViewModel>();

            //List<Ticket> tickets = _ticketLogic.GetTicketsList();

            //IEnumerable<string> routeNames = tickets.Select(t => t.Wagon.Route.Name).Distinct();

            //foreach (string routeName in routeNames)
            //{
            //    scheduleViewModels.Add(new ScheduleViewModel
            //    {
            //        Name = routeName,
            //        Count = tickets.Count(t => t.Wagon.Route.Name == routeName),
            //        FullPrice = tickets.Where(t => t.Wagon.Route.Name == routeName).Select(t => t.Price).Sum()
            //    });
            //}
            #endregion

            scheduleViewModels = scheduleViewModels.OrderByDescending(s => s.Count).ToList();

            #region OLD CODE
            //foreach (Ticket ticket in tickets)
            //{
            //    scheduleViewModels.Add(new ScheduleViewModel
            //    {
            //        Name = ticket.Wagon.Route.Name,
            //        Count = tickets.Count(t => t.Wagon.Route.Name == ticket.Wagon.Route.Name),
            //        FullPrice = tickets.Where(t => t.Wagon.Route.Name == ticket.Wagon.Route.Name).Select(t => t.Price).Sum()
            //    });
            //}

            //scheduleViewModels = (List<ScheduleViewModel>) scheduleViewModels.Distinct();

            //RouteAddViewModel routeAddViewModel = new RouteAddViewModel
            //{
            //    StationsListItems = _stationLogic.GetStationsListItems()
            //};
            #endregion

            return View(scheduleViewModels);
        }

        public ActionResult Create()
        {
            RouteAddViewModel routeAddViewModel = new RouteAddViewModel
            {
                StationsListItems = _stationLogic.GetStationsListItems()
            };

            return View(routeAddViewModel);
        }

        [HttpPost]
        public ActionResult Create(RouteAddViewModel routeAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                routeAddViewModel.StationsListItems = _stationLogic.GetStationsListItems();
                return View(routeAddViewModel);
            }

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

            #region OLD CODE
            //Route route = new Route
            //{
            //    Id = routeAddViewModel.Id,
            //    Name = routeAddViewModel.Name,
            //    Number = routeAddViewModel.Number,
            //    DepatureDateTime = routeAddViewModel.DepatureDate.AddHours(routeAddViewModel.DepatureTime.Hours)
            //        .AddMinutes(routeAddViewModel.DepatureTime.Minutes),
            //    ArrivalDateTime = routeAddViewModel.ArrivalDate.AddHours(routeAddViewModel.ArrivalTime.Hours)
            //        .AddMinutes(routeAddViewModel.ArrivalTime.Minutes),
            //    FullPrice = routeAddViewModel.Price,
            //    StartingStation = startingStation,
            //    LastStation = lastStation,
            //};
            #endregion

            //ToDo: move setting startingStation, lastStation from Mapper to controller
            Mapper.CreateMap<RouteAddViewModel, Route>()
                .ForMember(x => x.DepatureDateTime, o => o.MapFrom(s => s.DepatureDate.AddHours(s.DepatureTime.Hours)
                    .AddMinutes(s.DepatureTime.Minutes)))
                .ForMember(x => x.ArrivalDateTime, o => o.MapFrom(s => s.ArrivalDate.AddHours(s.ArrivalTime.Hours)
                    .AddMinutes(s.ArrivalTime.Minutes)))
                //CAN MINIMIZE BY RENAME FULLPRICE TO PRICE
                .ForMember(x => x.FullPrice, o => o.MapFrom(s => s.Price))
                .ForMember(x => x.StartingStation, o => o.MapFrom(s => startingStation))
                .ForMember(x => x.LastStation, o => o.MapFrom(s => lastStation));

            var route = Mapper.Map<RouteAddViewModel, Route>(routeAddViewModel);

            _routeLogic.AddRoute(route);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Route route = _routeLogic.GetRouteById(id);

            #region OLD MAPPING

            //ToDo: move automapper
            //ToDo: bootswatch google
            RouteAddViewModel routeEditViewModel = new RouteAddViewModel
            {
                Id = route.Id,
                Name = route.Name,
                Number = route.Number,
                StartingStationRoute = route.StartingStation.Id,
                LastStationRoute = route.LastStation.Id,
                StartingStation = route.StartingStation.Station.Id,
                LastStation = route.LastStation.Station.Id,
                DepatureDate = route.DepatureDateTime.Date,
                DepatureTime = new TimeSpan(0, route.DepatureDateTime.Hour, route.DepatureDateTime.Minute, 0),
                ArrivalDate = route.ArrivalDateTime,
                ArrivalTime = new TimeSpan(0, route.ArrivalDateTime.Hour, route.ArrivalDateTime.Minute, 0),
                StationsListItems = _stationLogic.GetStationsListItems()
            };
            #endregion

            //Mapper.CreateMap<Route, RouteAddViewModel>()
            //   .ForMember(x => x.StartingStation, opt => opt.MapFrom(src => src.StartingStation.Station.Name))
            //   .ForMember(x => x.LastStation, opt => opt.MapFrom(src => src.LastStation.Station.Name))
            //   .ForMember(x => x.StartingStationRoute, opt => opt.MapFrom(src => src.StartingStation.Id))
            //   .ForMember(x => x.LastStationRoute, opt => opt.MapFrom(src => src.LastStation.Id))
            //   .ForMember(x => x.DepatureDate, opt => opt.MapFrom(src => src.DepatureDateTime.Date))
            //   .ForMember(x => x.DepatureTime, opt => opt.MapFrom(src => new TimeSpan(0, src.DepatureDateTime.Hour, src.DepatureDateTime.Minute, 0)))
            //    .ForMember(x => x.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDateTime))
            //   .ForMember(x => x.ArrivalTime, opt => opt.MapFrom(src => new TimeSpan(0, src.ArrivalDateTime.Hour, src.ArrivalDateTime.Minute, 0)))
            //   .ForMember(x => x.StationsListItems, opt => opt.MapFrom(src => _stationLogic.GetStationsListItems()));

            //var routeEditViewModel = Mapper.Map<Route, RouteAddViewModel>(route);

            return View(routeEditViewModel);
        }

        [HttpPost]
        public ActionResult Edit(RouteAddViewModel routeEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                routeEditViewModel.StationsListItems = _stationLogic.GetStationsListItems();
                return View(routeEditViewModel);
            }

            var start = _stationLogic.GetStationById(routeEditViewModel.StartingStation);
            var last = _stationLogic.GetStationById(routeEditViewModel.LastStation);

            StationRoute startingStation = _stationRouteLogic.GetStationRouteById(routeEditViewModel.StartingStationRoute);
            startingStation.Station = start;

            StationRoute lastStation = _stationRouteLogic.GetStationRouteById(routeEditViewModel.LastStationRoute);
            lastStation.Station = last;

            Route route = new Route
            {
                Id = routeEditViewModel.Id,
                Name = routeEditViewModel.Name,
                Number = routeEditViewModel.Number,
                StartingStation = startingStation,
                LastStation = lastStation,
                DepatureDateTime = routeEditViewModel.DepatureDate.AddHours(routeEditViewModel.DepatureTime.Hours)
                    .AddMinutes(routeEditViewModel.DepatureTime.Minutes),
                ArrivalDateTime = routeEditViewModel.ArrivalDate.AddHours(routeEditViewModel.ArrivalTime.Hours)
                    .AddMinutes(routeEditViewModel.ArrivalTime.Minutes)
            };

            _routeLogic.EditRoute(route);

            return RedirectToAction("Index");
        }

        public ActionResult AddWay(int id)
        {
            StationRouteAddViewModel stationRouteAddViewModel = new StationRouteAddViewModel
            {
                RouteId = id,
                StationsListItems = _stationLogic.GetStationsListItems()
            };

            return View(stationRouteAddViewModel);
        }

        [HttpPost]
        public ActionResult AddWay(StationRouteAddViewModel stationRouteAddViewModel)
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

        public ActionResult AddWagons(int id)
        {
            Route route = _routeLogic.GetRouteById(id);
            WagonAddViewModel wagonAddViewModel = new WagonAddViewModel
            {
                RouteId = route.Id,
                WagonTypeListItems = _wagonTypeLogic.GetWagonTypeListItems()
            };

            return View(wagonAddViewModel);
        }

        [HttpPost]
        public ActionResult AddWagons(WagonAddViewModel wagonAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                wagonAddViewModel.WagonTypeListItems = _wagonTypeLogic.GetWagonTypeListItems();
                return View(wagonAddViewModel);
            }

            Route route = _routeLogic.GetRouteById(wagonAddViewModel.RouteId);
            WagonType wagonType = _wagonTypeLogic.GetWagonTypeById(wagonAddViewModel.WagonType);

            for (int i = 0; i < wagonAddViewModel.NumberOfWagons; i++)
            {
                Wagon wagon = new Wagon
                {
                    Number = i + 1,
                    WagonType = wagonType,
                    Tickets = new List<Ticket>()
                };
                route.Wagons.Add(wagon);
            }

            _routeLogic.EditRoute(route);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Route route = _routeLogic.GetRouteById(id);
            return View(route);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _routeLogic.DeleteRouteById(id);

            return RedirectToAction("Index");
        }
    }
}