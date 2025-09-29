using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.DataSeeder;

namespace Hospital.Core.Tests.Fixtures;

/// <summary>
/// Fixture for Unit tests
/// </summary>
public class TestDataFixture
{
    /// <summary>
    /// Test list of Patients
    /// </summary>
    public List<Patient> Patients { get; }

    /// <summary>
    /// Test list of Doctors
    /// </summary>
    public List<Doctor> Doctors { get; }

    /// <summary>
    /// Test list of Specializations
    /// </summary>
    public List<Specialization> Specializations { get; }

    /// <summary>
    /// Test list of Appointments
    /// </summary>
    public List<Appointment> Appointments { get; }

    /// <summary>
    /// Initializes test data
    /// </summary>
    public TestDataFixture()
    {
        Specializations = DataSeeder.SeedSpecializations().ToList();
        Doctors = DataSeeder.SeedDoctors(Specializations.ToArray()).ToList();
        Patients = DataSeeder.SeedPatients().ToList();
        Appointments = DataSeeder.SeedAppointments(Patients.ToArray(), Doctors.ToArray()).ToList();
    }
}
