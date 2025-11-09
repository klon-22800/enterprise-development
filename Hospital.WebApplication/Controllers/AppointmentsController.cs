using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Service;
using Hospital.WebApplication.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApplication.Controllers;

/// <summary>Controller for managing appointments.</summary>
[Route("api/[controller]")]
[ApiController]
public class AppointmentController(IAppointmentService service, ILogger<AppointmentController> logger) : ControllerBase
{
    /// <summary>Returns all appointments.</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Appointment>>> GetAll()
    {
        logger.LogInformation("Called GetAll in AppointmentController");
        var appointments = await service.GetAllAppointmentsAsync();
        return Ok(appointments);
    }

    /// <summary>Returns an appointment by Id.</summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Appointment>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in AppointmentController");
        var appointment = await service.GetAppointmentAsync(id);
        if (appointment is null) return NotFound();
        return Ok(appointment);
    }

    /// <summary>Creates a new appointment.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create([FromBody] AppointmentDto appointmentDto)
    {
        logger.LogInformation("Called Create in AppointmentController");
        var id = await service.CreateAppointmentAsync(appointmentDto.ToDomain());
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    /// <summary>Updates an existing appointment by Id.</summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Appointment>> Update(Guid id, [FromBody] AppointmentDto appointmentDto)
    {
        logger.LogInformation("Called Update in AppointmentController");
        var updated = await service.UpdateAppointmentAsync(id, appointmentDto.ToDomain());
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    /// <summary>Deletes an appointment by Id.</summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in AppointmentController");
        var deleted = await service.DeleteAppointmentAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
