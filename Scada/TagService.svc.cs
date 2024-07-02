using Scada.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Scada.models;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TagService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TagService.svc or TagService.svc.cs at the Solution Explorer and start debugging.
    public class TagService : ITagService
    {
        private readonly TagRepository _tagRepository;

        public TagService()
        {
            _tagRepository = new TagRepository(new ScadaContext());
        }

        public bool AddTag(Tag tag)
        {
            try
            {
                _tagRepository.AddTag(tag);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveTag(string tagName)
        {
            try
            {
                _tagRepository.RemoveTag(tagName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTag(Tag tag)
        {
            try
            {
                _tagRepository.UpdateTag(tag);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Tag GetTag(string tagName)
        {
            return _tagRepository.GetTag(tagName);
        }

        public List<Tag> GetAllTags()
        {
            return _tagRepository.GetAllTags();
        }
        public bool IsTagNameUnique(string tagName)
        {
            return _tagRepository.GetTag(tagName) == null;
        }
    }
}
