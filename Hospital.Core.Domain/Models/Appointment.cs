namespace Hospital.Core.Domain.Models;
public class Appointment
{
    public DateTime AppointmentTime { get; set; }
    public required string CabinetNumber { get; set; }
    public bool IsRepeated { get; set; }
    public required Patient Patient { get; set; }
    public required Doctor Doctor { get; set; }

}
