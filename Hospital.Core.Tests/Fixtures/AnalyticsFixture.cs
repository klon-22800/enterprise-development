using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.WebApplication.Services;
using Moq;

namespace Hospital.Core.Tests.Fixtures;


public class AnalyticsFixture
{

    public AnalyticsService Service { get; }


    public TestDataFixture Data { get; }


    public AnalyticsFixture()
    {
        Data = new TestDataFixture();

        var specializationRepoMock = new Mock<IRepository<Specialization>>();
        var doctorRepoMock = new Mock<IRepository<Doctor>>();
        var patientRepoMock = new Mock<IRepository<Patient>>();
        var appointmentRepoMock = new Mock<IRepository<Appointment>>();

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
            specializationRepoMock.Object,
            doctorRepoMock.Object,
            patientRepoMock.Object,
            appointmentRepoMock.Object
        );
    }
}
