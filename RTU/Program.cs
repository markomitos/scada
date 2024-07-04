using RTU.TagServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTU
{
    internal class Program
    {
        
        private static TagServiceClient tagServiceClient = new TagServiceClient();

        static void Main(string[] args)
        {
            Console.Write("Enter RTU Driver Address: ");
            string driverAddress = Console.ReadLine();

            Console.Write("Enter lower limit for values: ");
            double lowerLimit = int.Parse(Console.ReadLine());

            Console.Write("Enter upper limit for values: ");
            double upperLimit = int.Parse(Console.ReadLine());

            RealTimeUnit rtu = new RealTimeUnit(driverAddress, lowerLimit, upperLimit);
            
            while (true)
            {
                double value = rtu.GenerateValue();
                tagServiceClient.setRTUValue(driverAddress, value);
                Console.WriteLine("Value: " + value);

                tagServiceClient.getRTUValue(driverAddress);
                Console.WriteLine("GETValue: " + value);
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
