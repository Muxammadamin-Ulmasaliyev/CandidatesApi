using System.ComponentModel.DataAnnotations;

namespace Candidates.Core.Entities;

/// <summary>
/// A generic base class entities.
/// Provides common metadata fields such as Id, CreatedAt, and LastModifiedAt.
/// </summary>
/// <typeparam name="T">The type of the identifier (e.g., Guid, int).</typeparam>
public class BaseEntity<T>
{
    [Key]
    public T Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
