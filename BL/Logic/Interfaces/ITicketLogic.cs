using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.BL.Logic.Interfaces
{
    public interface ITicketLogic
    {
        List<Ticket> GetTicketsList();
        Ticket GetTicketById(int id);
        void AddTicket(Ticket ticket);
    }
}
