namespace Hospital.Core.Domain.Models;

public class Patient
{
    public required string PassportNumber { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Patronymic { get; set; }
    public DateOnly BirthDate { get; set; }
    public required string Address {  get; set; }
    public required string Gender { get; set; }
    public BloodType BloodType { get; set; }
    public RhesusFactor RhesusFactor { get; set; }
    public required string PhoneNumber { get; set; }

}
