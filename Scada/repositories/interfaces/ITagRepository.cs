using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.repositories.interfaces
{
    public interface ITagRepository
    {
        void AddTag(Tag tag);
        void RemoveTag(string tagId);
        void UpdateTag(Tag tag);
        Tag GetTag(string tagId);
        List<Tag> GetAllTags();
    }

}
