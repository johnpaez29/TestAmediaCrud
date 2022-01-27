using System;
using System.Collections.Generic;
using System.Linq;
using TestUserDataConnection.Models;

namespace TestUserDataConnection.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TestCrudContext _testCrudContext;

        public UserRepository(TestCrudContext testCrudContext)
        {
            _testCrudContext = testCrudContext;
        }
        public void DeleteOne(int id)
        {
            User user = _testCrudContext.Users.Find(id);
            if (user == null)
                throw new Exception("Usuario no encontrado");
            _testCrudContext.Users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _testCrudContext.Users.AsEnumerable();
        }

        public User GetById(int id)
        {
            User user = _testCrudContext.Users.Find(id);
            if (user == null)
                throw new Exception("Usuario no encontrado");
            return user;
        }

        public void InsertOne(User user)
        {
            _testCrudContext.Users.Add(user);
            _testCrudContext.SaveChanges();
        }

        public void UpdateOne(User user)
        {
            _testCrudContext.Users.Update(user);

            _testCrudContext.SaveChanges();
        }
    }
}
