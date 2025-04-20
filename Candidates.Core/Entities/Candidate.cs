using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candidates.Core.Entities;

[Table(name: "Candidates")]
public class Candidate : BaseEntity<int>
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!; // Unique
    public string? PhoneNumber { get; set; }
    public DateTime? BestTimeToCall { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GitHubUrl { get; set; }
    [Required]
    public string Comment { get; set; } = null!;
}
