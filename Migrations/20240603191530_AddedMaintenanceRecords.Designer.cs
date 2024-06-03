﻿// <auto-generated />
using System;
using CarMaintenance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarMaintenance.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    [Migration("20240603191530_AddedMaintenanceRecords")]
    partial class AddedMaintenanceRecords
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarMaintenance.Models.Domain.Car", b =>
                {
                    b.Property<Guid>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentMiles")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarId = new Guid("ed15c113-a7fe-4970-bc82-53ccd2f87ee2"),
                            CarName = "Toyota Camry",
                            CurrentMiles = 120000
                        },
                        new
                        {
                            CarId = new Guid("46f7785e-7780-4f0f-a3b8-3a1ae3d774f3"),
                            CarName = "Honda Civic",
                            CurrentMiles = 90000
                        },
                        new
                        {
                            CarId = new Guid("0e117f0a-ffd2-4c3f-b559-43b1c674d4b6"),
                            CarName = "Ford Focus",
                            CurrentMiles = 70000
                        },
                        new
                        {
                            CarId = new Guid("40a069c9-5f64-4e15-b26a-17c618fcf687"),
                            CarName = "Chevrolet Malibu",
                            CurrentMiles = 50000
                        },
                        new
                        {
                            CarId = new Guid("e18ae45a-9924-4e0c-9439-24723a077d22"),
                            CarName = "Nissan Altima",
                            CurrentMiles = 30000
                        });
                });

            modelBuilder.Entity("CarMaintenance.Models.Domain.MaintenanceRecord", b =>
                {
                    b.Property<Guid>("MaintenanceRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Component")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Miles")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaintenanceRecordId");

                    b.HasIndex("CarId");

                    b.ToTable("MaintenanceRecords");

                    b.HasData(
                        new
                        {
                            MaintenanceRecordId = new Guid("331b6b47-1c9b-4898-978d-85a1f5071bfb"),
                            CarId = new Guid("ed15c113-a7fe-4970-bc82-53ccd2f87ee2"),
                            Component = "EngineOil",
                            Date = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 115000,
                            Type = "Change"
                        },
                        new
                        {
                            MaintenanceRecordId = new Guid("4ac53a32-1fdf-4119-ad05-288b0e5c07f4"),
                            CarId = new Guid("ed15c113-a7fe-4970-bc82-53ccd2f87ee2"),
                            Component = "TransmissionFluid",
                            Date = new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 118000,
                            Type = "Check"
                        },
                        new
                        {
                            MaintenanceRecordId = new Guid("a8c7a5c1-a0b4-43a7-b264-5a0ba697b216"),
                            CarId = new Guid("46f7785e-7780-4f0f-a3b8-3a1ae3d774f3"),
                            Component = "EngineOil",
                            Date = new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 85000,
                            Type = "Change"
                        },
                        new
                        {
                            MaintenanceRecordId = new Guid("78670dfa-2355-47c1-bd7a-223acffc3f83"),
                            CarId = new Guid("46f7785e-7780-4f0f-a3b8-3a1ae3d774f3"),
                            Component = "Brakes",
                            Date = new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 88000,
                            Type = "Check"
                        },
                        new
                        {
                            MaintenanceRecordId = new Guid("0eba66a6-79f8-433e-bc31-9de8b8aecaf5"),
                            CarId = new Guid("0e117f0a-ffd2-4c3f-b559-43b1c674d4b6"),
                            Component = "EngineOil",
                            Date = new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 68000,
                            Type = "Change"
                        },
                        new
                        {
                            MaintenanceRecordId = new Guid("bd01de31-0c75-451a-bbf7-f252babe2749"),
                            CarId = new Guid("0e117f0a-ffd2-4c3f-b559-43b1c674d4b6"),
                            Component = "Tires",
                            Date = new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 70000,
                            Type = "Check"
                        },
                        new
                        {
                            MaintenanceRecordId = new Guid("58662f97-b471-4ef0-b903-af115689ecc8"),
                            CarId = new Guid("40a069c9-5f64-4e15-b26a-17c618fcf687"),
                            Component = "EngineOil",
                            Date = new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 45000,
                            Type = "Change"
                        },
                        new
                        {
                            MaintenanceRecordId = new Guid("c1821b23-2509-4dd0-bf70-39e5067787be"),
                            CarId = new Guid("40a069c9-5f64-4e15-b26a-17c618fcf687"),
                            Component = "Battery",
                            Date = new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 47000,
                            Type = "Check"
                        },
                        new
                        {
                            MaintenanceRecordId = new Guid("6e44ab04-29ef-4f25-a8ae-b259a5ba4c17"),
                            CarId = new Guid("e18ae45a-9924-4e0c-9439-24723a077d22"),
                            Component = "EngineOil",
                            Date = new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 25000,
                            Type = "Change"
                        },
                        new
                        {
                            MaintenanceRecordId = new Guid("1d1157fd-d5cc-42fe-86aa-cc445d483a6b"),
                            CarId = new Guid("e18ae45a-9924-4e0c-9439-24723a077d22"),
                            Component = "AirFilter",
                            Date = new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Miles = 28000,
                            Type = "Check"
                        });
                });

            modelBuilder.Entity("CarMaintenance.Models.Domain.MaintenanceRecord", b =>
                {
                    b.HasOne("CarMaintenance.Models.Domain.Car", null)
                        .WithMany("MaintenanceRecords")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarMaintenance.Models.Domain.Car", b =>
                {
                    b.Navigation("MaintenanceRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
