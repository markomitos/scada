using Scada.repositories.interfaces;
using Scada.repositories;
using System.Collections.Generic;
using System.Linq;
using Scada.models;

public class TagRepository : ITagRepository
{
    private readonly ScadaContext context;

    public TagRepository(ScadaContext context)
    {
        this.context = context;
    }

    public void AddTag(Tag tag)
    {
        context.Tags.Add(tag);
        context.SaveChanges();
    }

    public void RemoveTag(string tagId)
    {
        var tag = context.Tags.Find(tagId);
        if (tag != null)
        {
            context.Tags.Remove(tag);
            context.SaveChanges();
        }
    }

    public void UpdateTag(Tag tag)
    {
        var existingTag = context.Tags.Find(tag.Name);
        if (existingTag != null)
        {
            context.Entry(existingTag).CurrentValues.SetValues(tag);
            context.SaveChanges();
        }
    }

    public Tag GetTag(string tagId)
    {
        return context.Tags.Find(tagId);
    }

    public List<Tag> GetAllTags()
    {
        return context.Tags.ToList();
    }
}
