using Scada.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.repositories.interfaces
{
    public interface ITagValueRepository
    {
        void AddTagValue(TagValue tagValue);
        void RemoveTagValue(string tagValueId);
        void UpdateTagValue(TagValue tagValue);
        TagValue GetTagValue(string tagValueId);
        List<TagValue> GetAllTagValues();


    }

}
