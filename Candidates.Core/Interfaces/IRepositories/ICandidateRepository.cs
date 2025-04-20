using Candidates.Core.Entities;

namespace Candidates.Core.Interfaces.IRepositories;

public interface ICandidateRepository
{
    Task<Candidate> Upsert(Candidate entity);
    Task<Candidate> GetById(int id);
    Task<bool> IsExists(string email);
    Task<Candidate> GetByEmailAsync(string email);
}
