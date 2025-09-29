namespace Hospital.Core.Domain.Models;

/// <summary>
/// Represents a doctor in the hospital.
/// </summary>
public class Doctor
{
    /// <summary>
    /// Surrogate key.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The doctor's passport number.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// The doctor's first name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The doctor's surname.
    /// </summary>
    public required string Surname { get; set; }

    /// <summary>
    /// The doctor's patronymic.
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// The doctor's date of birth.
    /// </summary>
    public required DateOnly BirthDate { get; set; }

    /// <summary>
    /// The doctor's specialization.
    /// </summary>
    public required Specialization Specialization { get; set; }

    /// <summary>
    /// The doctor's years of experience.
    /// </summary>
    public required int Expirience { get; set; }
}