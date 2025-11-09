using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Service;
using Hospital.WebApplication.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApplication.Controllers;

/// <summary>Controller for managing patients.</summary>
[Route("api/[controller]")]
[ApiController]
public class PatientController(IPatientService service, ILogger<PatientController> logger) : ControllerBase
{
    /// <summary>Returns all patients.</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Patient>>> GetAll()
    {
        logger.LogInformation("Called GetAll in PatientController");
        var patients = await service.GetAllPatientsAsync();
        return Ok(patients);
    }

    /// <summary>Returns a patient by Id.</summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Patient>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in PatientController");
        var patient = await service.GetPatientAsync(id);
        if (patient is null) return NotFound();
        return Ok(patient);
    }

    /// <summary>Creates a new patient.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create([FromBody] PatientDto patientDto)
    {
        logger.LogInformation("Called Create in PatientController");
        var id = await service.CreatePatientAsync(patientDto.ToDomain());
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    /// <summary>Updates a patient by Id.</summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Patient>> Update(Guid id, [FromBody] PatientDto patientDto)
    {
        logger.LogInformation("Called Update in PatientController");
        var updated = await service.UpdatePatientAsync(id, patientDto.ToDomain());
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    /// <summary>Deletes a patient by Id.</summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in PatientController");
        var deleted = await service.DeletePatientAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
