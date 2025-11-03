using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddAppointmentEntity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "appointments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                OfficeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                IsRepeated = table.Column<bool>(type: "bit", nullable: false),
                PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_appointments", x => x.Id);
                table.ForeignKey(
                    name: "FK_appointments_doctors_DoctorId",
                    column: x => x.DoctorId,
                    principalTable: "doctors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_appointments_patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_appointments_DoctorId",
            table: "appointments",
            column: "DoctorId");

        migrationBuilder.CreateIndex(
            name: "IX_appointments_PatientId",
            table: "appointments",
            column: "PatientId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "appointments");
    }
}
