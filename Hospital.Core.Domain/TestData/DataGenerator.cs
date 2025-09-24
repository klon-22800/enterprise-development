using Hospital.Core.Domain.Models;

namespace Hospital.Core.Domain.TestData;

public class DataGenerator
{
    public static (Patient[] patients, Doctor[] doctors, Specialization[] specializations, Appointment[] appointments) GenerateData()
    {
        var specializations = new[]
        {
            new Specialization { Id = 1, Name = "Хирург" },
            new Specialization { Id = 2, Name = "Терапевт" },
            new Specialization { Id = 3, Name = "Офтальмолог" },
            new Specialization { Id = 4, Name = "Невролог" },
            new Specialization { Id = 5, Name = "Педиатр" },
            new Specialization { Id = 6, Name = "Кардиолог" },
            new Specialization { Id = 7, Name = "Дерматолог" },
            new Specialization { Id = 8, Name = "Ортопед" },
            new Specialization { Id = 9, Name = "Эндокринолог" },
            new Specialization { Id = 10, Name = "Психиатр" },
        };

        var doctors = new[]
        {
            new Doctor { PassportNumber = "1111 100001", Name = "Иван", Surname = "Иванов", Patronymic = "Иванович", BirthDate = new DateOnly(1975, 5, 15), Specialization = specializations[0], Expirience = 20 },
            new Doctor { PassportNumber = "2222 200002", Name = "Петр", Surname = "Петров", Patronymic = "Петрович", BirthDate = new DateOnly(1980, 3, 21), Specialization = specializations[1], Expirience = 15 },
            new Doctor { PassportNumber = "3333 300003", Name = "Анна", Surname = "Смирнова", Patronymic = "Сергеевна", BirthDate = new DateOnly(1988, 7, 9), Specialization = specializations[2], Expirience = 10 },
            new Doctor { PassportNumber = "4444 400004", Name = "Сергей", Surname = "Сидоров", Patronymic = "Андреевич", BirthDate = new DateOnly(1970, 11, 3), Specialization = specializations[3], Expirience = 25 },
            new Doctor { PassportNumber = "5555 500005", Name = "Мария", Surname = "Кузнецова", Patronymic = "Олеговна", BirthDate = new DateOnly(1990, 1, 17), Specialization = specializations[4], Expirience = 7 },
            new Doctor { PassportNumber = "6666 600006", Name = "Дмитрий", Surname = "Орлов", Patronymic = "Михайлович", BirthDate = new DateOnly(1983, 6, 30), Specialization = specializations[5], Expirience = 12 },
            new Doctor { PassportNumber = "7777 700007", Name = "Ольга", Surname = "Морозова", Patronymic = "Александровна", BirthDate = new DateOnly(1985, 4, 12), Specialization = specializations[6], Expirience = 9 },
            new Doctor { PassportNumber = "8888 800008", Name = "Алексей", Surname = "Федоров", Patronymic = "Игоревич", BirthDate = new DateOnly(1978, 9, 23), Specialization = specializations[7], Expirience = 18 },
            new Doctor { PassportNumber = "9999 900009", Name = "Елена", Surname = "Соболева", Patronymic = "Степановна", BirthDate = new DateOnly(1992, 2, 2), Specialization = specializations[8], Expirience = 5 },
            new Doctor { PassportNumber = "0000 100010", Name = "Виктор", Surname = "Егоров", Patronymic = "Владимирович", BirthDate = new DateOnly(1969, 12, 25), Specialization = specializations[9], Expirience = 30 },
        };

        var patients = new[]
        {
            new Patient { PassportNumber = "2222 000001", Name = "Андрей", Surname = "Козлов", Patronymic = "Иванович", BirthDate = new DateOnly(1995, 8, 10), Address = "Ленина 1", Gender = "М", BloodType = BloodType.O, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79001111111" },
            new Patient { PassportNumber = "2222 000002", Name = "Светлана", Surname = "Павлова", Patronymic = "Сергеевна", BirthDate = new DateOnly(1987, 4, 14), Address = "Мира 7", Gender = "Ж", BloodType = BloodType.A, RhesusFactor = RhesusFactor.Negative, PhoneNumber = "+79002222222" },
            new Patient { PassportNumber = "2222 000003", Name = "Никита", Surname = "Сергеев", Patronymic = "Павлович", BirthDate = new DateOnly(2000, 12, 1), Address = "Гагарина 10", Gender = "М", BloodType = BloodType.B, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79003333333" },
            new Patient { PassportNumber = "2222 000004", Name = "Марина", Surname = "Соколова", Patronymic = "Олеговна", BirthDate = new DateOnly(1999, 3, 3), Address = "Советская 15", Gender = "Ж", BloodType = BloodType.AB, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79004444444" },
            new Patient { PassportNumber = "2222 000005", Name = "Павел", Surname = "Михайлов", Patronymic = "Андреевич", BirthDate = new DateOnly(1985, 10, 20), Address = "Парковая 18", Gender = "М", BloodType = BloodType.O, RhesusFactor = RhesusFactor.Negative, PhoneNumber = "+79005555555" },
            new Patient { PassportNumber = "2222 000006", Name = "Екатерина", Surname = "Новикова", Patronymic = "Михайловна", BirthDate = new DateOnly(1993, 5, 15), Address = "Центральная 9", Gender = "Ж", BloodType = BloodType.B, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79006666666" },
            new Patient { PassportNumber = "2222 000007", Name = "Игорь", Surname = "Васильев", Patronymic = "Дмитриевич", BirthDate = new DateOnly(1990, 11, 8), Address = "Школьная 22", Gender = "М", BloodType = BloodType.A, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79007777777" },
            new Patient { PassportNumber = "2222 000008", Name = "Алина", Surname = "Григорьева", Patronymic = "Станиславовна", BirthDate = new DateOnly(1998, 1, 30), Address = "Молодежная 3", Gender = "Ж", BloodType = BloodType.O, RhesusFactor = RhesusFactor.Negative, PhoneNumber = "+79008888888" },
            new Patient { PassportNumber = "2222 000009", Name = "Руслан", Surname = "Александров", Patronymic = "Владимирович", BirthDate = new DateOnly(1982, 7, 19), Address = "Заречная 12", Gender = "М", BloodType = BloodType.AB, RhesusFactor = RhesusFactor.Negative, PhoneNumber = "+79009999999" },
            new Patient { PassportNumber = "2222 000010", Name = "Юлия", Surname = "Тарасова", Patronymic = "Егоровна", BirthDate = new DateOnly(1992, 9, 25), Address = "Пушкина 5", Gender = "Ж", BloodType = BloodType.B, RhesusFactor = RhesusFactor.Positive, PhoneNumber = "+79000000000" },
        };

        var appointments = new[]
        {
            new Appointment { AppointmentTime = new DateTime(2025, 1, 1, 9, 0, 0), CabinetNumber = "101", IsRepeated = false, Patient = patients[0], Doctor = doctors[0] },
            new Appointment { AppointmentTime = new DateTime(2025, 3, 1, 10, 0, 0), CabinetNumber = "102", IsRepeated = true, Patient = patients[1], Doctor = doctors[1] },
            new Appointment { AppointmentTime = new DateTime(2025, 5, 1, 11, 0, 0), CabinetNumber = "103", IsRepeated = false, Patient = patients[2], Doctor = doctors[2] },
            new Appointment { AppointmentTime = new DateTime(2025, 7, 1, 12, 0, 0), CabinetNumber = "104", IsRepeated = false, Patient = patients[3], Doctor = doctors[3] },
            new Appointment { AppointmentTime = new DateTime(2025, 9, 1, 13, 0, 0), CabinetNumber = "105", IsRepeated = true, Patient = patients[4], Doctor = doctors[4] },
            new Appointment { AppointmentTime = new DateTime(2025, 11, 1, 14, 0, 0), CabinetNumber = "106", IsRepeated = false, Patient = patients[5], Doctor = doctors[5] },
            new Appointment { AppointmentTime = new DateTime(2025, 2, 1, 15, 0, 0), CabinetNumber = "107", IsRepeated = true, Patient = patients[6], Doctor = doctors[6] },
            new Appointment { AppointmentTime = new DateTime(2025, 4, 1, 16, 0, 0), CabinetNumber = "108", IsRepeated = false, Patient = patients[7], Doctor = doctors[9] },
            new Appointment { AppointmentTime = new DateTime(2025, 6, 1, 17, 0, 0), CabinetNumber = "109", IsRepeated = true, Patient = patients[8], Doctor = doctors[9] },
            new Appointment { AppointmentTime = new DateTime(2025, 8, 1, 18, 0, 0), CabinetNumber = "110", IsRepeated = false, Patient = patients[9], Doctor = doctors[9] },
            new Appointment { AppointmentTime = new DateTime(2025, 2, 1, 10, 0, 0), CabinetNumber = "101", IsRepeated = false, Patient = patients[9], Doctor = doctors[0] },
        };

        return (patients, doctors, specializations, appointments);
    }
}
