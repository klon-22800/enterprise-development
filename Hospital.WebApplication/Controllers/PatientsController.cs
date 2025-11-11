using Hospital.Core.Domain.Service;
using Hospital.WebApplication.Mappers;
using Microsoft.AspNetCore.Mvc;
using Hospital.Contracts.Dto;

namespace Hospital.WebApplication.Controllers;

/// <summary>
/// Controller for managing patients.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PatientController(IPatientService service, ILogger<PatientController> logger) : ControllerBase
{
    /// <summary>
    /// Returns all patients.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<PatientResponseDto>>> GetAll()
    {
        logger.LogInformation("Called GetAll in PatientController");
        try
        {
            var patients = await service.GetAllPatientsAsync();
            var response = patients.Select(p => p.ToResponse()).ToList();
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in GetAll");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    /// <summary>
    /// Returns a patient by Id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PatientResponseDto>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in PatientController");
        try
        {
            var patient = await service.GetPatientAsync(id);
            if (patient is null) return NotFound();

            return Ok(patient.ToResponse());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in GetById");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    /// <summary>
    /// Creates a new patient.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Create([FromBody] PatientDto patientDto)
    {
        logger.LogInformation("Called Create in PatientController");

        if (patientDto is null)
            return BadRequest("Patient data is required.");

        try
        {
            var id = await service.CreatePatientAsync(patientDto.ToDomain());
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
    /// Updates a patient by Id.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PatientResponseDto>> Update(Guid id, [FromBody] PatientDto patientDto)
    {
        logger.LogInformation("Called Update in PatientController");

        if (patientDto is null)
            return BadRequest("Patient data is required.");

        try
        {
            var updated = await service.UpdatePatientAsync(id, patientDto.ToDomain());
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
    /// Deletes a patient by Id.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in PatientController");

        try
        {
            var deleted = await service.DeletePatientAsync(id);
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
