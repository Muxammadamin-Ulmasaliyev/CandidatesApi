using Candidates.Core.DTOs;
using Candidates.Core.Entities;
using Candidates.Core.Interfaces.IRepositories;
using Candidates.Core.Mapper;
using Candidates.Core.Services;
using Moq;
using System.Net;

public class CandidateServiceTests
{
    private readonly Mock<ICandidateRepository> _mockRepo;
    private readonly CandidateService _service;

    public CandidateServiceTests()
    {
        _mockRepo = new Mock<ICandidateRepository>();
        _service = new CandidateService(_mockRepo.Object);
    }

    [Fact]
    public async Task Upsert_NewCandidate_ReturnsSuccess()
    {
        var dto = new CandidateDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Comment = "Interested in the role"
        };

        _mockRepo.Setup(r => r.GetIdByEmailAsync(dto.Email.Trim().ToLowerInvariant())).ReturnsAsync((int?)null);
        _mockRepo.Setup(r => r.Update(It.IsAny<Candidate>())).ReturnsAsync(dto.MapToEntity());

        var result = await _service.Upsert(dto);

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(dto.Email, result.Result.Email);
    }

    [Fact]
    public async Task Upsert_EmailExistsWithDifferentId_ReturnsBadRequest()
    {
        var dto = new CandidateDto
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Doe",
            Email = "john@example.com",
            Comment = "Looking for backend role"
        };

        _mockRepo.Setup(r => r.GetIdByEmailAsync(dto.Email.ToLower())).ReturnsAsync(1);

        var result = await _service.Upsert(dto);

        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
    }
}
