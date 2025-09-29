namespace Hospital.Core.Domain.Models;

/// <summary>
/// Represents a doctor's specialization.
/// </summary>
public class Specialization
{
    /// <summary>
    /// Surrogate key..
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The name of the specialization.
    /// </summary>
    public required string Name { get; set; }
}
