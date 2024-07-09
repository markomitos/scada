using System;
using System.ServiceModel;

namespace AlarmDisplayApp
{
    public class Callback : AlarmValueServiceReference.IAlarmValueServiceCallback
    {
        public void NotifyAlarmTriggered(string message)
        {
            Console.WriteLine(message);
        }
    }

    internal class Program
    {
        public static AlarmValueServiceReference.AlarmValueServiceClient alarmServiceClient;
        static void Main(string[] args)
        {
            Console.WriteLine("Listening to triggered alarms: \n");
            alarmServiceClient = new AlarmValueServiceReference.AlarmValueServiceClient(new InstanceContext(new Callback()));
            alarmServiceClient.SubOnAlarmDisplay();
            Console.ReadKey();
            alarmServiceClient.Close();
        }
    }
}
