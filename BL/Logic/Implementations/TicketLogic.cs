using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.BL.Logic.Implementations
{
    public class TicketLogic : ITicketLogic
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketLogic(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public List<Ticket> GetTicketsList()
        {
            return _ticketRepository.GetTickets();
        }

        public Ticket GetTicketById(int id)
        {
            return GetTicketsList().First(t => t.Id == id);
        }

        public void AddTicket(Ticket ticket)
        {
            _ticketRepository.AddTicket(ticket);
        }
    }
}
