using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "specializations",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_specializations", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "doctors",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Expirience = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_doctors", x => x.Id);
                table.ForeignKey(
                    name: "FK_doctors_specializations_SpecializationId",
                    column: x => x.SpecializationId,
                    principalTable: "specializations",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_doctors_SpecializationId",
            table: "doctors",
            column: "SpecializationId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "doctors");

        migrationBuilder.DropTable(
            name: "specializations");
    }
}
