using Hospital.Core.Tests.Fixtures;

namespace Hospital.Core.Tests;

/// <summary>
/// Contains unit tests for hospital core functionality using test data fixture.
/// </summary>
public class UnitTest : IClassFixture<TestDataFixture>
{
    private readonly TestDataFixture _fixture;


    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    public UnitTest(TestDataFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Tests retrieving doctors with experience of 10 years or more.
    /// </summary>
    [Fact]
    public void DoctorsWithExperienceMoreThan10()
    {
        var doctors = _fixture.Doctors;

        var passportNumbers = doctors
            .Where(d => d.Expirience >= 10)
            .OrderBy(d => d.PassportNumber)
            .Select(d => d.PassportNumber)
            .ToArray();

        var expected = new[]
        {
            "0000 100010", 
            "1111 100001", 
            "2222 200002", 
            "3333 300003", 
            "4444 400004",
            "6666 600006",
            "8888 800008" 
        };

        Assert.Equal(expected, passportNumbers);
    }

    /// <summary>
    /// Tests retrieving patients of a specific doctor.
    /// </summary>
    [Fact]
    public void PatientsOfSpecificDoctor()
    {
        var doctorPassport = "0000 100010"; 
        var appointments = _fixture.Appointments;

        var patientPassports = appointments
            .Where(a => a.Doctor.PassportNumber == doctorPassport)
            .Select(a => a.Patient)
            .OrderBy(p => p.Surname)
            .ThenBy(p => p.Name)
            .ThenBy(p => p.Patronymic)
            .Select(p => p.PassportNumber)
            .ToArray();

        var expected = new[]
        {
            "2222 000009", "2222 000008", "2222 000010"
        };

        Assert.Equal(expected, patientPassports);
    }

    /// <summary>
    /// Tests counting repeated appointments per patient in the last month.
    /// </summary>
    [Fact]
    public void CountOfRepeatedAppointmentsPerPatientLastMonth()
    {
        var appointments = _fixture.Appointments;
        var today = new DateTime(2025, 9, 24); 
        var monthAgo = today.AddMonths(-1);

        var repeatedCounts = appointments
            .Where(a => a.IsRepeated && a.AppointmentTime >= monthAgo && a.AppointmentTime <= today)
            .GroupBy(a => a.Patient.PassportNumber)
            .Select(g => new
            {
                PatientPassport = g.Key,
                Count = g.Count()
            })
            .OrderBy(r => r.PatientPassport)
            .ToArray();


        var expected = new[]
        {
            new { PatientPassport = "2222 000005", Count = 1 },
        };


        Assert.Equal(expected, repeatedCounts);
    }

    /// <summary>
    /// Tests retrieving patients over 30 years old with appointments to multiple doctors.
    /// </summary>
    [Fact]
    public void PatientsOver30WithAppointmentsToMultipleDoctors()
    {
        var appointments = _fixture.Appointments;
        var today = new DateOnly(2025, 9, 24); 
        var ageLimit = today.AddYears(-30);

        var patientPassports = appointments
            .Where(a => a.Patient.BirthDate <= ageLimit)
            .GroupBy(a => a.Patient.PassportNumber)
            .Where(g => g.Select(a => a.Doctor.PassportNumber).Distinct().Count() > 1)
            .Select(g => g.Key) 
            .Join(
                appointments.Select(a => a.Patient).Distinct(),
                passport => passport,
                patient => patient.PassportNumber,
                (passport, patient) => new { patient.PassportNumber, patient.BirthDate }
            )
            .OrderBy(p => p.BirthDate)
            .Select(p => p.PassportNumber)
            .ToArray();

        var expected = new string[] {"2222 000010"};

        Assert.Equal(expected, patientPassports);
    }

    /// <summary>
    /// Tests retrieving appointments in the current month for a specific cabinet.
    /// </summary>
    [Fact]
    public void AppointmentsCurrentMonthInSpecificCabinet()
    {
        var appointments = _fixture.Appointments;
        var today = new DateTime(2025, 9, 24); 
        var cabinetNumber = "105"; 

        var appointmentPatientPassports = appointments
            .Where(a => a.CabinetNumber == cabinetNumber
                        && a.AppointmentTime.Year == today.Year
                        && a.AppointmentTime.Month == today.Month)
            .OrderBy(a => a.AppointmentTime)
            .Select(a => a.Patient.PassportNumber)
            .ToArray();

        var expected = new[]
        {
            "2222 000005" 
        };

        Assert.Equal(expected, appointmentPatientPassports);
    }

}
