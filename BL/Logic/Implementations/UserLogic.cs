using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.BL.Logic.Interfaces;
using TrainBooking.DAL;
using TrainBooking.DAL.Entities;
using TrainBooking.DAL.Repositories.Implementations;
using TrainBooking.DAL.Repositories.Interfaces;

namespace TrainBooking.BL.Logic.Implementations
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
