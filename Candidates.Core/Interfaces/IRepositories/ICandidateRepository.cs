using Candidates.Core.Entities;

namespace Candidates.Core.Interfaces.IRepositories;

public interface ICandidateRepository : IBaseRepository<Candidate>
{
    Task<int?> GetIdByEmailAsync(string email);
}
