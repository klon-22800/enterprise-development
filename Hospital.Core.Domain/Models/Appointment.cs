namespace Hospital.Core.Domain.Models;

/// <summary>
/// Represents a medical appointment between a patient and a doctor.
/// </summary>
public class Appointment
{
    /// <summary>
    /// Surrogate key.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The date and time of the appointment.
    /// </summary>
    public required DateTime AppointmentTime { get; set; } 

    /// <summary>
    /// The number of the cabinet where the appointment will take place.
    /// </summary>
    public required string CabinetNumber { get; set; }

    /// <summary>
    /// Indicates whether the appointment is a recurring one.
    /// </summary>
    public bool IsRepeated { get; set; } 

    /// <summary>
    /// The patient attending the appointment.
    /// </summary>
    public required Patient Patient { get; set; }

    /// <summary>
    /// The doctor who will see the patient.
    /// </summary>
    public required Doctor Doctor { get; set; }
}
