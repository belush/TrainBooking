using System.Collections.Generic;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetTickets();
        Ticket GetTicketById(int id);
        void AddTicket(Ticket ticket);
    }
}
