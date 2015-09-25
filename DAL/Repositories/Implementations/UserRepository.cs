using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.DAL.Repositories.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(TrainBookingContext context)
            : base(context)
        {
        }

        public List<User> GetUsers()
        {
            return db.User.ToList();
        }
    }
}
