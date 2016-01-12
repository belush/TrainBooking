using System;
using System.Collections.Generic;
using System.IO;
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
            return _ticketRepository.GetTicketById(id);
        }

        public void AddTicket(Ticket ticket)
        {
            _ticketRepository.AddTicket(ticket);
        }

        //
        public string GetFilePathForTicket()
        {
            return "/Content/Ticket.txt";
        }

        public string GetContentType()
        {
            return "application/txt";
        }

        public string GetDownloadName(int ticketNumber)
        {
            return string.Format("Ticket #{0}.txt", ticketNumber);
        }

        public void WriteTicket(int ticketId, string filePath)
        {
            Ticket ticket = GetTicketById(ticketId);

            using (StreamWriter file = new StreamWriter(System.IO.File.Open(filePath, FileMode.OpenOrCreate), Encoding.UTF8))
            {
                file.WriteLine("Билет №" + ticket.Id);
                file.WriteLine();

                file.WriteLine(string.Format("ФИО: {0} {1} {2}", ticket.User.LastName, ticket.User.MidName, ticket.User.FirstName));
                file.WriteLine();

                file.WriteLine("Станция отправки: " + ticket.Wagon.Route.StartingStation.Station.Name);
                file.WriteLine("Станция прибытия: " + ticket.Wagon.Route.LastStation.Station.Name);
                file.WriteLine();

                file.WriteLine("Дата/Время отправки: "+ticket.Wagon.Route.DepatureDateTime);
                file.WriteLine("Дата/Время прибытия: " + ticket.Wagon.Route.ArrivalDateTime);
                file.WriteLine();

                file.WriteLine("Поезд #" + ticket.Wagon.Route.Number);
                file.WriteLine("Вагон #" + ticket.Wagon.Number);
                file.WriteLine("Место #"+ ticket.PlaceNumber);
                file.WriteLine("Цена: " + ticket.Price);
                file.WriteLine();
            }
        }

        
    }
}
