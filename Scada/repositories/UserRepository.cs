using Scada.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace Scada.repositories
{
    public class UserRepository
    {
        private readonly ScadaContext _context;

        public UserRepository(ScadaContext context)
        {
            _context = context;
        }

        // Create a new user
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Read all users
        public IQueryable<User> GetAllUsers()
        {
            return _context.Users;
        }

        // Read a single user by username
        public User GetUser(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        // Update a user
        public void UpdateUser(User updatedUser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == updatedUser.Username);
            if (existingUser != null)
            {
                existingUser.Password = updatedUser.Password;
                _context.SaveChanges();
            }
        }

        // Delete a user by username
        public void DeleteUser(string username)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Username == username);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
        }

    }
}