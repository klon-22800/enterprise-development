using Bogus;
using Grpc.Core;
using Hospital.Grpc.Contracts;

namespace Hospital.Generation.GrpcServer.Services;

/// <summary>
/// Класс для генерации сущностей DoctorGrpc, PatientGrpc и AppointmentGrpc
/// </summary>
public class GenerationServiceImpl(Faker faker) : GenerationService.GenerationServiceBase
{

    /// <summary>
    /// Генерация и отправка списков DTO-сущностей по батчей с учетом ответа от клиента
    /// </summary>
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

         List<string> specializationIds = new()
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
                                    PassportNumber = faker.Random.Replace("#### ####"),
                                    Name = faker.Name.FirstName(),
                                    Surname = faker.Name.LastName(),
                                    Patronymic = faker.PickRandom(patronymics),
                                    BirthDate = faker.Date.Past(60, DateTime.Now.AddYears(-20)).ToString("yyyy-MM-dd"),
                                    SpecializationId = faker.PickRandom(specializationIds),
                                    Experience = faker.Random.Int(1, 40)
                                }).ToList();

                            var patients = Enumerable.Range(1, thisBatchSize)
                                .Select(_ => new PatientGrpc
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    PassportNumber = faker.Random.Replace("#### ####"),
                                    Name = faker.Name.FirstName(),
                                    Surname = faker.Name.LastName(),
                                    Patronymic = faker.PickRandom(patronymics),
                                    BirthDate = faker.Date.Past(80, DateTime.Now.AddYears(-18)).ToString("yyyy-MM-dd"),
                                    Address = faker.Address.FullAddress(),
                                    Gender = faker.PickRandom<GenderGrpc>(),
                                    BloodType = faker.PickRandom<BloodTypeGrpc>(),
                                    RhesusFactor = faker.PickRandom<RhesusFactorGrpc>(),
                                    PhoneNumber = faker.Phone.PhoneNumber()
                                }).ToList();

                            var appointments = Enumerable.Range(1, thisBatchSize)
                                .Select(i => new AppointmentGrpc
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    AppointmentTime = faker.Date.Future().ToString("o"),
                                    OfficeNumber = faker.Random.Int(1, 50).ToString(),
                                    IsRepeated = faker.Random.Bool(),
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

                            if (!await WaitForAck(requestStream, context, currentBatch))
                                return;
                        }

                        await responseStream.WriteAsync(new GenerationResponse
                        {
                            Completed = new GenerationCompleted { TotalBatches = currentBatch }
                        });
                        break;

                    case GenerationRequest.PayloadOneofCase.Ack:
                        break;
                }
            }
    }

    /// <summary>
    /// Ожидание ответа от клиента об успешной обработке батча
    /// </summary>
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
