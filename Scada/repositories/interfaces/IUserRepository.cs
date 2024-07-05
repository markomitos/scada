using Scada.models;
using System.Collections.Generic;
using System.Linq;

namespace Scada.repositories.interfaces
{
    interface IUserRepository
    {
        void CreateUser(User user);
        void DeleteUser(string username);
        void UpdateUser(User updatedUser);
        User GetUser(string username);
        List<User> GetAllUsers();
    }
}