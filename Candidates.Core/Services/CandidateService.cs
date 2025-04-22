using Candidates.Core.DTOs;
using Candidates.Core.DTOs.General;
using Candidates.Core.Interfaces.IRepositories;
using Candidates.Core.Interfaces.IServices;
using Candidates.Core.Mapper;
using System.Net;

namespace Candidates.Core.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;

    public CandidateService(ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
    }

    public async Task<ResponseModel<CandidateDto>> Upsert(CandidateDto dto)
    {
        var existingId = await _candidateRepository.GetIdByEmailAsync(dto.Email);

        if (existingId != null && existingId != dto.Id)
        {
            return new("Specified email already exists in the database.", HttpStatusCode.BadRequest);
        }
        var entity = dto.MapToEntity();

        var newEntity = await _candidateRepository.Update(entity);

        return new(newEntity.MapToDto(), HttpStatusCode.OK);
    }

}
