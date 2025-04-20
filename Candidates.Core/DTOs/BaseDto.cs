namespace Candidates.Core.DTOs;


/// <summary>
/// A generic base class for Data Transfer Objects (DTOs).
/// Provides common metadata fields such as Id, CreatedAt, and LastModifiedAt.
/// </summary>
/// <typeparam name="T">The type of the identifier (e.g., Guid, int).</typeparam>
public class BaseDto<T>
{
    public T? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
