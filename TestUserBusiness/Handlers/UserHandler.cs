using System;
using System.Collections.Generic;
using TestUserDataConnection.Models;
using TestUserDataConnection.Repositories;

namespace TestUserBusiness.Handlers
{
    public class UserHandler : IUserHandler
    {
        IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void DeleteOne(int? id)
        {
            if ((id ?? 0) == 0)
                throw new Exception("id no valido");

            _userRepository.DeleteOne(id ?? 0);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void InsertOne(User user)
        {
            _userRepository.InsertOne(user);
        }

        public void UpdateOne(User user)
        {
            if (user.Id == 0)
                throw new Exception("id no valido");
            _userRepository.UpdateOne(user);
        }
    }
}
