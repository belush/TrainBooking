using System.Collections.Generic;
using TrainBooking.DAL.Entities;

namespace TrainBooking.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(int id);
    }
}
