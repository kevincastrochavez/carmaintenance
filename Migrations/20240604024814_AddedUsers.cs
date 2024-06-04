using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class AddedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentMiles = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Users",
                columns: new[] { "UserId", "UserName" },
                values: new object[,]
                {
                    { "user1", "Alice" },
                    { "user2", "Bob" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarName", "CurrentMiles", "UserId" },
                values: new object[,]
                {
                    { new Guid("3b60efae-e751-4d4c-a9a5-50e0975499cf"), "Honda Civic", 90000, "user1" },
                    { new Guid("6093c8cb-942c-4fa9-b8d5-bc8fdc3c6212"), "Nissan Altima", 30000, "user2" },
                    { new Guid("83693178-be6c-4d3a-9840-77d0d7b83913"), "Toyota Camry", 120000, "user1" },
                    { new Guid("e2dabf2d-6d62-4430-8cbf-30731194def2"), "Chevrolet Malibu", 50000, "user2" },
                    { new Guid("e9819b15-3b79-4baa-b6c1-efb5321c8370"), "Ford Focus", 70000, "user2" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "MaintenanceRecordId", "CarId", "Component", "Date", "Miles", "Type" },
                values: new object[,]
                {
                    { new Guid("1613d49a-a7ea-4883-80fb-6e9a9a85b5e4"), new Guid("83693178-be6c-4d3a-9840-77d0d7b83913"), "EngineOil", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 115000, "Change" },
                    { new Guid("205ae21d-987c-44c6-87aa-28526aaf5a8e"), new Guid("e9819b15-3b79-4baa-b6c1-efb5321c8370"), "EngineOil", new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 68000, "Change" },
                    { new Guid("35fd68cd-ebf4-4807-ac86-ecfb34797a17"), new Guid("e2dabf2d-6d62-4430-8cbf-30731194def2"), "EngineOil", new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000, "Change" },
                    { new Guid("578d7eca-8221-4f1b-8dfe-9c6996af2e12"), new Guid("e9819b15-3b79-4baa-b6c1-efb5321c8370"), "Tires", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 70000, "Check" },
                    { new Guid("65235f73-5590-46c9-9edd-4fa1d957f77e"), new Guid("e2dabf2d-6d62-4430-8cbf-30731194def2"), "Battery", new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 47000, "Check" },
                    { new Guid("ae370782-abf1-47b7-9b2a-7a2e7fd4591a"), new Guid("83693178-be6c-4d3a-9840-77d0d7b83913"), "TransmissionFluid", new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 118000, "Check" },
                    { new Guid("b55b950f-c55a-4a0f-8cb5-9558813e30c3"), new Guid("6093c8cb-942c-4fa9-b8d5-bc8fdc3c6212"), "EngineOil", new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000, "Change" },
                    { new Guid("c0cba228-84b1-4ac8-9e0f-533cb9481676"), new Guid("3b60efae-e751-4d4c-a9a5-50e0975499cf"), "Brakes", new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 88000, "Check" },
                    { new Guid("c6534793-688d-4c59-a2cd-1f445861d06c"), new Guid("6093c8cb-942c-4fa9-b8d5-bc8fdc3c6212"), "AirFilter", new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 28000, "Check" },
                    { new Guid("f59d94a8-2ecb-460b-ac59-4db634331e0c"), new Guid("3b60efae-e751-4d4c-a9a5-50e0975499cf"), "EngineOil", new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 85000, "Change" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

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

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
