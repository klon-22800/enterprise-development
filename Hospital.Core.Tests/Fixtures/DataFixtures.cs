using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.TestData;

namespace Hospital.Core.Tests.Fixtures;

/// <summary>
/// Fixture for Unit tests
/// </summary>
public class TestDataFixture : IDisposable
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
        var (patients, doctors, specializations, appointments) = DataGenerator.GenerateData();

        Patients = patients.ToList();
        Doctors = doctors.ToList();
        Specializations = specializations.ToList();
        Appointments = appointments.ToList();
    }

    /// <summary>
    /// Resource disposing
    /// </summary>
    public void Dispose()
    {
    }
}
