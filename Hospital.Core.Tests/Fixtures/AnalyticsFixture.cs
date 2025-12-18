using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.WebApplication.Services;
using Moq;

namespace Hospital.Core.Tests.Fixtures;

/// <summary>Fixture for testing AnalyticsService.</summary>
public class AnalyticsFixture
{
    /// <summary>The analytics service under test.</summary>
    public AnalyticsService Service { get; }

    /// <summary>Test data used in the fixture.</summary>
    public TestDataFixture Data { get; }

    /// <summary>Initializes the fixture with mocked repositories and test data.</summary>
    public AnalyticsFixture()
    {
        Data = new TestDataFixture();

        var specializationRepoMock = new Mock<IRepository<Specialization>>();
        var doctorRepoMock = new Mock<IDoctorRepository>();
        var patientRepoMock = new Mock<IRepository<Patient>>();
        var appointmentRepoMock = new Mock<IAppointmentRepository>();

        specializationRepoMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(Data.Specializations.ToList());

        doctorRepoMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(Data.Doctors.ToList());

        patientRepoMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(Data.Patients.ToList());

        appointmentRepoMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(Data.Appointments.ToList());

        Service = new AnalyticsService(
            doctorRepoMock.Object,
            patientRepoMock.Object,
            appointmentRepoMock.Object
        );
    }
}