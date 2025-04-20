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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity<int> && (
            e.State == EntityState.Modified || e.State == EntityState.Added));

        foreach (var entry in entries)
        {
            var entity = (BaseEntity<int>)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.Now;
            }

            entity.LastModifiedAt = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        AppDbContextConfiguration.Configure(modelBuilder);
        AppDbContextConfiguration.SeedData(modelBuilder);
    }

}
