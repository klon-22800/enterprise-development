using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Service;
using Hospital.WebApplication.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApplication.Controllers;

/// <summary>Controller for managing doctors.</summary>
[Route("api/[controller]")]
[ApiController]
public class DoctorController(IDoctorService service, ILogger<DoctorController> logger) : ControllerBase
{
    /// <summary>Returns all doctors.</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Doctor>>> GetAll()
    {
        logger.LogInformation("Called GetAll in DoctorController");
        var doctors = await service.GetAllDoctorsAsync();
        return Ok(doctors);
    }

    /// <summary>Returns a doctor by Id.</summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Doctor>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in DoctorController");
        var doctor = await service.GetDoctorAsync(id);
        if (doctor is null) return NotFound();
        return Ok(doctor);
    }

    /// <summary>Creates a new doctor.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Create([FromBody] DoctorDto doctorDto)
    {
        logger.LogInformation("Called Create in DoctorController");
        var id = await service.CreateDoctorAsync(doctorDto.ToDomain());
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    /// <summary>Updates a doctor by Id.</summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Doctor>> Update(Guid id, [FromBody] DoctorDto doctorDto)
    {
        logger.LogInformation("Called Update in DoctorController");
        var updated = await service.UpdateDoctorAsync(id, doctorDto.ToDomain());
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    /// <summary>Deletes a doctor by Id.</summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in DoctorController");
        var deleted = await service.DeleteDoctorAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}