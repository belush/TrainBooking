using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Implementations;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.BL.Logic.Implementations
{
    public class WagonTypeLogic : IWagonTypeLogic
    {
        private readonly IWagonTypeRepository _wagonTypeRepository;

        public WagonTypeLogic(IWagonTypeRepository wagonTypeRepository)
        {
            this._wagonTypeRepository = wagonTypeRepository;
        }

        public List<WagonType> GetWagonTypeList()
        {
            return _wagonTypeRepository.GetWagonTypes();
        }

        public List<SelectListItem> GetWagonTypeListItems()
        {
            List<SelectListItem> wagonTypeListItems = GetWagonTypeList().
                Select(w => new SelectListItem()
                {
                    Text = w.Name,
                    Value = w.Id.ToString()
                }).ToList();

            return wagonTypeListItems;
        }

        public WagonType GetWagonTypeById(int id)
        {
            return _wagonTypeRepository.GetWagonTypeById(id);
        }

        public void DeleteWagonTypeById(int id)
        {
            WagonType wagonType = GetWagonTypeById(id);
            _wagonTypeRepository.DeleteWagonType(wagonType);
        }

        public void AddWagonType(WagonType wagonType)
        {
            _wagonTypeRepository.AddWagonType(wagonType);
        }

        public void DeleteWagonType(WagonType wagonType)
        {
            _wagonTypeRepository.DeleteWagonType(wagonType);
        }

        public void EditWagonType(WagonType wagonType)
        {
            _wagonTypeRepository.EditWagonType(wagonType);
        }
    }
}
