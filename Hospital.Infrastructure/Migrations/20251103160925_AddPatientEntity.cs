using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddPatientEntity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "patients",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Gender = table.Column<int>(type: "int", nullable: false),
                BloodType = table.Column<int>(type: "int", nullable: true),
                RhesusFactor = table.Column<int>(type: "int", nullable: true),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_patients", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "patients");
    }
}
