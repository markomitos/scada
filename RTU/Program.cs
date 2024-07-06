using RTU.TagServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RTU
{
    public class TagProcessingCallback : ITagServiceCallback
    {
        public void NotifyAnalogInputChanged(AnalogInputTag inputTag)
        {
            
        }

        public void NotifyDigitalInputChanged(DigitalInputTag inputTag)
        {
 
        }
    }

    internal class Program
    {
        
        private static TagServiceClient tagServiceClient = new TagServiceClient(new InstanceContext(new TagProcessingCallback()));

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
                string message = value.ToString();

                byte[] hashValue;
                byte[] signature = rtu.SignMessage(message, out hashValue);

                string hashValueBase64 = Convert.ToBase64String(hashValue);
                string signatureBase64 = Convert.ToBase64String(signature);

                tagServiceClient.setRTUValue(driverAddress, value, signatureBase64, hashValueBase64);
                Console.WriteLine("Value: " + value);

                double retrievedValue = tagServiceClient.getRTUValue(driverAddress);
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
