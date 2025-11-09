using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApplication.Controllers;

/// <summary>Controller for managing specializations.</summary>
[Route("api/[controller]")]
[ApiController]
public class SpecializationController(ISpecializationService service, ILogger<SpecializationController> logger) : ControllerBase
{
    /// <summary>Returns all specializations.</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Specialization>>> GetAll()
    {
        logger.LogInformation("Called GetAll in SpecializationController");
        var specializations = await service.GetAllSpecializationsAsync();
        return Ok(specializations);
    }

    /// <summary>Returns a specialization by Id.</summary>
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

    /// <summary>Creates a new specialization.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Create([FromBody] SpecializationDto specialization)
    {
        logger.LogInformation("Called Create in SpecializationController");
        var id = await service.CreateSpecializationAsync(specialization.Name);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    /// <summary>Updates a specialization by Id.</summary>
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

    /// <summary>Deletes a specialization by Id.</summary>
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
