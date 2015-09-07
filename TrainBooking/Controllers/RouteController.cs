using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainBooking.BL;
using TrainBooking.BL.Logic;
using TrainBooking.DAL.Entities;

namespace TrainBooking.Controllers
{
    public class RouteController : Controller
    {
        RouteLogic logic = new RouteLogic();

        public ActionResult Index()
        {
            List<Route> routes = logic.GetRoutesList();
            return View(routes);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Route route)
        {
            try
            {
                //
                // как настроить БД чтобы она сама обновлялась при изменении
                //

                //
                // как лучше оформить добавление промежуточных станций?
                //
                logic.AddRoute(route);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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