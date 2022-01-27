using System.Collections.Generic;
using System.Linq;
using TestUserDataConnection.Models;

namespace TestUserDataConnection.Repositories
{
    public class UserTypes : IUserTypes
    {
        private readonly TestCrudContext _testCrudContext;

        public UserTypes(TestCrudContext testCrudContext)
        {
            _testCrudContext = testCrudContext;
        }
        public IEnumerable<UserType> GetAll()
        {
            return _testCrudContext.UserTypes.AsEnumerable();
        }
    }
}
