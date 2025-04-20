using Candidates.Core.DTOs;
using Candidates.Core.Entities;
using System.Runtime.CompilerServices;

namespace Candidates.Core.Mapper;

public static class CustomMapper
{

    public static Candidate MapToEntity(this CandidateDto dto)
    {
        return new Candidate
        {
            Id = dto.Id,
            CreatedAt = dto.CreatedAt,
            LastModifiedAt = dto.LastModifiedAt,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email.Trim().ToLowerInvariant(),
            BestTimeToCall = dto.BestTimeToCall,
            LinkedInUrl = dto.LinkedInUrl,
            GitHubUrl = dto.GitHubUrl,
            Comment = dto.Comment
        };
    }

    public static CandidateDto MapToDto(this Candidate entity)
    {
        return new CandidateDto
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            LastModifiedAt = entity.LastModifiedAt,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email,
            BestTimeToCall = entity.BestTimeToCall,
            LinkedInUrl = entity.LinkedInUrl,
            GitHubUrl = entity.GitHubUrl,
            Comment = entity.Comment
        };
    }
}
