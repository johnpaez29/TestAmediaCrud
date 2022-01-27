using System.Collections.Generic;
using TestUserDataConnection.Models;

namespace TestUserDataConnection.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        void InsertOne(User user);

        void UpdateOne(User user);

        void DeleteOne(int id);
    }
}
