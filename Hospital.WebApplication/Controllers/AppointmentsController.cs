using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Service;
using Hospital.WebApplication.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController(IAppointmentService service, ILogger<AppointmentController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Appointment>>> GetAll()
    {
        logger.LogInformation("Called GetAll in AppointmentController");
        var appointments = await service.GetAllAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Appointment>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in AppointmentController");
        var appointment = await service.GetAppointmentAsync(id);
        if (appointment is null) return NotFound();
        return Ok(appointment);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] AppointmentDto appointmentDto)
    {
        logger.LogInformation("Called Create in AppointmentController");
        var id = await service.CreateAppointmentAsync(appointmentDto.ToDomain());
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Appointment>> Update(Guid id, [FromBody] AppointmentDto appointmentDto)
    {
        logger.LogInformation("Called Update in AppointmentController");
        var updated = await service.UpdateAppointmentAsync(id, appointmentDto.ToDomain());
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in AppointmentController");
        var deleted = await service.DeleteAppointmentAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
