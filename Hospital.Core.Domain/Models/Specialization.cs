namespace Hospital.Core.Domain.Models;

/// <summary>
/// Represents a doctor's specialization.
/// </summary>
public class Specialization
{
    /// <summary>
    /// The unique identifier of the specialization.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the specialization.
    /// </summary>
    public required string Name { get; set; }
}