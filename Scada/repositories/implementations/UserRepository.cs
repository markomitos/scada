using Scada.models;
using Scada.repositories.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Scada.repositories
{
    public class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            using (var context = new ScadaContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void DeleteUser(string username)
        {
            using (var context = new ScadaContext())
            {
                var userToDelete = context.Users.FirstOrDefault(u => u.Username == username);
                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateUser(User updatedUser)
        {
            using (var context = new ScadaContext())
            {
                var existingUser = context.Users.FirstOrDefault(u => u.Username == updatedUser.Username);
                if (existingUser != null)
                {
                    context.Entry(existingUser).CurrentValues.SetValues(updatedUser);
                    context.SaveChanges();
                }
            }
        }

        public User GetUser(string username)
        {
            using (var context = new ScadaContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username);
            }
        }

        public List<User> GetAllUsers()
        {
            using (var context = new ScadaContext())
            {
                return context.Users.ToList();
            }
        }
    }
}