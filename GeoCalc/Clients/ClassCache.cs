using BrainDump.Data.Entities;
using BrainDump.Interfaces;

namespace BrainDump.Clients;

public class ClassCache : ICache<Class>
{
    private readonly Dictionary<string, Class> _cache;
    public ClassCache()
    {
        _cache ??= new Dictionary<string, Class>();
    }
    public Task Add(Class nameOfClass)
    {
        return Task.FromResult(_cache[nameOfClass.Name] = nameOfClass);
    }

    public Task Clear()
    {
        return Task.FromResult(_cache.Clear);
    }

    public Task<Class> Get(Class nameOfClass)
    {
        return Task.FromResult(_cache[nameOfClass.Name]);
    }

    public Task<List<Class>> GetAll()
    {
        return Task.FromResult(_cache.Values.ToList());
    }

    public Task Remove(Class nameOfClass)
    {
        return Task.FromResult(_cache.Remove(nameOfClass.Name));
    }

    public Task Update(Class nameOfClass)
    {
        if (_cache.ContainsKey(nameOfClass.Name))
        {
            Remove(nameOfClass);
            Add(nameOfClass);
        }
        return Task.CompletedTask;
    }
}
