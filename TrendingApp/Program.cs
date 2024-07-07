using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static Scada.Program;
using TrendingApp.TagServiceReference;

namespace Scada
{
    
    public class TagProcessingCallback : ITagServiceCallback
    {
        public void NotifyValueChanged(TagValue inputTag)
        {
            Console.WriteLine("Input tag with name: " + inputTag.TagName + ", has value: " + inputTag.Value + ", at: " + inputTag.TimeStamp );
        }
    }

    public class Program
    {


        static void Main(string[] args)
        {
            using (TagServiceClient
                   client = new TagServiceClient(new InstanceContext(new TagProcessingCallback())))
            {
                client.InitTrending(new Guid());
                Console.ReadLine();
            }
        }
    }
}
