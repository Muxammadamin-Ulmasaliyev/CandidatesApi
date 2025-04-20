using System.ComponentModel.DataAnnotations;

namespace Candidates.Core.DTOs;

public class CandidateDto : BaseDto<int>
{
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please input an email in a valid format.")]
    public string Email { get; set; } = null!; // Unique

    [Phone(ErrorMessage = "Please input a valid phone number.")]
    public string? PhoneNumber { get; set; }

    public DateTime? BestTimeToCall { get; set; }

    [Url(ErrorMessage = "Please input a valid LinkedIn URL.")]
    public string? LinkedInUrl { get; set; }

    [Url(ErrorMessage = "Please input a valid GitHub URL.")]
    public string? GitHubUrl { get; set; }

    [Required(ErrorMessage = "Comment is required.")]
    public string Comment { get; set; } = null!;
}
