using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.SharedModels.DTOs;

namespace Cinema.Services.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(UserDto dto)
        {
            var user = new User()
            {
                Username = dto.Username,
                Password = dto.Password
            };
            _userRepository.Add(user);
            _userRepository.Save();
        }

        public bool Login(string username, string password)
        {
            var userExist =
                _userRepository.GetAll().FirstOrDefault(x => x.Username == username && x.Password == password);

            if (userExist != null)
            {
                return true;
            }
            return false;
        }
    }
}
