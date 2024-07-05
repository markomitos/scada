using Scada.models;
using Scada.repositories;
using Scada.utilities;
using System.Collections.Generic;
using System;

namespace Scada.services
{
    public class AuthenticationService
    {
        private static Dictionary<string, User> authenticatedUsers = new Dictionary<string, User>();

        public static string LogInUser(string username, string password)
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

        public static bool Logout(string token)
        {
            return authenticatedUsers.Remove(token);
        }

        public static bool AuthenticateToken(string token)
        {
            return authenticatedUsers.ContainsKey(token);
        }
    }
}