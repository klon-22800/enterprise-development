using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "Address", "BirthDate", "BloodType", "Gender", "Name", "PassportNumber", "Patronymic", "PhoneNumber", "RhesusFactor", "Surname" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000000"), "Пушкина 5", new DateOnly(1992, 9, 25), 2, 1, "Юлия", "2222 000010", "Егоровна", "+79000000000", 1, "Тарасова" },
                    { new Guid("c0000000-0000-0000-0000-000000000001"), "Ленина 1", new DateOnly(1995, 8, 10), 0, 0, "Андрей", "2222 000001", "Иванович", "+79001111111", 1, "Козлов" },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), "Мира 7", new DateOnly(1987, 4, 14), 1, 1, "Светлана", "2222 000002", "Сергеевна", "+79002222222", 0, "Павлова" },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), "Гагарина 10", new DateOnly(2000, 12, 1), 2, 0, "Никита", "2222 000003", "Павлович", "+79003333333", 1, "Сергеев" },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), "Советская 15", new DateOnly(1999, 3, 3), 3, 1, "Марина", "2222 000004", "Олеговна", "+79004444444", 1, "Соколова" },
                    { new Guid("c0000000-0000-0000-0000-000000000005"), "Парковая 18", new DateOnly(1985, 10, 20), 0, 0, "Павел", "2222 000005", "Андреевич", "+79005555555", 0, "Михайлов" },
                    { new Guid("c0000000-0000-0000-0000-000000000006"), "Центральная 9", new DateOnly(1993, 5, 15), 2, 1, "Екатерина", "2222 000006", "Михайловна", "+79006666666", 1, "Новикова" },
                    { new Guid("c0000000-0000-0000-0000-000000000007"), "Школьная 22", new DateOnly(1990, 11, 8), 1, 0, "Игорь", "2222 000007", "Дмитриевич", "+79007777777", 1, "Васильев" },
                    { new Guid("c0000000-0000-0000-0000-000000000008"), "Молодежная 3", new DateOnly(1998, 1, 30), 0, 1, "Алина", "2222 000008", "Станиславовна", "+79008888888", 0, "Григорьева" },
                    { new Guid("c0000000-0000-0000-0000-000000000009"), "Заречная 12", new DateOnly(1982, 7, 19), 3, 0, "Руслан", "2222 000009", "Владимирович", "+79009999999", 0, "Александров" }
                });

            migrationBuilder.InsertData(
                table: "specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000000"), "Психиатр" },
                    { new Guid("b0000000-0000-0000-0000-000000000001"), "Хирург" },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), "Терапевт" },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), "Офтальмолог" },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), "Невролог" },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), "Педиатр" },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), "Проктолог" },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), "Дерматолог" },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), "Ортопед" },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), "Эндокринолог" }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "Id", "BirthDate", "Experience", "Name", "PassportNumber", "Patronymic", "SpecializationId", "Surname" },
                values: new object[,]
                {
                    { new Guid("d0000000-0000-0000-0000-000000000000"), new DateOnly(1969, 12, 25), 30, "Вячеслав", "0000 100010", "Вячеславович", new Guid("b0000000-0000-0000-0000-000000000000"), "Ряхов" },
                    { new Guid("d0000000-0000-0000-0000-000000000001"), new DateOnly(1975, 5, 15), 20, "Иван", "1111 100001", "Иванович", new Guid("b0000000-0000-0000-0000-000000000001"), "Иванов" },
                    { new Guid("d0000000-0000-0000-0000-000000000002"), new DateOnly(1980, 3, 21), 15, "Петр", "2222 200002", "Петрович", new Guid("b0000000-0000-0000-0000-000000000002"), "Петров" },
                    { new Guid("d0000000-0000-0000-0000-000000000003"), new DateOnly(1988, 7, 9), 10, "Анна", "3333 300003", "Сергеевна", new Guid("b0000000-0000-0000-0000-000000000003"), "Смирнова" },
                    { new Guid("d0000000-0000-0000-0000-000000000004"), new DateOnly(1970, 11, 3), 25, "Сергей", "4444 400004", "Андреевич", new Guid("b0000000-0000-0000-0000-000000000004"), "Сидоров" },
                    { new Guid("d0000000-0000-0000-0000-000000000005"), new DateOnly(1983, 6, 30), 12, "Дмитрий", "6666 600006", "Михайлович", new Guid("b0000000-0000-0000-0000-000000000005"), "Орлов" },
                    { new Guid("d0000000-0000-0000-0000-000000000006"), new DateOnly(1990, 1, 17), 7, "Михаил", "6412 100503", "Романович", new Guid("b0000000-0000-0000-0000-000000000006"), "Косенко" },
                    { new Guid("d0000000-0000-0000-0000-000000000007"), new DateOnly(1985, 4, 12), 9, "Ольга", "7777 700007", "Александровна", new Guid("b0000000-0000-0000-0000-000000000007"), "Морозова" },
                    { new Guid("d0000000-0000-0000-0000-000000000008"), new DateOnly(1978, 9, 23), 18, "Алексей", "8888 800008", "Игоревич", new Guid("b0000000-0000-0000-0000-000000000008"), "Федоров" },
                    { new Guid("d0000000-0000-0000-0000-000000000009"), new DateOnly(1992, 2, 2), 5, "Елена", "9999 900009", "Степановна", new Guid("b0000000-0000-0000-0000-000000000009"), "Соболева" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Id", "AppointmentTime", "DoctorId", "IsRepeated", "OfficeNumber", "PatientId" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000001"), false, "101", new Guid("c0000000-0000-0000-0000-000000000001") },
                    { new Guid("a0000000-0000-0000-0000-000000000002"), new DateTime(2025, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000002"), true, "102", new Guid("c0000000-0000-0000-0000-000000000002") },
                    { new Guid("a0000000-0000-0000-0000-000000000003"), new DateTime(2025, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000003"), false, "103", new Guid("c0000000-0000-0000-0000-000000000003") },
                    { new Guid("a0000000-0000-0000-0000-000000000004"), new DateTime(2025, 7, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000004"), false, "104", new Guid("c0000000-0000-0000-0000-000000000004") },
                    { new Guid("a0000000-0000-0000-0000-000000000005"), new DateTime(2025, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000005"), true, "105", new Guid("c0000000-0000-0000-0000-000000000005") },
                    { new Guid("a0000000-0000-0000-0000-000000000006"), new DateTime(2025, 11, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000006"), false, "106", new Guid("c0000000-0000-0000-0000-000000000006") },
                    { new Guid("a0000000-0000-0000-0000-000000000007"), new DateTime(2025, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000007"), true, "107", new Guid("c0000000-0000-0000-0000-000000000007") },
                    { new Guid("a0000000-0000-0000-0000-000000000008"), new DateTime(2025, 4, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000008"), false, "108", new Guid("c0000000-0000-0000-0000-000000000008") },
                    { new Guid("a0000000-0000-0000-0000-000000000009"), new DateTime(2025, 6, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000009"), true, "109", new Guid("c0000000-0000-0000-0000-000000000009") },
                    { new Guid("a0000000-0000-0000-0000-000000000010"), new DateTime(2025, 8, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000000"), false, "110", new Guid("c0000000-0000-0000-0000-000000000000") },
                    { new Guid("a0000000-0000-0000-0000-000000000011"), new DateTime(2025, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0000000-0000-0000-0000-000000000001"), false, "101", new Guid("c0000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "specializations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"));
        }
    }
}
