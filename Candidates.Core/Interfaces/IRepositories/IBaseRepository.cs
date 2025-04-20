namespace Candidates.Core.Interfaces.IRepositories;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById<Tid>(Tid id);
    Task<T> Create(T model);
    Task CreateRange(List<T> model);
    Task<T> Update(T model);
    Task Delete(T model);
    Task SaveChangeAsync();
}
