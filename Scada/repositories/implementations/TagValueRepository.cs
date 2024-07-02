using Scada.repositories.interfaces;
using Scada.repositories;
using System.Collections.Generic;
using System.Linq;
using Scada.models;

public class TagValueRepository : ITagValueRepository
{
    private readonly ScadaContext context;

    public TagValueRepository(ScadaContext context)
    {
        this.context = context;
    }

    public void AddTagValue(TagValue tagValue)
    {
        context.TagValues.Add(tagValue);
        context.SaveChanges();
    }

    public void RemoveTagValue(string tagValueId)
    {
        var tagValue = context.TagValues.Find(tagValueId);
        if (tagValue != null)
        {
            context.TagValues.Remove(tagValue);
            context.SaveChanges();
        }
    }

    public void UpdateTagValue(TagValue tagValue)
    {
        var existingTagValue = context.TagValues.Find(tagValue.Id);
        if (existingTagValue != null)
        {
            context.Entry(existingTagValue).CurrentValues.SetValues(tagValue);
            context.SaveChanges();
        }
    }

    public TagValue GetTagValue(string tagValueId)
    {
        return context.TagValues.Find(tagValueId);
    }

    public List<TagValue> GetAllTagValues()
    {
        return context.TagValues.ToList();
    }
}
