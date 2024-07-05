using System.ServiceModel;
using System;

namespace Scada
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost userService = new ServiceHost(typeof(UserService));
            ServiceHost tagService = new ServiceHost(typeof(TagService));
            userService.Open();
            tagService.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            userService.Close();
            tagService.Close();
        }

    }
}