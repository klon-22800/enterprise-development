using Grpc.Core;
using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Grpc.Contracts;

namespace Hospital.WebApplication.Grpc;

/// <summary>
/// Класс GrpcConsumer для принятия, обработки и сохранения данных через репозитории
/// </summary>
public class GrpcClientConsumer
{
    private readonly IDoctorRepository _doctorRepo;
    private readonly IRepository<Patient> _patientRepo;
    private readonly IAppointmentRepository _appointmentRepo;
    private readonly GenerationService.GenerationServiceClient _grpcClient;

    public GrpcClientConsumer(
        IDoctorRepository doctorRepo,
        IRepository<Patient> patientRepo,
        IAppointmentRepository appointmentRepo,
        GenerationService.GenerationServiceClient grpcClient)
    {
        _doctorRepo = doctorRepo;
        _patientRepo = patientRepo;
        _appointmentRepo = appointmentRepo;
        _grpcClient = grpcClient;
    }

    /// <summary>
    /// Метод для принятия и обработки данных 
    /// </summary>
    /// <param name="totalCount" > Общее кол-во каждой сущности </param>
    /// <param name="batchSize" > Кол-во сущностей в одном батче </param>
    public async Task StartGenerationAsync(int totalCount, int batchSize, CancellationToken cancellationToken = default)
    {
        using var call = _grpcClient.Generate();

        await call.RequestStream.WriteAsync(new GenerationRequest
        {
            Start = new StartGeneration
            {
                TotalCount = totalCount,
                BatchSize = batchSize
            }
        });

        await foreach (var response in call.ResponseStream.ReadAllAsync(cancellationToken))
        {
            if (response.PayloadCase == GenerationResponse.PayloadOneofCase.Batch)
            {
                var batch = response.Batch;

                foreach (var doc in batch.Doctors)
                {
                    var doctor = new Doctor
                    {
                        Id = Guid.Parse(doc.Id),
                        PassportNumber = doc.PassportNumber,
                        Name = doc.Name,
                        Surname = doc.Surname,
                        Patronymic = doc.Patronymic,
                        BirthDate = DateOnly.Parse(doc.BirthDate),
                        SpecializationId = Guid.Parse(doc.SpecializationId),
                        Experience = doc.Experience
                    };
                    await _doctorRepo.CreateAsync(doctor);
                }

                foreach (var pat in batch.Patients)
                {
                    var patient = new Patient
                    {
                        Id = Guid.Parse(pat.Id),
                        PassportNumber = pat.PassportNumber,
                        Name = pat.Name,
                        Surname = pat.Surname,
                        Patronymic = pat.Patronymic,
                        BirthDate = DateOnly.Parse(pat.BirthDate),
                        Address = pat.Address,
                        Gender = pat.Gender.ToDomain(),
                        BloodType = pat.BloodType.ToDomain(),
                        RhesusFactor = pat.RhesusFactor.ToDomain(),
                        PhoneNumber = pat.PhoneNumber
                    };
                    await _patientRepo.CreateAsync(patient);
                }

                foreach (var app in batch.Appointments)
                {
                    var appointment = new Appointment
                    {
                        Id = Guid.Parse(app.Id),
                        AppointmentTime = DateTime.Parse(app.AppointmentTime),
                        OfficeNumber = app.OfficeNumber,
                        IsRepeated = app.IsRepeated,
                        DoctorId = Guid.Parse(app.DoctorId),
                        PatientId = Guid.Parse(app.PatientId)
                    };
                    await _appointmentRepo.CreateAsync(appointment);
                }

                await call.RequestStream.WriteAsync(new GenerationRequest
                {
                    Ack = new BatchAck { BatchNumber = batch.BatchNumber }
                });
            }
            else if (response.PayloadCase == GenerationResponse.PayloadOneofCase.Completed)
            {
                Console.WriteLine($"Generation completed. Total batches: {response.Completed.TotalBatches}");
                break;
            }
            else if (response.PayloadCase == GenerationResponse.PayloadOneofCase.Error)
            {
                Console.WriteLine($"Generation error: {response.Error.Message}");
                break;
            }
        }

        await call.RequestStream.CompleteAsync();
    }
}
