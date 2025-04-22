using Candidates.Core.Entities;
using Candidates.Core.Interfaces.IRepositories;
using Candidates.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Infrastructure.Repositories;

public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
{
    public CandidateRepository(AppDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<int?> GetIdByEmailAsync(string email)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        return await _dbContext.Candidates
            .Where(c => c.Email == email)
            .Select(c => (int?)c.Id)
            .FirstOrDefaultAsync();
    }

}
