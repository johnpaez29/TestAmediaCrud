using System.Collections.Generic;
using TestUserDataConnection.Models;

namespace TestUserDataConnection.Repositories
{
    public interface IUserTypes
    {
        IEnumerable<UserType> GetAll();
    }
}
