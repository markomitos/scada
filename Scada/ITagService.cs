using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Scada.models;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITagService" in both code and config file together.
    [ServiceContract]
    public interface ITagService
    {
        [OperationContract]
        bool AddTag(Tag tag);

        [OperationContract]
        bool RemoveTag(string tagName);

        [OperationContract]
        bool UpdateTag(Tag tag);

        [OperationContract]
        Tag GetTag(string tagName);

        [OperationContract]
        List<Tag> GetAllTags();

        [OperationContract]
        bool IsTagNameUnique(string tagName);
    }
}
