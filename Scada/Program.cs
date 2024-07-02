using System.ServiceModel;
using System;

namespace Scada
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svc = new ServiceHost(typeof(UserService));
            svc.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            svc.Close();
        }

    }
}