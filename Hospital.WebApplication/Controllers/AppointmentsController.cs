using Hospital.Core.Domain.Service;
using Hospital.WebApplication.Mappers;
using Microsoft.AspNetCore.Mvc;
using Hospital.Contracts.Dto;

namespace Hospital.WebApplication.Controllers;

/// <summary>
/// Controller for managing appointments.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AppointmentController(IAppointmentService service, ILogger<AppointmentController> logger) : ControllerBase
{
    /// <summary>
    /// Returns all appointments.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AppointmentResponseDto>>> GetAll()
    {
        logger.LogInformation("Called GetAll in AppointmentController");
        var appointments = await service.GetAllAppointmentsAsync();
        var response = appointments.Select(a => a.ToResponse()).ToList();
        return Ok(response);
    }

    /// <summary>
    /// Returns an appointment by Id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AppointmentResponseDto>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in AppointmentController");
        var appointment = await service.GetAppointmentAsync(id);
        if (appointment is null) return NotFound();
        var response = appointment.ToResponse();
        return Ok(response);
    }

    /// <summary>
    /// Creates a new appointment.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Create([FromBody] AppointmentDto appointmentDto)
    {
        logger.LogInformation("Called Create in AppointmentController");

        try
        {
            var id = await service.CreateAppointmentAsync(appointmentDto.ToDomain());
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
    /// Updates an existing appointment by Id.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AppointmentResponseDto>> Update(Guid id, [FromBody] AppointmentDto appointmentDto)
    {
        logger.LogInformation("Called Update in AppointmentController");

        if (appointmentDto is null)
            return BadRequest("Appointment data is required.");

        try
        {
            var appointmentToUpdate = appointmentDto.ToDomain();

            var updated = await service.UpdateAppointmentAsync(id, appointmentToUpdate);
            if (updated is null)
                return NotFound();

            var response = updated.ToResponse();
            return Ok(response);
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
    /// Deletes an appointment by Id.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in AppointmentController");
        try
        {
            var deleted = await service.DeleteAppointmentAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred in Delete");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
}
