using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DotNetOpenAuth.Messaging;
using TrainBooking.BL.Logic;
using TrainBooking.BL.Logic.Implementations;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories;
using TrainBooking.DAL.Repositories.Implementations;
using TrainBooking.Models;
using TrainBooking.Models.WagonModels;
using WebMatrix.WebData;

namespace TrainBooking.Controllers
{
    [Authorize(Roles = "User")]
    public class WagonController : BaseController
    {
        private readonly IWagonLogic _wagonLogic;
        private readonly IUserLogic _userLogic;
        private readonly IStationLogic _stationLogic;
        private readonly IStationRouteLogic _stationRouteLogic;
        private readonly IRouteLogic _routeLogic;
        private readonly ITicketLogic _ticketLogic;

        public WagonController()
        {
            var context = new TrainBookingContext();

            _wagonLogic = new WagonLogic(new WagonRepository(context));
            _userLogic = new UserLogic(new UserRepository(context));
            _stationLogic = new StationLogic(new StationRepository(context));
            _routeLogic = new RouteLogic(new RouteRepository(context));
            _ticketLogic = new TicketLogic(new TicketRepository(context));
            _stationRouteLogic = new StationRouteLogic(new StationRouteRepository(context));
        }

        public ActionResult Index(int id)
        {
            List<Wagon> wagons = _wagonLogic.GetWagonList().Where(w => w.Route.Id == id).ToList();

            var wagonViewModels = wagons.Select(w => new WagonViewModel()
            {
                Id = w.Id,
                Number = w.Number,
                WagonType = w.WagonType
            });

            List<Station> stations = _routeLogic.GetRoutesList().Where(r => r.Id == id).Select(r => r.StartingStation.Station).ToList();
            stations.AddRange(_routeLogic.GetRoutesList().Where(r => r.Id == id).Select(r => r.LastStation.Station));

            var stationsSecond = new List<Station>();

            foreach (Route route in _routeLogic.GetRoutesList().Where(r => r.Id == id))
            {
                stationsSecond.AddRange(route.WayStations.Select(w => w.Station).ToList());
            }
            stations.AddRange(stationsSecond);

            List<SelectListItem> stationsListItems = stations.
             Select(s => new SelectListItem()
             {
                 Text = s.Name,
                 Value = s.Id.ToString()
             }).ToList();

            ViewData["stations"] = stationsListItems;

            return View(wagonViewModels);
        }


        public ActionResult RouteChoose(int startingStationId = 0, int lastStationId = 0)
        {
            var wagons = _wagonLogic.GetFilteredWagons(startingStationId, lastStationId);

            var wagonViewModels = wagons.Select(w => new WagonViewModel()
            {
                Id = w.Id,
                Number = w.Number,
                WagonType = w.WagonType,
                Route = w.Route,
                PricePerPlace = _wagonLogic.GetPrice(w, startingStationId, lastStationId),
                EmptyPlaces = new List<int>()
            }).ToList();

            List<Ticket> tickets = _ticketLogic.GetTicketsList();

            //tickets = tickets.Where(t => t.StartingStationRoute == startingStationId).ToList();
            //tickets = tickets.Where(t => (t.StartingStationRoute == startingStationId)
            //    && (t.LastStationRoute == lastStationId)).ToList();

            //tickets =
            //    tickets.Where(
            //        t =>
            //            (_stationRouteLogic.GetStationRouteById(t.StartingStationRoute).Station.Id == startingStationId))
            //        .ToList();

            //tickets =
            //    tickets.Where(
            //        t =>
            //            (_stationRouteLogic.GetStationRouteById(t.LastStationRoute).Station.Id == lastStationId))
            //        .ToList();


            foreach (WagonViewModel wagonViewModel in wagonViewModels)
            {
                wagonViewModel.EmptyPlaces =
                    tickets.Where(t => t.Wagon.Id == wagonViewModel.Id).Select(t => t.PlaceNumber).ToList();
            }

            return PartialView(wagonViewModels);
        }


        public ActionResult BuyTicket(int id, int placeNumber)
        {
            Wagon wagon = _wagonLogic.GetWagonById(id);

            User user = _userLogic.GetUserById(WebSecurity.CurrentUserId);

            Route route = wagon.Route;

            var stations = route.WayStations.Select(w => w.Station).ToList();
            stations.Add(route.StartingStation.Station);
            stations.Add(route.LastStation.Station);

            List<SelectListItem> stationsListItems = stations.
               Select(s => new SelectListItem()
               {
                   Text = s.Name,
                   Value = s.Id.ToString()
               }).ToList();

            TicketViewModel ticketViewModel = new TicketViewModel
            {
                WagonNumber = wagon.Number,
                UserName = user.FirstName,
                PlaceNumber = placeNumber,
                StartingStationName = route.StartingStation.Station.Name,
                LastStationName = route.LastStation.Station.Name,
                StationsListItems = stationsListItems,
                Price = _wagonLogic.GetPrice(wagon, null, null),
                RouteNumber = route.Number,
                WagonId = wagon.Id,
                StartingStationRouteId = route.StartingStation.Id,
                LastStationRouteId = route.LastStation.Id,
                StartingStationId = route.StartingStation.Station.Id,
                LastStationId = route.LastStation.Station.Id,
            };

            return View(ticketViewModel);
        }

        [HttpPost]
        public ActionResult BuyTicket(TicketViewModel ticketViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ticketViewModel);
            }
            StationRoute startingStation = _stationRouteLogic.GetStationRouteById(ticketViewModel.StartingStationRouteId);
            StationRoute lastStation = _stationRouteLogic.GetStationRouteById(ticketViewModel.LastStationRouteId);
            User user = _userLogic.GetUserById(WebSecurity.CurrentUserId);
            Wagon wagon = _wagonLogic.GetWagonById(ticketViewModel.WagonId);

            Ticket ticket = new Ticket
            {
                Id = ticketViewModel.Id,
                StartingStationRoute = startingStation.Id,
                LastStationRoute = lastStation.Id,
                PlaceNumber = ticketViewModel.PlaceNumber,
                User = user,
                Wagon = wagon,
                Price = ticketViewModel.Price
            };

            _ticketLogic.AddTicket(ticket);

            return RedirectToAction("BuySucces");
        }

        public ActionResult BuySucces()
        {
            return View();
        }
    }
}
