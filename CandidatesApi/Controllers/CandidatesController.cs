using Candidates.Core.DTOs;
using Candidates.Core.DTOs.General;
using Candidates.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Candidates.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<ResponseModel<CandidateDto>> Upsert([FromBody] CandidateDto dto)
        {
            return await _candidateService.Upsert(dto);
        }
    }
}
