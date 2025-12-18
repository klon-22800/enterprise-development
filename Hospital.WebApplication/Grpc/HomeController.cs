using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApplication.Grpc;

[ApiController]
[Route("api/[controller]")]
public class GenerationController : ControllerBase
{
    private readonly GrpcClientConsumer _grpcConsumer;

    public GenerationController(GrpcClientConsumer grpcConsumer)
    {
        _grpcConsumer = grpcConsumer;
    }

    [HttpPost("start")]
    public async Task<IActionResult> StartGeneration([FromQuery] int totalCount, [FromQuery] int batchSize)
    {
        // Запускаем генерацию данных через gRPC
        await _grpcConsumer.StartGenerationAsync(totalCount, batchSize);
        return Ok(new { Message = "Generation started" });
    }
}
