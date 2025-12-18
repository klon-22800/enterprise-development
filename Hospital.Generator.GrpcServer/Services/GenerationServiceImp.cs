using Hospital.GrpcContracts.Generation;
using Grpc.Core;

namespace Hospital.Generator.GrpcServer.Services;

public class GenerationServiceImpl : GenerationService.GenerationServiceBase
{
    public override async Task Generate(
        IAsyncStreamReader<GenerationRequest> requestStream,
        IServerStreamWriter<GenerationResponse> responseStream,
        ServerCallContext context)
    {
        await foreach (var request in requestStream.ReadAllAsync())
        {
            switch (request.PayloadCase)
            {
                case GenerationRequest.PayloadOneofCase.Start:
                    var start = request.Start;
                    // TODO: генерация данных через Bogus и отправка батчей
                    break;

                case GenerationRequest.PayloadOneofCase.Ack:
                    var ack = request.Ack;
                    // TODO: обработка ack от клиента
                    break;
            }
        }
    }
}
