using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecializationController(ISpecializationService service, ILogger<SpecializationController> logger) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Specialization>>> GetAll()
    {
        logger.LogInformation("Called GetAll in SpecializationController");
        var specializations = await service.GetAllSpecializationsAsync();
        return Ok(specializations);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Specialization>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in SpecializationController");
        var specialization = await service.GetSpecializationAsync(id);
        if (specialization is null) return NotFound();
        return Ok(specialization);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Create([FromBody] Specialization specialization)
    {
        logger.LogInformation("Called Create in SpecializationController");
        var id = await service.CreateSpecializationAsync(specialization);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Specialization>> Update(Guid id, [FromBody] Specialization specialization)
    {
        logger.LogInformation("Called Update in SpecializationController");
        var updated = await service.UpdateSpecializationAsync(id, specialization);
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in SpecializationController");
        var deleted = await service.DeleteSpecializationAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
