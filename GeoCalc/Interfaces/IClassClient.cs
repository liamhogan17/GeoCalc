
using BrainDump.Data.Entities;

namespace BrainDump.Interfaces;

public interface IClassClient
{
    public Task<List<Class>> GetAllClassesByGrade(string grade);
    public Task<List<Class>> GetAllClassesBySubject(string subject);
    public Task<Class> GetClass(string name, string grade, string subject);
    public Task AddClass(Class classToAdd);
    public Task RemoveClass(Class classToRemove);
    public Task UpdateClass(Class classToUpdate);
}