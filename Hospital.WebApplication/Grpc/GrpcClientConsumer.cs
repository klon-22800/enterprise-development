using Grpc.Core;
using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Repository;
using Hospital.Grpc.Contracts;
using Hospital.WebApplication.Grpc.Mappers;

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
    /// <param name="cancellationToken" > cancellationToken </param>
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
                    await _doctorRepo.CreateAsync(doc.ToDomain());
                }

                foreach (var pat in batch.Patients)
                {
                    await _patientRepo.CreateAsync(pat.ToDomain());
                }

                foreach (var app in batch.Appointments)
                {
                    await _appointmentRepo.CreateAsync(app.ToDomain());
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
