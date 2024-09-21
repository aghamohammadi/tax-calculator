﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculator.EntityBase.Context;

#nullable disable

namespace TaxCalculator.EntityBase.Migrations
{
    [DbContext(typeof(TaxCalculatorDbContext))]
    partial class TaxCalculatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Sweden",
                            Name = "Gothenburg"
                        });
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.CityTaxRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("HasSingleChargeRule")
                        .HasColumnType("bit");

                    b.Property<decimal>("MaxAmountPerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SingleChargeWindowInMinutes")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("CityTaxRule");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            HasSingleChargeRule = true,
                            MaxAmountPerDay = 60m,
                            SingleChargeWindowInMinutes = 60,
                            Year = 2013
                        });
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExemptDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsExemptBeforeHoliday")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Holiday");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            ExemptDate = new DateTime(2013, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsExemptBeforeHoliday = true
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            ExemptDate = new DateTime(2013, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsExemptBeforeHoliday = true
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            ExemptDate = new DateTime(2013, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsExemptBeforeHoliday = true
                        },
                        new
                        {
                            Id = 4,
                            CityId = 1,
                            ExemptDate = new DateTime(2013, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsExemptBeforeHoliday = true
                        },
                        new
                        {
                            Id = 5,
                            CityId = 1,
                            ExemptDate = new DateTime(2013, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsExemptBeforeHoliday = true
                        },
                        new
                        {
                            Id = 6,
                            CityId = 1,
                            ExemptDate = new DateTime(2013, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsExemptBeforeHoliday = true
                        });
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.MonthTaxExemption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("MonthTaxExemption");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Month = 7,
                            Year = 2013
                        });
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.TaxAmount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("TaxAmount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 8m,
                            CityId = 1,
                            EndTime = new TimeOnly(6, 29, 0),
                            StartTime = new TimeOnly(6, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 2,
                            Amount = 13m,
                            CityId = 1,
                            EndTime = new TimeOnly(6, 59, 0),
                            StartTime = new TimeOnly(6, 30, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 3,
                            Amount = 18m,
                            CityId = 1,
                            EndTime = new TimeOnly(7, 59, 0),
                            StartTime = new TimeOnly(7, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 4,
                            Amount = 13m,
                            CityId = 1,
                            EndTime = new TimeOnly(8, 29, 0),
                            StartTime = new TimeOnly(8, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 5,
                            Amount = 8m,
                            CityId = 1,
                            EndTime = new TimeOnly(14, 59, 0),
                            StartTime = new TimeOnly(8, 30, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 6,
                            Amount = 13m,
                            CityId = 1,
                            EndTime = new TimeOnly(15, 29, 0),
                            StartTime = new TimeOnly(15, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 7,
                            Amount = 18m,
                            CityId = 1,
                            EndTime = new TimeOnly(16, 59, 0),
                            StartTime = new TimeOnly(15, 30, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 8,
                            Amount = 13m,
                            CityId = 1,
                            EndTime = new TimeOnly(17, 59, 0),
                            StartTime = new TimeOnly(17, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 9,
                            Amount = 8m,
                            CityId = 1,
                            EndTime = new TimeOnly(18, 29, 0),
                            StartTime = new TimeOnly(18, 0, 0),
                            Year = 2013
                        },
                        new
                        {
                            Id = 10,
                            Amount = 0m,
                            CityId = 1,
                            EndTime = new TimeOnly(5, 59, 0),
                            StartTime = new TimeOnly(18, 30, 0),
                            Year = 2013
                        });
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LicensePlate = "EMG-001",
                            VehicleType = "Emergency"
                        },
                        new
                        {
                            Id = 2,
                            LicensePlate = "EMG-002",
                            VehicleType = "Emergency"
                        },
                        new
                        {
                            Id = 3,
                            LicensePlate = "BUS-001",
                            VehicleType = "Busses"
                        },
                        new
                        {
                            Id = 4,
                            LicensePlate = "BUS-002",
                            VehicleType = "Busses"
                        },
                        new
                        {
                            Id = 5,
                            LicensePlate = "DPL-001",
                            VehicleType = "Diplomat"
                        },
                        new
                        {
                            Id = 6,
                            LicensePlate = "DPL-002",
                            VehicleType = "Diplomat"
                        },
                        new
                        {
                            Id = 7,
                            LicensePlate = "MTR-001",
                            VehicleType = "Motorcycles"
                        },
                        new
                        {
                            Id = 8,
                            LicensePlate = "MTR-002",
                            VehicleType = "Motorcycles"
                        },
                        new
                        {
                            Id = 9,
                            LicensePlate = "MLT-001",
                            VehicleType = "Military"
                        },
                        new
                        {
                            Id = 10,
                            LicensePlate = "MLT-002",
                            VehicleType = "Military"
                        },
                        new
                        {
                            Id = 11,
                            LicensePlate = "FRG-001",
                            VehicleType = "Foreign"
                        },
                        new
                        {
                            Id = 12,
                            LicensePlate = "FRG-002",
                            VehicleType = "Foreign"
                        },
                        new
                        {
                            Id = 13,
                            LicensePlate = "FRG-003",
                            VehicleType = "Foreign"
                        },
                        new
                        {
                            Id = 14,
                            LicensePlate = "FRG-004",
                            VehicleType = "Foreign"
                        },
                        new
                        {
                            Id = 15,
                            LicensePlate = "FRG-005",
                            VehicleType = "Foreign"
                        },
                        new
                        {
                            Id = 16,
                            LicensePlate = "PRV-001",
                            VehicleType = "Cars"
                        },
                        new
                        {
                            Id = 17,
                            LicensePlate = "PRV-002",
                            VehicleType = "Cars"
                        },
                        new
                        {
                            Id = 18,
                            LicensePlate = "PRV-003",
                            VehicleType = "Cars"
                        },
                        new
                        {
                            Id = 19,
                            LicensePlate = "PKP-001",
                            VehicleType = "Trucks"
                        },
                        new
                        {
                            Id = 20,
                            LicensePlate = "PKP-002",
                            VehicleType = "Trucks"
                        },
                        new
                        {
                            Id = 21,
                            LicensePlate = "VAN-001",
                            VehicleType = "Vans"
                        },
                        new
                        {
                            Id = 22,
                            LicensePlate = "VAN-002",
                            VehicleType = "Vans"
                        },
                        new
                        {
                            Id = 23,
                            LicensePlate = "TRK-001",
                            VehicleType = "Trucks"
                        },
                        new
                        {
                            Id = 24,
                            LicensePlate = "TRK-002",
                            VehicleType = "Trucks"
                        },
                        new
                        {
                            Id = 25,
                            LicensePlate = "LUX-001",
                            VehicleType = "Cars"
                        });
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.VehicleExemption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("VehicleExemption");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            VehicleType = "Emergency"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            VehicleType = "Busses"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            VehicleType = "Diplomat"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 1,
                            VehicleType = "Motorcycles"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 1,
                            VehicleType = "Military"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 1,
                            VehicleType = "Foreign"
                        });
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.WeekendDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("WeekendDay");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            DayOfWeek = 6
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            DayOfWeek = 0
                        });
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.CityTaxRule", b =>
                {
                    b.HasOne("TaxCalculator.EntityBase.Entity.City", "City")
                        .WithMany("CityTaxRules")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.Holiday", b =>
                {
                    b.HasOne("TaxCalculator.EntityBase.Entity.City", "City")
                        .WithMany("Holidays")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.MonthTaxExemption", b =>
                {
                    b.HasOne("TaxCalculator.EntityBase.Entity.City", "City")
                        .WithMany("MonthTaxExemptions")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.TaxAmount", b =>
                {
                    b.HasOne("TaxCalculator.EntityBase.Entity.City", "City")
                        .WithMany("TaxAmounts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.VehicleExemption", b =>
                {
                    b.HasOne("TaxCalculator.EntityBase.Entity.City", "City")
                        .WithMany("VehicleExemptions")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.WeekendDay", b =>
                {
                    b.HasOne("TaxCalculator.EntityBase.Entity.City", "City")
                        .WithMany("WeekendDays")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TaxCalculator.EntityBase.Entity.City", b =>
                {
                    b.Navigation("CityTaxRules");

                    b.Navigation("Holidays");

                    b.Navigation("MonthTaxExemptions");

                    b.Navigation("TaxAmounts");

                    b.Navigation("VehicleExemptions");

                    b.Navigation("WeekendDays");
                });
#pragma warning restore 612, 618
        }
    }
}
