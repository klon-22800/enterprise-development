using Hospital.Core.Domain.Service;
using Hospital.Core.Domain.Models;
using Hospital.Infrastructure.Repositories;

using Hospital.Core.Domain.Repository;


namespace Hospital.WebApplication.Services;


public class AnalyticsService(
    IRepository<Specialization> specialization,
    IRepository<Doctor> doctor, IRepository<Patient> patient, 
    IRepository<Appointment> appointment) : IAnalyticsService
{ 

    public Task<List<Guid>> GetDoctorsWithExperienceOver10Async(CancellationToken cancellationToken = default)
    {
        //Фигачим сюда бизнес логику и возвращает сразу готовые данные на тесты 
    }
        

    //public Task<List<Patient>> GetPatientsByDoctorAsync(Guid doctorId, CancellationToken cancellationToken = default)
    //    => _repository.GetPatientsByDoctorAsync(doctorId, cancellationToken);

    //public Task<List<(Guid PatientId, int Count)>> GetRepeatedAppointmentsLastMonthAsync(DateTime today, CancellationToken cancellationToken = default)
    //    => _repository.GetRepeatedAppointmentsLastMonthAsync(today, cancellationToken);

    //public Task<List<Patient>> GetPatientsOver30WithMultipleDoctorsAsync(DateOnly today, CancellationToken cancellationToken = default)
    //    => _repository.GetPatientsOver30WithMultipleDoctorsAsync(today, cancellationToken);

    //public Task<List<Appointment>> GetAppointmentsCurrentMonthByCabinetAsync(string cabinetNumber, DateTime today, CancellationToken cancellationToken = default)
    //    => _repository.GetAppointmentsCurrentMonthByCabinetAsync(cabinetNumber, today, cancellationToken);
}
