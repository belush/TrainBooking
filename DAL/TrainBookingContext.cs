﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL
{
    public class TrainBookingContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<StationRoute> StationRoutes { get; set; }
        public DbSet<Wagon> Wagons { get; set; }
        public DbSet<WagonType> WagonTypes { get; set; }
        public DbSet<User> User { get; set; }
    }
}
