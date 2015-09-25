using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainBooking.DAL.Entities;

namespace TrainBooking.BL.Logic.Interfaces
{
    public interface IWagonTypeLogic
    {
        List<WagonType> GetWagonTypeList();
        List<SelectListItem> GetWagonTypeListItems();
        WagonType GetWagonTypeById(int id);
        void DeleteWagonTypeById(int id);
        void AddWagonType(WagonType wagonType);
        void DeleteWagonType(WagonType wagonType);
        void EditWagonType(WagonType wagonType);
    }
}
