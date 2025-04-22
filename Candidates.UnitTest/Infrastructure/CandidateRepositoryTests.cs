using Candidates.Core.Entities;
using Candidates.Infrastructure.Data;
using Candidates.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class CandidateRepositoryTests
{
    private AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique for each test
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task GetIdByEmailAsync_ReturnsCorrectId()
    {
        var context = GetInMemoryDbContext();
        var repo = new CandidateRepository(context);

        var candidate = new Candidate
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Comment = "Ready to work"
        };

        context.Candidates.Add(candidate);
        await context.SaveChangesAsync();

        var id = await repo.GetIdByEmailAsync("john@example.com");

        Assert.NotNull(id);
        Assert.Equal(candidate.Id, id);
    }

    [Fact]
    public async Task Update_AddsNewCandidate_WhenIdIsZero()
    {
        var context = GetInMemoryDbContext();
        var repo = new CandidateRepository(context);

        var candidate = new Candidate
        {
            FirstName = "New",
            LastName = "Person",
            Email = "new@person.com",
            Comment = "New hire"
        };

        var result = await repo.Update(candidate);

        Assert.NotEqual(0, result.Id);
        Assert.Equal("new@person.com", result.Email);
    }

    [Fact]
    public async Task Update_UpdatesExistingCandidate()
    {
        var context = GetInMemoryDbContext();
        var repo = new CandidateRepository(context);

        var candidate = new Candidate
        {
            FirstName = "Jane",
            LastName = "Doe",
            Email = "jane@update.com",
            Comment = "Initial comment"
        };

        context.Candidates.Add(candidate);
        await context.SaveChangesAsync();

        candidate.Comment = "Updated comment";

        var updated = await repo.Update(candidate);

        Assert.Equal("Updated comment", updated.Comment);
    }
}
