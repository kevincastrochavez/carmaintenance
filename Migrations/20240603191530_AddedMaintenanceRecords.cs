using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaintenanceRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentMiles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    MaintenanceRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Miles = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Component = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.MaintenanceRecordId);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarName", "CurrentMiles" },
                values: new object[,]
                {
                    { new Guid("0e117f0a-ffd2-4c3f-b559-43b1c674d4b6"), "Ford Focus", 70000 },
                    { new Guid("40a069c9-5f64-4e15-b26a-17c618fcf687"), "Chevrolet Malibu", 50000 },
                    { new Guid("46f7785e-7780-4f0f-a3b8-3a1ae3d774f3"), "Honda Civic", 90000 },
                    { new Guid("e18ae45a-9924-4e0c-9439-24723a077d22"), "Nissan Altima", 30000 },
                    { new Guid("ed15c113-a7fe-4970-bc82-53ccd2f87ee2"), "Toyota Camry", 120000 }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "MaintenanceRecordId", "CarId", "Component", "Date", "Miles", "Type" },
                values: new object[,]
                {
                    { new Guid("0eba66a6-79f8-433e-bc31-9de8b8aecaf5"), new Guid("0e117f0a-ffd2-4c3f-b559-43b1c674d4b6"), "EngineOil", new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 68000, "Change" },
                    { new Guid("1d1157fd-d5cc-42fe-86aa-cc445d483a6b"), new Guid("e18ae45a-9924-4e0c-9439-24723a077d22"), "AirFilter", new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 28000, "Check" },
                    { new Guid("331b6b47-1c9b-4898-978d-85a1f5071bfb"), new Guid("ed15c113-a7fe-4970-bc82-53ccd2f87ee2"), "EngineOil", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 115000, "Change" },
                    { new Guid("4ac53a32-1fdf-4119-ad05-288b0e5c07f4"), new Guid("ed15c113-a7fe-4970-bc82-53ccd2f87ee2"), "TransmissionFluid", new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 118000, "Check" },
                    { new Guid("58662f97-b471-4ef0-b903-af115689ecc8"), new Guid("40a069c9-5f64-4e15-b26a-17c618fcf687"), "EngineOil", new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000, "Change" },
                    { new Guid("6e44ab04-29ef-4f25-a8ae-b259a5ba4c17"), new Guid("e18ae45a-9924-4e0c-9439-24723a077d22"), "EngineOil", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000, "Change" },
                    { new Guid("78670dfa-2355-47c1-bd7a-223acffc3f83"), new Guid("46f7785e-7780-4f0f-a3b8-3a1ae3d774f3"), "Brakes", new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 88000, "Check" },
                    { new Guid("a8c7a5c1-a0b4-43a7-b264-5a0ba697b216"), new Guid("46f7785e-7780-4f0f-a3b8-3a1ae3d774f3"), "EngineOil", new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 85000, "Change" },
                    { new Guid("bd01de31-0c75-451a-bbf7-f252babe2749"), new Guid("0e117f0a-ffd2-4c3f-b559-43b1c674d4b6"), "Tires", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 70000, "Check" },
                    { new Guid("c1821b23-2509-4dd0-bf70-39e5067787be"), new Guid("40a069c9-5f64-4e15-b26a-17c618fcf687"), "Battery", new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 47000, "Check" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_CarId",
                table: "MaintenanceRecords",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
