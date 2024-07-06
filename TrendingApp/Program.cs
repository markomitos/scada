using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Scada.Program;
using TrendingApp.TagServiceReference;

namespace Scada
{
    
    public class TagProcessingCallback : ITagServiceCallback
    {
        public void NotifyAnalogInputChanged(AnalogInputTag inputTag)
        {
            Console.WriteLine("Input tag with name: " + inputTag.Name );
        }

        public void NotifyDigitalInputChanged(DigitalInputTag inputTag)
        {
            Console.WriteLine("Input tag with name: " + inputTag.Name);
        }
    }

    public class Program
    {


        static void Main(string[] args)
        {
        }
    }
}
