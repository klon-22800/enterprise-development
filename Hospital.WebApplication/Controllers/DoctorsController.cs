using Hospital.Core.Domain.Service;
using Hospital.WebApplication.Mappers;
using Microsoft.AspNetCore.Mvc;
using Hospital.Contracts.Dto.Doctor;

namespace Hospital.WebApplication.Controllers;

/// <summary>
/// Controller for managing doctors.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DoctorController(IDoctorService service, ILogger<DoctorController> logger) : ControllerBase
{
    /// <summary>
    /// Returns all doctors.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<DoctorResponseDto>>> GetAll()
    {
        logger.LogInformation("Called GetAll in DoctorController");
        try
        {
            var doctors = await service.GetAllDoctorsAsync();
            var response = doctors.Select(d => d.ToResponse()).ToList();
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in GetAll");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    /// <summary>
    /// Returns a doctor by Id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DoctorResponseDto>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in DoctorController");
        try
        {
            var doctor = await service.GetDoctorAsync(id);
            if (doctor is null) return NotFound();

            return Ok(doctor.ToResponse());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in GetById");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    /// <summary>
    /// Creates a new doctor.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Create([FromBody] DoctorDto doctorDto)
    {
        logger.LogInformation("Called Create in DoctorController");

        if (doctorDto is null)
            return BadRequest("Doctor data is required.");

        try
        {
            var id = await service.CreateDoctorAsync(doctorDto.ToDomain());
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
    /// Updates a doctor by Id.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DoctorResponseDto>> Update(Guid id, [FromBody] DoctorDto doctorDto)
    {
        logger.LogInformation("Called Update in DoctorController");

        if (doctorDto is null)
            return BadRequest("Doctor data is required.");

        try
        {
            var doctorToUpdate = doctorDto.ToDomain();
            doctorToUpdate.Id = id; 

            var updated = await service.UpdateDoctorAsync(id, doctorToUpdate);
            if (updated is null)
                return NotFound();

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
    /// Deletes a doctor by Id.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in DoctorController");

        try
        {
            var deleted = await service.DeleteDoctorAsync(id);
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
