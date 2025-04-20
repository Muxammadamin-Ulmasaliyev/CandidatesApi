using Candidates.Core.Interfaces.IRepositories;
using Candidates.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly AppDbContext _dbContext;
    protected DbSet<T> DbSet => _dbContext.Set<T>();

    public BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var data = await _dbContext.Set<T>()
            .AsNoTracking()
            .ToListAsync();

        return data;
    }

    public async Task<T> GetById<Tid>(Tid id)
    {
        var data = await _dbContext.Set<T>().FindAsync(id);
        return data;
    }

    public async Task<T> Create(T model)
    {
        await _dbContext.Set<T>().AddAsync(model);
        await _dbContext.SaveChangesAsync();
        return model;
    }

    public async Task CreateRange(List<T> model)
    {
        await _dbContext.Set<T>().AddRangeAsync(model);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T> Update(T model)
    {
        var updatedEntity = _dbContext.Set<T>().Update(model).Entity;
        await _dbContext.SaveChangesAsync();
        return updatedEntity;
    }

    public async Task Delete(T model)
    {
        _dbContext.Set<T>().Remove(model);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangeAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

}
