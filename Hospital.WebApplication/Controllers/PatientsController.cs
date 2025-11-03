using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController(IPatientService service, ILogger<PatientController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Patient>>> GetAll()
    {
        logger.LogInformation("Called GetAll in PatientController");
        var patients = await service.GetAllPatientsAsync();
        return Ok(patients);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Patient>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in PatientController");
        var patient = await service.GetPatientAsync(id);
        if (patient is null) return NotFound();
        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Patient patient)
    {
        logger.LogInformation("Called Create in PatientController");
        var id = await service.CreatePatientAsync(patient);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Patient>> Update(Guid id, [FromBody] Patient patient)
    {
        logger.LogInformation("Called Update in PatientController");
        var updated = await service.UpdatePatientAsync(id, patient);
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in PatientController");
        var deleted = await service.DeletePatientAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
