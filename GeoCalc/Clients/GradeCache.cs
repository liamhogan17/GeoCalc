using BrainDump.Data.Entities;
using BrainDump.Interfaces;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using System.Diagnostics;

namespace BrainDump.Clients
{
    public class GradeCache : ICache<WholeGrade>
    {
        private readonly Dictionary<string, WholeGrade> _cache;
        public GradeCache()
        {
            _cache ??= new Dictionary<string, WholeGrade>();
        }
        public Task Add(WholeGrade grade)
        {
            return Task.FromResult(_cache[grade.Grade] = grade);
        }

        public Task Clear()
        {
            return Task.FromResult(_cache.Clear);
        }

        public Task<WholeGrade> Get(WholeGrade grade)
        {
            return Task.FromResult(_cache[grade.Grade]);
        }

        public Task<List<WholeGrade>> GetAll()
        {
            return Task.FromResult(_cache.Values.ToList());
        }

        public Task Remove(WholeGrade grade)
        {
            return Task.FromResult(_cache.Remove(grade.Grade));
        }

        public Task Update(WholeGrade grade)
        {
            if (_cache.ContainsKey(grade.Grade))
            {
                Remove(grade);
                Add(grade);
            }
            return Task.CompletedTask;
        }
    }
}
