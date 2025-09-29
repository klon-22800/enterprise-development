using Hospital.Core.Tests.Fixtures;

namespace Hospital.Core.Tests;

/// <summary>
/// Contains unit tests for hospital core functionality using test data fixture.
/// </summary>
public class HospitalDomainTests(TestDataFixture fixture) : IClassFixture<TestDataFixture>
{
    private readonly TestDataFixture _fixture = fixture;

    /// <summary>
    /// Tests retrieving doctors with experience of 10 years or more.
    /// </summary>
    [Fact]
    public void GetDoctors_WithExperienceOver10_ReturnsCorrectDoctors()
    {
        List<Guid> expectedIds = [
            Guid.Parse("d0000000-0000-0000-0000-000000000000"),
            Guid.Parse("d0000000-0000-0000-0000-000000000001"),
            Guid.Parse("d0000000-0000-0000-0000-000000000002"),
            Guid.Parse("d0000000-0000-0000-0000-000000000003"),
            Guid.Parse("d0000000-0000-0000-0000-000000000004"),
            Guid.Parse("d0000000-0000-0000-0000-000000000005"),
            Guid.Parse("d0000000-0000-0000-0000-000000000008"),
        ];

        var resultIds = _fixture.Doctors
            .Where(d => d.Expirience >= 10)
            .OrderBy(d => d.Id)
            .Select(d => d.Id)
            .ToList();

        Assert.Equal(expectedIds, resultIds);
    }

    /// <summary>
    /// Tests retrieving patients of a specific doctor.
    /// </summary>
    [Theory]
    [InlineData("d0000000-0000-0000-0000-000000000000", 1)]
    [InlineData("d0000000-0000-0000-0000-000000000001", 2)]
    public void GetPatients_ByDoctor_ReturnsCorrectCount(string doctorGuid, int expectedCount)
    {
        var doctorId = Guid.Parse(doctorGuid);

        var patients = _fixture.Appointments
            .Where(a => a.Doctor.Id == doctorId)
            .Select(a => a.Patient)
            .OrderBy(p => p.Surname)
            .ThenBy(p => p.Name)
            .ThenBy(p => p.Patronymic)
            .ToList();

        Assert.Equal(expectedCount, patients.Count);
    }

    /// <summary>
    /// Tests counting repeated appointments per patient in the last month.
    /// </summary>
    [Fact]
    public void GetRepeatedAppointments_LastMonth_ReturnsCorrectCounts()
    {
        var today = new DateTime(2025, 9, 24);
        var monthAgo = today.AddMonths(-1);

        var expected = new[]
        {
            new { PatientId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), Count = 1 }
        };

        var result = _fixture.Appointments
            .Where(a => a.IsRepeated && a.AppointmentTime >= monthAgo && a.AppointmentTime <= today)
            .GroupBy(a => a.Patient.Id)
            .Select(g => new { PatientId = g.Key, Count = g.Count() })
            .OrderBy(x => x.PatientId)
            .ToArray();

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests retrieving patients over 30 years old with appointments to multiple doctors.
    /// </summary>
    [Fact]
    public void GetPatients_Over30WithMultipleDoctors_ReturnsCorrectPatients()
    {
        var today = new DateOnly(2025, 9, 24);
        var ageLimit = today.AddYears(-30);

        List<Guid> expectedIds = [
            Guid.Parse("c0000000-0000-0000-0000-000000000000"),
        ];

        var resultIds = _fixture.Appointments
            .Where(a => a.Patient.BirthDate <= ageLimit)
            .GroupBy(a => a.Patient.Id)
            .Where(g => g.Select(a => a.Doctor.Id).Distinct().Count() > 1)
            .Select(g => g.Key)
            .Join(
                _fixture.Patients,
                patientId => patientId,
                patient => patient.Id,
                (id, patient) => new { patient.Id, patient.BirthDate })
            .OrderBy(p => p.BirthDate)
            .Select(p => p.Id)
            .ToList();

        Assert.Equal(expectedIds, resultIds);
    }

    /// <summary>
    /// Tests retrieving appointments in the current month for a specific cabinet.
    /// </summary>
    [Fact]
    public void GetAppointments_CurrentMonthByCabinet_ReturnsCorrectAppointments()
    {
        var today = new DateTime(2025, 9, 24);
        var cabinetNumber = "105";

        List<Guid> expectedIds = [
            Guid.Parse("a0000000-0000-0000-0000-000000000005"),
        ];

        var resultIds = _fixture.Appointments
            .Where(a => a.OfficeNumber == cabinetNumber
                        && a.AppointmentTime.Year == today.Year
                        && a.AppointmentTime.Month == today.Month)
            .OrderBy(a => a.AppointmentTime)
            .Select(a => a.Id)
            .ToList();

        Assert.Equal(expectedIds, resultIds);
    }
}
