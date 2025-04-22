using Candidates.Api.Controllers;
using Candidates.Core.DTOs;
using Candidates.Core.DTOs.General;
using Candidates.Core.Interfaces.IServices;
using Moq;
using System.Net;

public class CandidateControllerTests
{
    private readonly Mock<ICandidateService> _mockService;
    private readonly CandidatesController _controller;

    public CandidateControllerTests()
    {
        _mockService = new Mock<ICandidateService>();
        _controller = new CandidatesController(_mockService.Object);
    }

    [Fact]
    public async Task Upsert_ValidDto_ReturnsOk()
    {
        var dto = new CandidateDto
        {
            FirstName = "Ali",
            LastName = "Smith",
            Email = "ali@sample.com",
            Comment = "Skilled developer"
        };
        var expectedResponse = new ResponseModel<CandidateDto>(dto);

        _mockService.Setup(s => s.Upsert(dto)).ReturnsAsync(expectedResponse);

        var result = await _controller.Upsert(dto);

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(dto.Email, result.Result.Email);
    }

    [Fact]
    public async Task Upsert_InvalidDto_ReturnsBadRequest()
    {
        var dto = new CandidateDto
        {
            FirstName = "John",
            LastName = "Smith",
            PhoneNumber = "+23123a321",
            Email = "john@sample.com",
            Comment = "Skilled developer"
        };

        _controller.ModelState.AddModelError("PhoneNumber", "Invalid phone number");

        var expectedResponse = new ResponseModel<CandidateDto>(dto, HttpStatusCode.BadRequest);

        _mockService.Setup(s => s.Upsert(dto)).ReturnsAsync(expectedResponse);

        var result = await _controller.Upsert(dto);

        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
    }

    [Fact]
    public async Task Upsert_InvalidDtoWithoutEmail_ReturnsBadRequest()
    {
        var dto = new CandidateDto
        {
            FirstName = "John",
            LastName = "Smith",
            PhoneNumber = "+2312321",
            Comment = "Skilled developer"
        };

        _controller.ModelState.AddModelError("Email", "Email is required.");

        var expectedResponse = new ResponseModel<CandidateDto>(dto, HttpStatusCode.BadRequest);

        _mockService.Setup(s => s.Upsert(dto)).ReturnsAsync(expectedResponse);

        var result = await _controller.Upsert(dto);

        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
    }
}
