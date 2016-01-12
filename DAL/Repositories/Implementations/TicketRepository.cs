using System.Collections.Generic;
using System.Linq;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.DAL.Repositories.Implementations
{
    public class TicketRepository : Repository, ITicketRepository
    {
        public List<Ticket> GetTickets()
        {
            return db.Tickets.ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return db.Tickets.FirstOrDefault(t => t.Id == id);
        }

        public void AddTicket(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }

        public TicketRepository(TrainBookingContext context)
            : base(context) { }
    }
}
