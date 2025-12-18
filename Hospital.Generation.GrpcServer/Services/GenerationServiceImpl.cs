using Bogus;
using Grpc.Core;
using Hospital.Grpc.Contracts;

namespace Hospital.Generation.GrpcServer.Services;

public class GenerationServiceImpl : GenerationService.GenerationServiceBase
{
    private readonly Faker _faker = new("ru");

    public override async Task Generate(
        IAsyncStreamReader<GenerationRequest> requestStream,
        IServerStreamWriter<GenerationResponse> responseStream,
        ServerCallContext context)
    {
        var totalCount = 0;
        var batchSize = 0;
        var currentBatch = 0;

        var patronymics = new[]
            {
                "Иванович", "Петрович", "Сергеевич", "Александрович",
                "Михайлович", "Романович", "Алексеевич", "Степанович",
                "Вячеславович", "Николаевич", "Александровна", "Сергеевна", "Михайловна"
            };

         List<string> SpecializationIds = new()
            {
                "b0000000-0000-0000-0000-000000000001", "b0000000-0000-0000-0000-000000000002",
                "b0000000-0000-0000-0000-000000000003", "b0000000-0000-0000-0000-000000000004",
                "b0000000-0000-0000-0000-000000000005", "b0000000-0000-0000-0000-000000000006",
                "b0000000-0000-0000-0000-000000000007", "b0000000-0000-0000-0000-000000000008",
                "b0000000-0000-0000-0000-000000000009", "b0000000-0000-0000-0000-000000000000",

            };

    await foreach (var request in requestStream.ReadAllAsync())
        {
            switch (request.PayloadCase)
            {
                case GenerationRequest.PayloadOneofCase.Start:
                    totalCount = request.Start.TotalCount;
                    batchSize = request.Start.BatchSize;
                    currentBatch = 0;

                    while (totalCount > 0 && !context.CancellationToken.IsCancellationRequested)
                    {
                        currentBatch++;
                        var thisBatchSize = Math.Min(batchSize, totalCount);

                        var doctors = Enumerable.Range(1, thisBatchSize)
                            .Select(_ => new DoctorGrpc
                            {
                                Id = Guid.NewGuid().ToString(),
                                PassportNumber = _faker.Random.Replace("#### ####"),
                                Name = _faker.Name.FirstName(),
                                Surname = _faker.Name.LastName(),
                                Patronymic = _faker.PickRandom(patronymics),
                                BirthDate = _faker.Date.Past(60, DateTime.Now.AddYears(-20)).ToString("yyyy-MM-dd"),
                                SpecializationId = _faker.PickRandom(SpecializationIds),
                                Experience = _faker.Random.Int(1, 40)
                            }).ToList();

                        var patients = Enumerable.Range(1, thisBatchSize)
                            .Select(_ => new PatientGrpc
                            {
                                Id = Guid.NewGuid().ToString(),
                                PassportNumber = _faker.Random.Replace("#### ####"),
                                Name = _faker.Name.FirstName(),
                                Surname = _faker.Name.LastName(),
                                Patronymic = _faker.PickRandom(patronymics),
                                BirthDate = _faker.Date.Past(80, DateTime.Now.AddYears(-18)).ToString("yyyy-MM-dd"),
                                Address = _faker.Address.FullAddress(),
                                Gender = _faker.PickRandom<GenderGrpc>(),
                                BloodType = _faker.PickRandom<BloodTypeGrpc>(),
                                RhesusFactor = _faker.PickRandom<RhesusFactorGrpc>(),
                                PhoneNumber = _faker.Phone.PhoneNumber()
                            }).ToList();

                        var appointments = Enumerable.Range(1, thisBatchSize)
                            .Select(i => new AppointmentGrpc
                            {
                                Id = Guid.NewGuid().ToString(),
                                AppointmentTime = _faker.Date.Future().ToString("o"),
                                OfficeNumber = _faker.Random.Int(1, 50).ToString(),
                                IsRepeated = _faker.Random.Bool(),
                                DoctorId = doctors[i - 1].Id,
                                PatientId = patients[i - 1].Id
                            }).ToList();

                        var batchResponse = new GenerationResponse
                        {
                            Batch = new AppointmentBatch
                            {
                                BatchNumber = currentBatch
                            }
                        };

                        batchResponse.Batch.Doctors.AddRange(doctors);
                        batchResponse.Batch.Patients.AddRange(patients);
                        batchResponse.Batch.Appointments.AddRange(appointments);

                        await responseStream.WriteAsync(batchResponse);

                        totalCount -= thisBatchSize;

                        // Ждём ack от клиента перед отправкой следующего батча
                        if (!await WaitForAck(requestStream, context, currentBatch))
                            return;
                    }

                    // Генерация завершена
                    await responseStream.WriteAsync(new GenerationResponse
                    {
                        Completed = new GenerationCompleted { TotalBatches = currentBatch }
                    });
                    break;

                case GenerationRequest.PayloadOneofCase.Ack:
                    // Игнорируем здесь, ack обрабатывается внутри WaitForAck
                    break;
            }
        }
    }

    private async Task<bool> WaitForAck(IAsyncStreamReader<GenerationRequest> requestStream, ServerCallContext context, int currentBatch)
    {
        try
        {
            await foreach (var request in requestStream.ReadAllAsync())
            {
                if (request.PayloadCase == GenerationRequest.PayloadOneofCase.Ack &&
                    request.Ack.BatchNumber == currentBatch)
                {
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
}
