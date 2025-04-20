using Candidates.Core.DTOs;
using Candidates.Core.DTOs.General;
using Candidates.Core.Entities;

namespace Candidates.Core.Interfaces.IServices;

public interface ICandidateService
{
    Task<ResponseModel<CandidateDto>> Upsert(CandidateDto dto);

}
