using Candidates.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    #region DbSets

    public DbSet<Candidate> Candidates { get; set; }


    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        AppDbContextConfiguration.Configure(modelBuilder);
        AppDbContextConfiguration.SeedData(modelBuilder);
    }

}
