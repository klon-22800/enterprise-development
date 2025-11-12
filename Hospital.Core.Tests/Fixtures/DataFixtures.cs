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
    public Patient[] Patients { get; }

    /// <summary>
    /// Test list of Doctors
    /// </summary>
    public Doctor[] Doctors { get; }

    /// <summary>
    /// Test list of Specializations
    /// </summary>
    public Specialization[] Specializations { get; }

    /// <summary>
    /// Test list of Appointments
    /// </summary>
    public Appointment[] Appointments { get; }

    /// <summary>
    /// Initializes test data
    /// </summary>
    public TestDataFixture()
    {
        Specializations = DataSeeder.SeedSpecializations();
        Doctors = DataSeeder.SeedDoctors(Specializations);
        Patients = DataSeeder.SeedPatients();
        Appointments = DataSeeder.SeedAppointments(Patients, Doctors);
    }
}
