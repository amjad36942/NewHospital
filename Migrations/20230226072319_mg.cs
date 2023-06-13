using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniHospitalProject.Migrations
{
    /// <inheritdoc />
    public partial class mg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorModel_DepartmentModel_DepartmentId",
                table: "DoctorModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorModel",
                table: "DoctorModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentModel",
                table: "DepartmentModel");

            migrationBuilder.RenameTable(
                name: "DoctorModel",
                newName: "DoctorTBL");

            migrationBuilder.RenameTable(
                name: "DepartmentModel",
                newName: "DepartmentTBL");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorModel_DepartmentId",
                table: "DoctorTBL",
                newName: "IX_DoctorTBL_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorTBL",
                table: "DoctorTBL",
                column: "DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentTBL",
                table: "DepartmentTBL",
                column: "DepartmentId");

            migrationBuilder.CreateTable(
                name: "doctorAppointmentTBL",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DocId = table.Column<int>(type: "int", nullable: false),
                    TotalFee = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorAppointmentTBL", x => x.AppId);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDaysTBL",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeSlot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isavailable = table.Column<bool>(type: "bit", nullable: false),
                    DoctorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorLastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDaysTBL", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "PatientTBL",
                columns: table => new
                {
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTBL", x => x.PId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorTBL_DepartmentTBL_DepartmentId",
                table: "DoctorTBL",
                column: "DepartmentId",
                principalTable: "DepartmentTBL",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorTBL_DepartmentTBL_DepartmentId",
                table: "DoctorTBL");

            migrationBuilder.DropTable(
                name: "doctorAppointmentTBL");

            migrationBuilder.DropTable(
                name: "DoctorDaysTBL");

            migrationBuilder.DropTable(
                name: "PatientTBL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorTBL",
                table: "DoctorTBL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentTBL",
                table: "DepartmentTBL");

            migrationBuilder.RenameTable(
                name: "DoctorTBL",
                newName: "DoctorModel");

            migrationBuilder.RenameTable(
                name: "DepartmentTBL",
                newName: "DepartmentModel");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorTBL_DepartmentId",
                table: "DoctorModel",
                newName: "IX_DoctorModel_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorModel",
                table: "DoctorModel",
                column: "DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentModel",
                table: "DepartmentModel",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorModel_DepartmentModel_DepartmentId",
                table: "DoctorModel",
                column: "DepartmentId",
                principalTable: "DepartmentModel",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
