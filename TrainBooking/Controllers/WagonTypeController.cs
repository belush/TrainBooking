﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainBooking.BL.Logic.Implementations;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Implementations;
using TrainBooking.Models;
using AutoMapper;

namespace TrainBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WagonTypeController : BaseController
    {
        private readonly IWagonTypeLogic _wagonTypeLogic;

        public WagonTypeController()
        {
            var context = new TrainBookingContext();

            _wagonTypeLogic = new WagonTypeLogic(new WagonTypeRepository(context));
        }

        public ActionResult Index()
        {
            #region OLD MAPPING
            //var wagonTypeViewModelList =
            //    _wagonTypeLogic.GetWagonTypeList()
            //    .Select(w => new WagonTypeViewModel()
            //    {
            //        Id = w.Id,
            //        Name = w.Name,
            //        Coefficient = w.Coefficient,
            //        NumberOfPlaces = w.NumberOfPlaces
            //    });
            #endregion

            var wagonTypeList = _wagonTypeLogic.GetWagonTypeList();

            Mapper.CreateMap<WagonType, WagonTypeViewModel>();
            var wagonTypeViewModelList = Mapper.Map<List<WagonType>, List<WagonTypeViewModel>>(wagonTypeList);

            return View(wagonTypeViewModelList);
        }

        public ActionResult Create()
        {
            #region Wagon Types
            //Общий - 81
            //Плацкартный - 54
            //Купейный - 36
            //СВ - 18
            #endregion
            return View();
        }

        [HttpPost]
        public ActionResult Create(WagonTypeViewModel wagonTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(wagonTypeViewModel);
            }
            #region OLD MAPPING
            //var wagonType = new WagonType
            //{
            //    Id = wagonTypeViewModel.Id,
            //    Name = wagonTypeViewModel.Name,
            //    NumberOfPlaces = wagonTypeViewModel.NumberOfPlaces,
            //    Coefficient = wagonTypeViewModel.Coefficient
            //};
            #endregion
            Mapper.CreateMap<WagonTypeViewModel, WagonType>();
            var wagonType = Mapper.Map<WagonTypeViewModel, WagonType>(wagonTypeViewModel);

            _wagonTypeLogic.AddWagonType(wagonType);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            WagonType wagonType = _wagonTypeLogic.GetWagonTypeById(id);
            WagonTypeViewModel wagonTypeViewModel = new WagonTypeViewModel
            {
                Id = wagonType.Id,
                Name = wagonType.Name,
                NumberOfPlaces = wagonType.NumberOfPlaces,
                Coefficient = wagonType.Coefficient
            };

            return View(wagonTypeViewModel);
        }

        [HttpPost]
        public ActionResult Edit(WagonTypeViewModel wagonTypeViewModel)
        {
            //клиентская валидация отключена валидировать на сервере
            if (!ModelState.IsValid)
            {
                return View();
            }

            #region OLD MAPPING
            //WagonType wagonType = new WagonType
            //{
            //    Id = wagonTypeViewModel.Id,
            //    Name = wagonTypeViewModel.Name,
            //    NumberOfPlaces = wagonTypeViewModel.NumberOfPlaces,
            //    Coefficient = wagonTypeViewModel.Coefficient
            //};
             #endregion
            Mapper.CreateMap<WagonTypeViewModel, WagonType>();
            var wagonType = Mapper.Map<WagonTypeViewModel, WagonType>(wagonTypeViewModel);

            _wagonTypeLogic.EditWagonType(wagonType);

            return RedirectToAction("Index");
        }
    }
}
