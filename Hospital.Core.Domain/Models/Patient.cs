using Hospital.Core.Domain.Models.Enums;

namespace Hospital.Core.Domain.Models;

/// <summary>
/// Represents a patient in the hospital.
/// </summary>
public class Patient
{
    /// <summary>
    /// Surrogate primary key.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The patient's passport number.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// The patient's first name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The patient's surname.
    /// </summary>
    public required string Surname { get; set; }

    /// <summary>
    /// The patient's patronymic (middle name).
    /// </summary>
    public string? Patronymic { get; set; } 

    /// <summary>
    /// The patient's date of birth.
    /// </summary>
    public required DateOnly BirthDate { get; set; } 

    /// <summary>
    /// The patient's address.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// The patient's gender.
    /// </summary>
    public required Gender Gender { get; set; }

    /// <summary>
    /// The patient's blood type.
    /// </summary>
    public BloodType? BloodType { get; set; } 

    /// <summary>
    /// The patient's Rhesus factor.
    /// </summary>
    public RhesusFactor? RhesusFactor { get; set; } 

    /// <summary>
    /// The patient's phone number.
    /// </summary>
    public required string PhoneNumber { get; set; }
}
