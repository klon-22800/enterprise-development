using Hospital.Core.Domain.Models;
using Hospital.Core.Domain.Shared.Enums;

namespace Hospital.Core.Domain.DataSeeder;

/// <summary>
/// Provides methods to generate seed data for the hospital system.
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Generates seed data for specializations.
    /// </summary>
    public static Specialization[] SeedSpecializations() => new[]
    {
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000001"), Name = "Хирург" },
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000002"), Name = "Терапевт" },   
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000003"), Name = "Офтальмолог" },
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000004"), Name = "Невролог" },
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000005"), Name = "Педиатр" },
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000006"), Name = "Проктолог" },
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000007"), Name = "Дерматолог" },
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000008"), Name = "Ортопед" },
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000009"), Name = "Эндокринолог" },
        new Specialization { Id = Guid.Parse("b0000000-0000-0000-0000-000000000000"), Name = "Психиатр" },
    };

    /// <summary>
    /// Generates seed data for doctors.
    /// </summary>
    public static Doctor[] SeedDoctors(Specialization[] specializations) => new[]
    {
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000001"), PassportNumber = "1111 100001", Name = "Иван", Surname = "Иванов", Patronymic = "Иванович", BirthDate = new DateOnly(1975, 5, 15), SpecializationId = specializations[0].Id, Experience = 20 },
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000002"), PassportNumber = "2222 200002", Name = "Петр", Surname = "Петров", Patronymic = "Петрович", BirthDate = new DateOnly(1980, 3, 21), SpecializationId = specializations[1].Id, Experience = 15 },
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000003"), PassportNumber = "3333 300003", Name = "Анна", Surname = "Смирнова", Patronymic = "Сергеевна", BirthDate = new DateOnly(1988, 7, 9), SpecializationId = specializations[2].Id, Experience = 10 },
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000004"), PassportNumber = "4444 400004", Name = "Сергей", Surname = "Сидоров", Patronymic = "Андреевич", BirthDate = new DateOnly(1970, 11, 3), SpecializationId = specializations[3].Id, Experience = 25 },
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000005"), PassportNumber = "6666 600006", Name = "Дмитрий", Surname = "Орлов", Patronymic = "Михайлович", BirthDate = new DateOnly(1983, 6, 30), SpecializationId = specializations[4].Id, Experience = 12 },
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000006"), PassportNumber = "6412 100503", Name = "Михаил", Surname = "Косенко", Patronymic = "Романович", BirthDate = new DateOnly(1990, 1, 17), SpecializationId = specializations[5].Id, Experience = 7 },
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000007"), PassportNumber = "7777 700007", Name = "Ольга", Surname = "Морозова", Patronymic = "Александровна", BirthDate = new DateOnly(1985, 4, 12), SpecializationId = specializations[6].Id, Experience = 9 },
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000008"), PassportNumber = "8888 800008", Name = "Алексей", Surname = "Федоров", Patronymic = "Игоревич", BirthDate = new DateOnly(1978, 9, 23), SpecializationId = specializations[7].Id, Experience = 18 },
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000009"), PassportNumber = "9999 900009", Name = "Елена", Surname = "Соболева", Patronymic = "Степановна", BirthDate = new DateOnly(1992, 2, 2), SpecializationId = specializations[8].Id, Experience = 5 },
        new Doctor { Id = Guid.Parse("d0000000-0000-0000-0000-000000000000"), PassportNumber = "0000 100010", Name = "Вячеслав", Surname = "Ряхов", Patronymic = "Вячеславович", BirthDate = new DateOnly(1969, 12, 25), SpecializationId = specializations[9].Id, Experience = 30 },
    };

    /// <summary>
    /// Generates seed data for patients.
    /// </summary>
    public static Patient[] SeedPatients() => new[]
    {
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000001"), PassportNumber = "2222 000001", Name = "Андрей", Surname = "Козлов", Patronymic = "Иванович", BirthDate = new DateOnly(1995, 8, 10), Address = "Ленина 1", Gender = Gender.Male, BloodType = BloodType.O, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79001111111" },
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000002"), PassportNumber = "2222 000002", Name = "Светлана", Surname = "Павлова", Patronymic = "Сергеевна", BirthDate = new DateOnly(1987, 4, 14), Address = "Мира 7", Gender = Gender.Female, BloodType = BloodType.A, RhesusFactor = RhesusFactor.Negative, PhoneNumber = "+79002222222" },
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000003"), PassportNumber = "2222 000003", Name = "Никита", Surname = "Сергеев", Patronymic = "Павлович", BirthDate = new DateOnly(2000, 12, 1), Address = "Гагарина 10", Gender = Gender.Male, BloodType = BloodType.B, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79003333333" },
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000004"), PassportNumber = "2222 000004", Name = "Марина", Surname = "Соколова", Patronymic = "Олеговна", BirthDate = new DateOnly(1999, 3, 3), Address = "Советская 15", Gender = Gender.Female, BloodType = BloodType.AB, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79004444444" },
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000005"), PassportNumber = "2222 000005", Name = "Павел", Surname = "Михайлов", Patronymic = "Андреевич", BirthDate = new DateOnly(1985, 10, 20), Address = "Парковая 18", Gender = Gender.Male, BloodType = BloodType.O, RhesusFactor = RhesusFactor.Negative, PhoneNumber = "+79005555555" },
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000006"), PassportNumber = "2222 000006", Name = "Екатерина", Surname = "Новикова", Patronymic = "Михайловна", BirthDate = new DateOnly(1993, 5, 15), Address = "Центральная 9", Gender = Gender.Female, BloodType = BloodType.B, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79006666666" },
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000007"), PassportNumber = "2222 000007", Name = "Игорь", Surname = "Васильев", Patronymic = "Дмитриевич", BirthDate = new DateOnly(1990, 11, 8), Address = "Школьная 22", Gender = Gender.Male, BloodType = BloodType.A, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79007777777" },
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000008"), PassportNumber = "2222 000008", Name = "Алина", Surname = "Григорьева", Patronymic = "Станиславовна", BirthDate = new DateOnly(1998, 1, 30), Address = "Молодежная 3", Gender = Gender.Female, BloodType = BloodType.O, RhesusFactor = RhesusFactor.Negative, PhoneNumber = "+79008888888" },
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000009"), PassportNumber = "2222 000009", Name = "Руслан", Surname = "Александров", Patronymic = "Владимирович", BirthDate = new DateOnly(1982, 7, 19), Address = "Заречная 12", Gender = Gender.Male, BloodType = BloodType.AB, RhesusFactor = RhesusFactor.Negative, PhoneNumber = "+79009999999" },
        new Patient { Id = Guid.Parse("c0000000-0000-0000-0000-000000000000"), PassportNumber = "2222 000010", Name = "Юлия", Surname = "Тарасова", Patronymic = "Егоровна", BirthDate = new DateOnly(1992, 9, 25), Address = "Пушкина 5", Gender = Gender.Female, BloodType = BloodType.B, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79000000000" },
    };

    /// <summary>
    /// Generates seed data for appointments.
    /// </summary>
    public static Appointment[] SeedAppointments(Patient[] patients, Doctor[] doctors) => new[]
    {
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000001"), AppointmentTime = new DateTime(2025, 1, 1, 9, 0, 0), OfficeNumber = "101", IsRepeated = false, PatientId = patients[0].Id, DoctorId = doctors[0].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000002"), AppointmentTime = new DateTime(2025, 3, 1, 10, 0, 0), OfficeNumber = "102", IsRepeated = true, PatientId = patients[1].Id, DoctorId = doctors[1].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000003"), AppointmentTime = new DateTime(2025, 5, 1, 11, 0, 0), OfficeNumber = "103", IsRepeated = false, PatientId = patients[2].Id, DoctorId = doctors[2].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000004"), AppointmentTime = new DateTime(2025, 7, 1, 12, 0, 0), OfficeNumber = "104", IsRepeated = false, PatientId = patients[3].Id, DoctorId = doctors[3].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000005"), AppointmentTime = new DateTime(2025, 9, 1, 13, 0, 0), OfficeNumber = "105", IsRepeated = true, PatientId = patients[4].Id, DoctorId = doctors[4].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000006"), AppointmentTime = new DateTime(2025, 11, 1, 14, 0, 0), OfficeNumber = "106", IsRepeated = false, PatientId = patients[5].Id, DoctorId = doctors[5].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000007"), AppointmentTime = new DateTime(2025, 2, 1, 15, 0, 0), OfficeNumber = "107", IsRepeated = true, PatientId = patients[6].Id, DoctorId = doctors[6].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000008"), AppointmentTime = new DateTime(2025, 4, 1, 16, 0, 0), OfficeNumber = "108", IsRepeated = false, PatientId = patients[7].Id, DoctorId = doctors[7].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000009"), AppointmentTime = new DateTime(2025, 6, 1, 17, 0, 0), OfficeNumber = "109", IsRepeated = true, PatientId = patients[8].Id, DoctorId = doctors[8].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000010"), AppointmentTime = new DateTime(2025, 8, 1, 18, 0, 0), OfficeNumber = "110", IsRepeated = false, PatientId = patients[9].Id, DoctorId = doctors[9].Id },
        new Appointment { Id = Guid.Parse("a0000000-0000-0000-0000-000000000011"), AppointmentTime = new DateTime(2025, 2, 1, 10, 0, 0), OfficeNumber = "101", IsRepeated = false, PatientId = patients[9].Id, DoctorId = doctors[0].Id },
    };
}
