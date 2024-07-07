using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Scada.models;

namespace Scada.callbacks
{
    [ServiceContract]
    public interface ITagServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyValueChanged(TagValue inputTag);
    }
}
