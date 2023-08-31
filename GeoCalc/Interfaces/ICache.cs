
namespace GeoCalc.Interfaces;

public interface ICache<T>
{
    public Task Add(T nameOfClass);
    public Task Remove(T nameOfClass);
    public Task Clear();
    public Task<T> Get(T nameOfClass);
    public Task<List<T>> GetAll();
    public Task Update(T nameOfClass);
}