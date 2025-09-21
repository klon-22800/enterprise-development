namespace Hospital.Core.Domain.Models;

public class Doctor
{
    public required string PassportNumber { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Patronymic { get; set; }
    public DateOnly BirthDate { get; set; }
    public required Specialization Specialization { get; set; }
    public int Expirience { get; set; }
}
