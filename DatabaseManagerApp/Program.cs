using System;
using DatabaseManagerApp.CoreServiceReference;

namespace DatabaseManagerApp
{
    internal class Program
    {
        private static UserServiceClient userServiceClient = new UserServiceClient();
        private static string currentToken = null;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SCADA System - User Management");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Logout");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        LoginUser();
                        break;
                    case "3":
                        LogoutUser();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void RegisterUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            bool result = userServiceClient.RegisterUser(username, password);

            if (result)
            {
                Console.WriteLine("User registered successfully.");
            }
            else
            {
                Console.WriteLine("User registration failed.");
            }
        }

        private static void LoginUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string token = userServiceClient.LogInUser(username, password);

            if (token != "Login failed")
            {
                currentToken = token;
                Console.WriteLine("Login successful. Token: " + token);
            }
            else
            {
                Console.WriteLine("Login failed.");
            }
        }

        private static void LogoutUser()
        {
            if (currentToken == null)
            {
                Console.WriteLine("No user is currently logged in.");
                return;
            }

            bool result = userServiceClient.Logout(currentToken);

            if (result)
            {
                currentToken = null;
                Console.WriteLine("Logout successful.");
            }
            else
            {
                Console.WriteLine("Logout failed.");
            }
        }
    }
}
