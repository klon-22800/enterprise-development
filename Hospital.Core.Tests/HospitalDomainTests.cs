using Hospital.Core.Tests.Fixtures;
using Hospital.WebApplication.Services;
using Hospital.Core.Domain.Models;

namespace Hospital.Core.Tests;

/// <summary>
/// Contains unit tests for hospital analytics functionality using test data fixture.
/// </summary>
public class HospitalDomainTests(AnalyticsFixture fixture) : IClassFixture<AnalyticsFixture>
{
    private readonly AnalyticsService _service = fixture.Service;

    /// <summary>
    /// Tests retrieving doctors with experience of 10 years or more.
    /// </summary>
    [Fact]
    public async Task GetDoctors_WithExperienceOver10_ReturnsCorrectDoctors()
    {
        // Arrange
        List<Guid> expectedIds =
        [
            Guid.Parse("d0000000-0000-0000-0000-000000000000"),
            Guid.Parse("d0000000-0000-0000-0000-000000000001"),
            Guid.Parse("d0000000-0000-0000-0000-000000000002"),
            Guid.Parse("d0000000-0000-0000-0000-000000000003"),
            Guid.Parse("d0000000-0000-0000-0000-000000000004"),
            Guid.Parse("d0000000-0000-0000-0000-000000000005"),
            Guid.Parse("d0000000-0000-0000-0000-000000000008"),
        ];

        // Act
        var resultIds = await _service.GetDoctorsWithExperienceOver10Async();

        // Assert
        Assert.Equal(expectedIds, resultIds);
    }

    /// <summary>
    /// Tests retrieving patients of a specific doctor.
    /// </summary>
    [Theory]
    [InlineData("d0000000-0000-0000-0000-000000000000", 1)]
    [InlineData("d0000000-0000-0000-0000-000000000001", 2)]
    public async Task GetPatients_ByDoctor_ReturnsCorrectCount(string doctorGuid, int expectedCount)
    {
        // Arrange
        var doctorId = Guid.Parse(doctorGuid);

        // Act
        var patients = await _service.GetPatientsByDoctorAsync(doctorId);

        // Assert
        Assert.Equal(expectedCount, patients.Count);
    }

    /// <summary>
    /// Tests counting repeated appointments per patient in the last month.
    /// </summary>
    [Fact]
    public async Task GetRepeatedAppointments_LastMonth_ReturnsCorrectCounts()
    {
        // Arrange
        var today = new DateTime(2025, 9, 24);

        var expected = new List<(Guid PatientId, int Count)>
        {
            (Guid.Parse("c0000000-0000-0000-0000-000000000005"), 1)
        };

        // Act
        var result = await _service.GetRepeatedAppointmentsLastMonthAsync(today);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests retrieving patients over 30 years old with appointments to multiple doctors.
    /// </summary>
    [Fact]
    public async Task GetPatients_Over30WithMultipleDoctors_ReturnsCorrectPatients()
    {
        // Arrange
        var today = new DateOnly(2025, 9, 24);

        List<Guid> expectedIds =
        [
            Guid.Parse("c0000000-0000-0000-0000-000000000000"),
        ];

        // Act
        var resultPatients = await _service.GetPatientsOver30WithMultipleDoctorsAsync(today);
        var resultIds = resultPatients.ToList();

        // Assert
        Assert.Equal(expectedIds, resultIds);
    }

    /// <summary>
    /// Tests retrieving appointments in the current month for a specific cabinet.
    /// </summary>
    [Fact]
    public async Task GetAppointments_CurrentMonthByCabinet_ReturnsCorrectAppointments()
    {
        // Arrange
        var today = new DateTime(2025, 9, 24);
        var cabinetNumber = "105";

        List<Guid> expectedIds =
        [
            Guid.Parse("a0000000-0000-0000-0000-000000000005"),
        ];

        // Act
        var appointments = await _service.GetAppointmentsCurrentMonthByCabinetAsync(cabinetNumber, today);
        var resultIds = appointments.Select(a => a.Id).ToList();

        // Assert
        Assert.Equal(expectedIds, resultIds);
    }
}
