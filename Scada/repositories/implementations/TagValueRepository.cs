using Scada.repositories.interfaces;
using Scada.repositories;
using System.Collections.Generic;
using System.Linq;
using Scada.models;

public class TagValueRepository : ITagValueRepository
{
    public void AddTagValue(TagValue tagValue)
    {
        using (var context = new ScadaContext())
        {
            context.TagValues.Add(tagValue);
            context.SaveChanges();
        }
    }

    public void RemoveTagValue(string tagValueId)
    {
        using (var context = new ScadaContext())
        {
            var tagValue = context.TagValues.Find(tagValueId);
            if (tagValue != null)
            {
                context.TagValues.Remove(tagValue);
                context.SaveChanges();
            }
        }
    }

    public void UpdateTagValue(TagValue tagValue)
    {
        using (var context = new ScadaContext())
        {
            var existingTagValue = context.TagValues.Find(tagValue.Id);
            if (existingTagValue != null)
            {
                context.Entry(existingTagValue).CurrentValues.SetValues(tagValue);
                context.SaveChanges();
            }
        }
    }

    public TagValue GetTagValue(string tagValueId)
    {
        using (var context = new ScadaContext())
        {
            return context.TagValues.Find(tagValueId);
        }
    }

    public List<TagValue> GetAllTagValues()
    {
        using (var context = new ScadaContext())
        {
            return context.TagValues.ToList();
        }
    }

    public TagValue GetLastTagValue(string tagName)
    {
        using (var context = new ScadaContext())
        {
            return context.TagValues
                .Where(tv => tv.TagName == tagName)
                .OrderByDescending(tv => tv.TimeStamp)
                .FirstOrDefault();
        }
    }
}
