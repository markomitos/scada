using Scada.models;
using Scada.repositories;
using Scada.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Scada.interfaces;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private static Dictionary<string, User> authenticatedUsers = new Dictionary<string, User>();
        public bool RegisterUser(string username, string password)
        {
            string encryptedPassword = EncryptionUtility.EncryptValue(password);
            User user = new User(username, encryptedPassword);
            using (var db = new ScadaContext())
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;

                }
            }
            return true;

        }

        public string LogInUser(string username, string password)
        {
            using (var db = new ScadaContext())
            {
                foreach (var user in db.Users)
                {
                    if (username == user.Username &&
                        EncryptionUtility.ValidateEncryptedData(password, user.Password))
                    {
                        string token = TokenGenerator.GenerateToken(username);
                        authenticatedUsers.Add(token, user);
                        return token;
                    }
                }
            }
            return "Login failed";
        }

        public bool Logout(string token)
        {
            return authenticatedUsers.Remove(token);
        }

    }
}
