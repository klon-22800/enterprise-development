using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApplication.Grpc;


/// <summary>
/// Контроллер для запсука процесса генерации. 
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class GenerationController : ControllerBase
{
    private readonly GrpcClientConsumer _grpcConsumer;

    public GenerationController(GrpcClientConsumer grpcConsumer)
    {
        _grpcConsumer = grpcConsumer;
    }

    /// <summary>
    /// Entrypoit для запуска процесса генерации
    /// </summary>
    /// <param name="totalCount" > Общее кол-во каждой сущности </param>
    /// <param name="batchSize" > Кол-во сущностей в одном батче </param>
    [HttpPost("start")]
    public async Task<IActionResult> StartGeneration([FromQuery] int totalCount, [FromQuery] int batchSize)
    {
        await _grpcConsumer.StartGenerationAsync(totalCount, batchSize);
        return Ok(new { Message = "Generation started" });
    }
}
