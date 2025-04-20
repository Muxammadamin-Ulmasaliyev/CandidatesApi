using Candidates.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Infrastructure.Data;

public class AppDbContextConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<Candidate>()
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("SYSDATETIME()");

        modelBuilder.Entity<Candidate>()
            .Property(e => e.LastModifiedAt)
            .HasDefaultValueSql("SYSDATETIME()");
    }

    public static void SeedData(ModelBuilder modelBuilder)
    {

    }
}
