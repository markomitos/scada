using System;
using Scada.repositories.interfaces;
using Scada.repositories;
using System.Collections.Generic;
using System.Linq;
using Scada.models;
using ValueType = Scada.models.ValueType;

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

    public List<TagValue> GetAllTagValuesWithinTimeFrame(DateTime startTime, DateTime endTime)
    {
        using (var context = new ScadaContext())
        {
            return context.TagValues.ToList().Where(tag => tag.TimeStamp >= startTime && tag.TimeStamp <= endTime)
                .OrderBy(tag => tag.TimeStamp)
                .ToList();
        }
    }

    public List<TagValue> GetAllLatestAnalogTagValues()
    {
        using (var context = new ScadaContext())
        {
            return context.TagValues.ToList().Where(tag => tag.ValueType.Equals(ValueType.ANALOG))
                    .GroupBy(tag => tag.TagName)
                    .Select(g => g.OrderByDescending(tag => tag.TimeStamp).FirstOrDefault())
                    .ToList();
        }
    }

    public List<TagValue> GetAllLatestDigitalTagValues()
    {
        using (var context = new ScadaContext())
        {
            return context.TagValues.ToList().Where(tag => tag.ValueType.Equals(ValueType.DIGITAL) )
                .GroupBy(tag => tag.TagName)
                .Select(g => g.OrderByDescending(tag => tag.TimeStamp).FirstOrDefault())
                .ToList();
        }
    }

    public List<TagValue> GetTagValues(string tagValueId)
    {
        using (var context = new ScadaContext())
        {
            return context.TagValues.Where(tag => tag.TagName.Equals(tagValueId)).OrderBy(tag => tag.Value).ToList();
        }
    }
}
