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
using Scada.services;
using Scada.repositories.implementations;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public bool RegisterUser(string username, string password)
        {
            string encryptedPassword = EncryptionUtility.EncryptValue(password);
            try
            {
                _userRepository.CreateUser(new User(username, encryptedPassword));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            return true;
        }

        public string LogInUser(string username, string password)
        {
            return AuthenticationService.LogInUser(username, password);
        }

        public bool Logout(string token)
        {
            return AuthenticationService.Logout(token);
        }

        public bool AuthenticateToken(string token)
        {
            return AuthenticationService.AuthenticateToken(token);
        }

    }
}
