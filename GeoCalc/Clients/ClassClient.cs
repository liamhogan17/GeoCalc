using BrainDump.Data.Entities;
using BrainDump.Interfaces;

namespace BrainDump.Clients;

public class ClassClient : IClassClient
{
    public Task AddClass(Class classToAdd)
    {
        throw new NotImplementedException();
    }

    public Task<List<Class>> GetAllClassesByGrade(string grade)
    {
        throw new NotImplementedException();
    }

    public Task<List<Class>> GetAllClassesBySubject(string subject)
    {
        throw new NotImplementedException();
    }

    public Task<Class> GetClass(string name, string grade, string subject)
    {
        throw new NotImplementedException();
    }

    public Task RemoveClass(Class classToRemove)
    {
        throw new NotImplementedException();
    }

    public Task UpdateClass(Class classToUpdate)
    {
        throw new NotImplementedException();
    }
}
