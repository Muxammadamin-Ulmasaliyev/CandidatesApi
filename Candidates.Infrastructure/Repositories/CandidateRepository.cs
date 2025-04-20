using Candidates.Core.Entities;
using Candidates.Core.Interfaces.IRepositories;
using Candidates.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Infrastructure.Repositories;

public class CandidateRepository : ICandidateRepository
{
    private readonly AppDbContext _dbContext;
    public CandidateRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Candidate> GetByEmailAsync(string email)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        return await _dbContext.Candidates.AsNoTracking().FirstOrDefaultAsync(x => x.Email == normalizedEmail);
    }

    public async Task<Candidate> GetById(int id)
    {
        return await _dbContext.Candidates.FindAsync(id);
    }

    public async Task<bool> IsExists(string email)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        return await _dbContext.Candidates.AnyAsync(x => x.Email == normalizedEmail);
    }

    public async Task<Candidate> Upsert(Candidate entity)
    {
        entity.LastModifiedAt = DateTime.Now;
        var updatedEntity = _dbContext.Candidates.Update(entity).Entity;
        await _dbContext.SaveChangesAsync();
        return updatedEntity;
    }
}
