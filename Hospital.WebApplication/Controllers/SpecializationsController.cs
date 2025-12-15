using Hospital.Core.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Hospital.Contracts.Dto.Specialization;
using Hospital.WebApplication.Mappers;

namespace Hospital.WebApplication.Controllers;

/// <summary>
/// Controller for managing specializations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecializationController(ISpecializationService service, ILogger<SpecializationController> logger) : ControllerBase
{
    /// <summary>
    /// Returns all specializations.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<SpecializationResponseDto>>> GetAll()
    {
        logger.LogInformation("Called GetAll in SpecializationController");
        try
        {
            var specializations = await service.GetAllSpecializationsAsync();
            var response = specializations.Select(s => s.ToResponse()).ToList();
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in GetAll");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    /// <summary>
    /// Returns a specialization by Id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SpecializationResponseDto>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in SpecializationController");
        try
        {
            var specialization = await service.GetSpecializationAsync(id);
            if (specialization is null) return NotFound();
            return Ok(specialization.ToResponse());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in GetById");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    /// <summary>
    /// Creates a new specialization.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Create([FromBody] SpecializationDto specializationDto)
    {
        logger.LogInformation("Called Create in SpecializationController");

        if (specializationDto is null)
            return BadRequest("Specialization data is required.");

        try
        {
            var id = await service.CreateSpecializationAsync(specializationDto.Name);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning(ex, "Validation failed during Create");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in Create");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    /// <summary>
    /// Updates a specialization by Id.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SpecializationResponseDto>> Update(Guid id, [FromBody] SpecializationDto specializationDto)
    {
        logger.LogInformation("Called Update in SpecializationController");

        if (specializationDto is null)
            return BadRequest("Specialization data is required.");

        try
        {
            var specializationToUpdate = specializationDto.ToDomain();
            specializationToUpdate.Id = id;

            var updated = await service.UpdateSpecializationAsync(id, specializationToUpdate);
            if (updated is null) return NotFound();

            return Ok(updated.ToResponse());
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning(ex, "Validation failed during Update");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in Update");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    /// <summary>
    /// Deletes a specialization by Id.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in SpecializationController");

        try
        {
            var deleted = await service.DeleteSpecializationAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in Delete");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
}
